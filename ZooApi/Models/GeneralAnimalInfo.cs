namespace ZooApi.Models
{
    /// <summary>
    /// Contains information about animal food consumption.
    /// </summary>
    public class GeneralAnimalInfo
    {
        /// <summary>
        /// Type of animal.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Percentage of food from animal weight.
        /// </summary>
        public decimal Coefficient { get; set; }

        /// <summary>
        /// Type of food that animal eats.
        /// </summary>
        public string FoodType { get; set; }

        /// <summary>
        /// Percentage of meat in animal food (only for both type eaters).
        /// </summary>
        public int MeatPercentage { get; set; }
    }
}
