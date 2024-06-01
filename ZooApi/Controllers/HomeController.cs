using Microsoft.AspNetCore.Mvc;
using ZooApi.Models;
namespace ZooApi.Controllers
{
    /// <summary>
    /// Main controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IFoodCostCalculator _calculator;

        /// <summary>
        /// Get dependencies by DI.
        /// </summary>
        /// <param name="calculator"></param>
        public HomeController(IFoodCostCalculator calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        /// Calculate daily animal feed cost.
        /// </summary>
        /// <param name="path">Path to the folder with files prices.txt, animals.csv, zoo.csv.</param>
        /// <returns>If the files were found, it returns the cost, otherwise a 404 error with the text that exactly was not found.</returns>
        [HttpGet("DailyCost")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(404, Type = typeof(string))]
        public ActionResult<decimal> GetDailyCost(string path)
        {
            if (!Directory.Exists(path))
            {
                return NotFound("Folder with files is not found");
            }
            else if (!System.IO.File.Exists(Path.Combine(path, "prices.txt")))
            {
                return NotFound("prices.txt is not found");
            }
            else if (!System.IO.File.Exists(Path.Combine(path, "animals.csv")))
            {
                return NotFound("animals.csv is not found");
            }
            else if (!System.IO.File.Exists(Path.Combine(path, "zoo.csv")))
            {
                return NotFound("zoo.csv is not found");
            }

            return Ok(_calculator.CalculateDailyCost(path));
        }
    }

}
