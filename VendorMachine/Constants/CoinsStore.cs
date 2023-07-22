namespace VendingMachine.Constants
{
    using VendingMachine.Enums;
    using VendingMachine.Models;
    /// <summary>
    /// Specifies Accepted coins constrant
    /// </summary>
    public static class CoinsStore
    {
        public static readonly List<ValidCoin> AvailableCoinsList = new List<ValidCoin> {
                new ValidCoin{Diameter = 19.05m, Thickness = 1.52m, Type = CoinType.Pennies, Mass = 2.5m, Value = 0.01m, IsValid = CoinType.Pennies.GetEnumIsValid()},
                new ValidCoin{Diameter = 21.21m, Thickness = 1.95m, Type = CoinType.Nickels, Mass = 5.0m, Value = 0.05m, IsValid = CoinType.Nickels.GetEnumIsValid()},
                new ValidCoin {Diameter = 17.91m, Thickness = 1.35m, Type = CoinType.Dimes, Mass = 2.268m, Value = 0.10m, IsValid = CoinType.Dimes.GetEnumIsValid()},
                new ValidCoin {Diameter = 24.26m, Thickness = 1.75m, Type = CoinType.Quarters, Mass = 5.670m, Value = 0.25m, IsValid = CoinType.Quarters.GetEnumIsValid()},
                new ValidCoin {Diameter = 30.61m, Thickness = 2.15m, Type = CoinType.HalfDollar, Mass = 11.34m, Value = 0.50m, IsValid = CoinType.HalfDollar.GetEnumIsValid()},
                new ValidCoin {Diameter = 26.49m, Thickness = 2.00m, Type = CoinType.Dollar, Mass = 8.1m, Value = 1.00m, IsValid = CoinType.Dollar.GetEnumIsValid()}
        };
        public static readonly List<InputCoins> InputCoinsExampleList = new List<InputCoins> {
                new InputCoins{Diameter = 19.05m, Thickness = 1.52m, Mass = 2.5m},
                new InputCoins{Diameter = 21.21m, Thickness = 1.95m, Mass = 5.0m},
                new InputCoins {Diameter = 17.91m, Thickness = 1.35m, Mass = 2.268m},
                new InputCoins {Diameter = 24.26m, Thickness = 1.75m, Mass = 5.670m},
                new InputCoins {Diameter = 30.61m, Thickness = 2.15m, Mass = 11.34m},
                new InputCoins {Diameter = 26.49m, Thickness = 2.00m, Mass = 8.1m},
                new InputCoins {Diameter = 35m, Thickness = 2.5m, Mass = 12.0m}, // invalid
                new InputCoins {Diameter = 40m, Thickness = 3m, Mass = 15.0m}, // invalid
        };
    };
}
