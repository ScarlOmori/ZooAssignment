using ZooApi.Models;

namespace ZooApi.Services
{
    /// <summary>
    /// Contains functionality for calculating the cost of animal food.
    /// </summary>
    public class FoodCostCalculator : IFoodCostCalculator
    {
        private readonly IDataReader _dataLoader;

        public FoodCostCalculator(IDataReader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        /// <summary>
        /// Calculate daily cost of animal food.
        /// </summary>
        /// <param name="path">Path to the folder with files prices.txt, animal.csv, zoo.csv.</param>
        /// <returns>Cost of animal food.</returns>
        public decimal CalculateDailyCost(string path)
        {
            var foodPrices = _dataLoader.ReadFoodPrices(Path.Combine(path,"prices.txt"));
            var animalInfos = _dataLoader.ReadAnimalInfo(Path.Combine(path, "animals.csv"));
            var zooAnimals = _dataLoader.ReadZooAnimals(Path.Combine(path, "zoo.csv"));

            decimal totalCost = 0;

            foreach (var animal in zooAnimals)
            {
                var info = animalInfos[animal.Type];
                decimal dailyFoodAmount = animal.Weight * info.Coefficient;

                switch (info.FoodType)
                {
                    case "meat":
                        totalCost += dailyFoodAmount * foodPrices.Meat;
                        break;
                    case "fruit":
                        totalCost += dailyFoodAmount * foodPrices.Fruit;
                        break;
                    case "both":
                        totalCost += dailyFoodAmount * (info.MeatPercentage / 100m) * foodPrices.Meat;
                        totalCost += dailyFoodAmount * ((100m - info.MeatPercentage) / 100m) * foodPrices.Fruit;
                        break;
                }
            }

            return totalCost;
        }
    }
}
