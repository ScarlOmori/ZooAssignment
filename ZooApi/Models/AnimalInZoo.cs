namespace ZooApi.Models
{
    /// <summary>
    /// Represents animals that have in the zoo.
    /// </summary>
    public class AnimalInZoo
    {
        /// <summary>
        /// Type of animal (Lion for example).
        /// </summary>
        public string Type { get; set; }

        public string Name { get; set; }
        public decimal Weight { get; set; }
    }
}
