using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Constants;
using VendingMachine.Enums;
using VendingMachine.Models;

namespace VendingMachine
{
    public static class IOHelpers
    {
        public static InputCoins SelectCoinForInput(int selectedCoinVal)
        {
            var coinsList = CoinsStore.InputCoinsExampleList;
            if (selectedCoinVal > coinsList.Count)
            {
                throw new ArgumentException("Invalid input");
            }
            return CoinsStore.InputCoinsExampleList[selectedCoinVal];
        }
        public static void WriteVendingResponseToScreen(VendingCoinResponseDTO response)
        {

            Console.WriteLine("Message : " + response.Message);
            Console.WriteLine("IsRejectedCoin : " + response.IsRejectedCoin);

            if (response.RejectedCoin != null)
            {
                Console.WriteLine("Coin Diameter: " + response.RejectedCoin.Diameter);
                Console.WriteLine("Coin Weight: " + response.RejectedCoin.Mass);
                Console.WriteLine("Coin Thickness: " + response.RejectedCoin.Thickness);
            }
            if (!string.IsNullOrEmpty(response.CoinName))
                Console.WriteLine("Coin Name: " + response.CoinName);
            if (!string.IsNullOrEmpty(response.AmountInserted))
                Console.WriteLine("Coin value/Price " + response.AmountInserted);
            Console.WriteLine("Net Balance Amount : " + response.NetAmount);

            if (!string.IsNullOrEmpty(response.AmountInserted) && !response.IsSuccess || response.RejectedCoin != null)
            {
                Console.WriteLine($"Rejected coins are placed in the coin return, Coin Name : {response.CoinName}");
                Console.WriteLine("Please take your coin and insert a valid coin");
            }
            if(!string.IsNullOrEmpty(response.ProductDetails))
                Console.WriteLine($"Product Details {response.ProductDetails}");
            if (response.ChangeAmount != null)
                WriteItemChangeToScreen(response.ChangeAmount);

            // Console.WriteLine("IsSuccess : " + response.IsSuccess);

        }

        public static void WriteItemChangeToScreen(IEnumerable<ChangeCoins> change)
        {
            if (!change.Any())
                return;
            Console.WriteLine("\nChange Returned\n");

            foreach (var item in change)
            {
                switch (item.Type)
                {
                    case CoinType.Nickels:
                        Console.WriteLine("No Of Nickels(0.05) : " + item.Number);
                        break;
                    case CoinType.Dimes:
                        Console.WriteLine("No Of Dimes(0.10) : " + item.Number);
                        break;
                    case CoinType.Quarters:
                        Console.WriteLine("No Of Quarters(0.25) : " + item.Number);
                        break;
                    case CoinType.HalfDollar:
                        Console.WriteLine("No Of HalfDollar(0.50) : " + item.Number);
                        break;
                    case CoinType.Dollar:
                        Console.WriteLine("No Of 1 Dollar : " + item.Number);
                        break;
                    default:
                        Console.WriteLine("0");
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        public static void LineSpace()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
        }
    }
}
