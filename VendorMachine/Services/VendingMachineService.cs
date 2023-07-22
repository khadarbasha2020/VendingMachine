using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Constants;
using VendingMachine.Enums;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class VendingMachineService : IVendingMachine
    {
        private readonly ICoinService _coinService;
        private readonly IProductService _productService;
        private decimal _cost;
        private decimal _LastInsertedValidCoinAmount;
        public VendingMachineService(ICoinService coinService, IProductService productService)
        {
            _productService = productService;
            _coinService = coinService;
        }
        public VendingCoinResponseDTO AcceptCoin(InputCoins inputCoin)
        {
            VendingCoinResponseDTO responseDTO = new VendingCoinResponseDTO();
            try
            {
                if (inputCoin == null)
                    throw new ArgumentNullException(ApplicationConstants.NoneCoinInput);

                var acceptedCoin  = _coinService.GetCoin(inputCoin);
                // out of coinns list or non us coin
                _LastInsertedValidCoinAmount = 0.0m;
                if (acceptedCoin == null)
                {
                    responseDTO.Message = ApplicationConstants.InsertValidCoin;
                    responseDTO.IsRejectedCoin = true;
                    responseDTO.RejectedCoin = inputCoin; //return rejected coin
                    responseDTO.CoinName = "rejected Coin";
                    responseDTO.AmountInserted = "Rejected or non us coin";
                    return responseDTO;
                }
                // valid us coins(Acceptable/ Non acceptable rejected coins)
                responseDTO.IsRejectedCoin = !acceptedCoin.IsValid;

                if (acceptedCoin.IsValid)
                {
                    _cost += acceptedCoin.Value;
                    _LastInsertedValidCoinAmount = acceptedCoin.Value;
                }                    
                responseDTO.Message = "Coin inserted properly thank you.";
                responseDTO.AmountInserted = acceptedCoin.Value.ToString();
                responseDTO.IsSuccess = acceptedCoin.IsValid;
                responseDTO.NetAmount = _cost;


                responseDTO.CoinName = acceptedCoin.Type.ToString();
                return responseDTO;


            }
            catch (Exception)
            {
                throw new Exception(ApplicationConstants.SomeThingWentWrong);
            }
        }
        public VendingCoinResponseDTO SelectProduct(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("Code parameter empty!");

            var response = new VendingCoinResponseDTO();

            //check if the code is valid            
            //if no, return error object with details
            var product = _productService.GetProduct(code);

            //invalid code entered
            if (product == null)
            {
                response.Message = "Invalid Product Selected. Please try again";
                response.IsSuccess = false;
                response.NetAmount = _cost;
                return response;
            }

            //no coins entered, but selection pressed
            if (_cost == 0)
            {
                //if exact change item, message = "exact change only"
                response.Message = "Insert Coin";
                response.IsSuccess = false;
                response.NetAmount = _cost;
                return response;
            }

            //entered coins less than cost
            if (_cost < product.ProductPrice)
            {
                response.Message = string.Format($"Selected Product Price is: {product.ProductPrice}");
                response.IsSuccess = false;
                response.NetAmount = _cost;
                return response;
            }

            //all good, valid code and valid amount entered
            var quantity = _productService.GetProductQuantity(code);
            if (quantity > 0)
            {
                response.Message = "Thank You";
                response.ProductDetails = $"Product Name: \n ================== \n{product.ProductName}, \nProduct Price: {product.ProductPrice}, \n Product Code:{product.ProductCode}, \n ProductType: {product.ProductType.ToString()} , \n product Quantity: {quantity}";
                response.IsSuccess = true;
                _productService.UpdateProductQuantity(code);
                response.ChangeAmount = MakeChange(Convert.ToDouble(_cost - product.ProductPrice));
                _cost = 0.00m;
                response.NetAmount = _cost;
                return response;
            }

            response.Message = "SOLD OUT";
            response.IsSuccess = false;
            response.NetAmount = _cost;
            return response;
        }
        public IEnumerable<ChangeCoins> ReturnCoinsChange()
        {
            var result = MakeChange(Convert.ToDouble(_cost));
            _cost = 0.00m;
            return result;
        }
        private IEnumerable<ChangeCoins> MakeChange(double input)
        {
            List<ChangeCoins> itemchange = new List<ChangeCoins>();

            var coins = GetCoinValuesDictionary();

            var change = input;
            if (change == 0) return itemchange;

            foreach (var value in coins.Keys)
            {
                var result = (int)(change / coins[value]);
                if (result > 0)
                {
                    itemchange.Add(new ChangeCoins
                    {
                        Type = value,
                        Number = result
                    });

                    change = Math.Round(change - (result * coins[value]), 3);
                    var remainingAmount = change;
                    if (remainingAmount == 0)
                        return itemchange;
                }
            }
            return itemchange;
        }

        private Dictionary<CoinType, double> GetCoinValuesDictionary()
        {
            return new Dictionary<CoinType, double>
            { { CoinType.Dollar, 1.00 }, { CoinType.HalfDollar, 0.50 }, { CoinType.Quarters, 0.25 }, { CoinType.Dimes, 0.10 } };
        }

        public IEnumerable<ChangeCoins> ReturnRejectedValidCoin()
        {
            var result = MakeChange(Convert.ToDouble(_LastInsertedValidCoinAmount));
            _LastInsertedValidCoinAmount = 0.00m;
            return result;
        }
    }

}
