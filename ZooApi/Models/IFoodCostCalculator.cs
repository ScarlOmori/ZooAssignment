namespace ZooApi.Models
{
    /// <summary>
    /// Represents classes that can calculate animals food cost.
    /// </summary>
    public interface IFoodCostCalculator
    {
        /// <summary>
        /// Calculate daily cost of animal food.
        /// </summary>
        /// <param name="path">Path to the folder with files prices.txt, animal.csv, zoo.csv.</param>
        /// <returns>Cost of animal food.</returns> 
        decimal CalculateDailyCost(string path);
    }
}
