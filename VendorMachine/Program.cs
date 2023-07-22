using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            var _vendingMachineService = new VendingMachineService(new CoinService(), new ProductService(new ProductStore()));
            Console.WriteLine("Fruits Vending Machine");
            IOHelpers.LineSpace();
            //case 1 - invalid coins
            Console.WriteLine("\ncase 1 - Non US coins coins\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(7)));
            IOHelpers.LineSpace();
            // case 2 - valid coins but not acceptable,return coins to user
            Console.WriteLine("\ncase 2 - valid coins but not acceptable,return coins to user\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(0)));

            IOHelpers.LineSpace();
            //Valid Coin, no return
            Console.WriteLine("\ncase 3 - valid coins,no return coins\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(2)));
            IOHelpers.LineSpace();
            //Valid Coin, no return
            Console.WriteLine("\ncase 3 repeat - valid coins,no return coins\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(3)));
            IOHelpers.LineSpace();
            //case 4 - valid coins, invalid product code
            Console.WriteLine("\ncase 4 - valid coins, invalid product code\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(5)));
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.SelectProduct("Fruit10"));
            IOHelpers.LineSpace();

             //case 5 only product selection with previous inserted coins and returning change
            Console.WriteLine("\ncase 5 - only product selection with previous inserted coins and returning change\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.SelectProduct("Fruit1"));
            IOHelpers.WriteItemChangeToScreen(_vendingMachineService.ReturnCoinsChange());
            IOHelpers.LineSpace();

            //case 6 - valid coins, valid product code, less amount entered            
            Console.WriteLine("\ncase 6 - valid coins, valid product code, less amount entered\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(2)));
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.SelectProduct("Fruit1"));
            IOHelpers.LineSpace();
            Console.WriteLine("\ncase 3 repeat to insert more coin to buy product - valid coins,no return coins and select product to buy and return the change\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(3)));
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.SelectProduct("Fruit3"));
            IOHelpers.WriteItemChangeToScreen(_vendingMachineService.ReturnCoinsChange());
            IOHelpers.LineSpace();

            //case 7 - valid coins, valid product code, more amount entered, make change            
            Console.WriteLine("\ncase 7 - valid coins, valid product code, more amount entered, make change\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(5)));
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.SelectProduct("Fruit2"));
            IOHelpers.WriteItemChangeToScreen(_vendingMachineService.ReturnCoinsChange());
            IOHelpers.LineSpace();
            //case 8 - valid coins, valid product code, correct(>=) amount entered, sold out            
            Console.WriteLine("\ncase 8 - valid coins, valid product code, correct(>=) amount entered, sold out\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(5)));
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.SelectProduct("Fruit4"));
            IOHelpers.LineSpace();
            // case 9 only return coins bcz sold out 
            Console.WriteLine("\ncase 9 - only return coins bcz sold out (Already inserted coins withdraw)\n");
            IOHelpers.WriteItemChangeToScreen(_vendingMachineService.ReturnCoinsChange());
            IOHelpers.LineSpace();
            //case 10 - valid coins, valid product code, correct(>=) amount entered, sold out, return coins            
            Console.WriteLine("\ncase 10 - valid coins, valid product code, correct(>=) amount entered, sold out, return coins\n");
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.AcceptCoin(IOHelpers.SelectCoinForInput(5)));
            IOHelpers.WriteVendingResponseToScreen(_vendingMachineService.SelectProduct("Fruit4"));
            IOHelpers.WriteItemChangeToScreen(_vendingMachineService.ReturnCoinsChange());
            IOHelpers.LineSpace();
            Console.ReadLine();
        }
    }
}