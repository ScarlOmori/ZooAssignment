using ZooApi.Models;

namespace ZooApi.Services
{
    /// <summary>
    /// Contains functionality for reading all the necessary information from files to calculate the cost of animal feed.
    /// </summary>
    public class DataReader : IDataReader
    {
        /// <summary>
        /// Reads food price from file by path.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Food prices model.</returns>
        public FoodPrices ReadFoodPrices(string path)
        {
            var lines = File.ReadAllLines(path);
            var prices = new FoodPrices();

            foreach (var line in lines)
            {
                var parts = line.Split('=');

                if (parts[0] == "Meat")
                    prices.Meat = decimal.Parse(parts[1]);
                if (parts[0] == "Fruit")
                    prices.Fruit = decimal.Parse(parts[1]);
            }

            return prices;
        }

        /// <summary>
        /// Reads animal information from file by path.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Collection of AnimalInformation by its type.</returns>
        public Dictionary<string, GeneralAnimalInfo> ReadAnimalInfo(string path)
        {
            var lines = File.ReadAllLines(path);
            var animalInfo = new Dictionary<string, GeneralAnimalInfo>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                var info = new GeneralAnimalInfo
                {
                    Type = parts[0],
                    Coefficient = Convert.ToDecimal(parts[1]),
                    FoodType = parts[2],
                    MeatPercentage = (parts.Length > 3 && !string.IsNullOrEmpty(parts[3])) ? int.Parse(parts[3].TrimEnd('%')) : 0
                };

                animalInfo.Add(info.Type, info);
            }

            return animalInfo;
        }

        /// <summary>
        /// Reads what animals are in the zoo from file by path.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Collection of AnimalInformation by its type.</returns>
        public List<AnimalInZoo> ReadZooAnimals(string path)
        {
            var lines = File.ReadAllLines(path).Skip(1);
            var zoo = new List<AnimalInZoo>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                var animal = new AnimalInZoo
                {
                    Type = parts[0],
                    Name = parts[1],
                    Weight = decimal.Parse(parts[2])
                };
                zoo.Add(animal);
            }

            return zoo;
        }
    }
}
