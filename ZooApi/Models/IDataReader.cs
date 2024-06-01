namespace ZooApi.Models
{
    /// <summary>
    /// Represents classes that can read all the necessary information for animals food cost calculations.
    /// </summary>
    public interface IDataReader
    {
        /// <summary>
        /// Reads food price from file by path.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Food prices model.</returns>
        FoodPrices ReadFoodPrices(string path);

        /// <summary>
        /// Reads animal information from file by path.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Collection of AnimalInformation by its type.</returns>
        Dictionary<string, GeneralAnimalInfo> ReadAnimalInfo(string path);

        /// <summary>
        /// Reads what animals are in the zoo from file by path.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Collection of AnimalInformation by its type.</returns>
        List<AnimalInZoo> ReadZooAnimals(string path);
    }
}
