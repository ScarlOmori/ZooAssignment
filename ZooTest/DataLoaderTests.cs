using ZooApi.Models;
using ZooApi.Services;
using FluentAssertions;
using System.Collections.Generic;
using ZooTests;

namespace ZooTest
{
    public class DataLoaderTests
    {
        [Fact]
        public void Read_AnimalInfo_ReturnsRightInfo()
        {
            IDataReader loader = new DataReader();
            var expected = new Dictionary<string, GeneralAnimalInfo>
            {
                { "Lion", new GeneralAnimalInfo { Coefficient = 0.10m, FoodType = "meat", Type = "Lion", MeatPercentage = 0 } },
                { "Zebra", new GeneralAnimalInfo { Coefficient = 0.08m, FoodType = "fruit", Type = "Zebra", MeatPercentage = 0 } },
                { "Wolf", new GeneralAnimalInfo { Coefficient = 0.07m, FoodType = "both", Type = "Wolf", MeatPercentage = 90 } },
                { "Piranha", new GeneralAnimalInfo { Coefficient = 0.5m, FoodType = "both", Type = "Piranha", MeatPercentage = 50 } }
            };

            var result = loader.ReadAnimalInfo(Path.Combine(Constants.Path, "LoadAnimalInfo/animals.csv"));

            foreach (var entry in expected)
            {
                result.Should().ContainKey(entry.Key).WhoseValue.Should().BeEquivalentTo(entry.Value);
            }
        }

        [Fact]
        public void Read_FoodPrices_ReturnsRightInfo()
        {
            IDataReader loader = new DataReader();
            var expected = new FoodPrices()
            {
                Meat = 12.56m,
                Fruit = 5.60m
            };

            var result = loader.ReadFoodPrices(Path.Combine(Constants.Path, "LoadFoodPrices/prices.txt"));


            result.Should().BeOfType<FoodPrices>()
                .Which.Meat.Should().Be(expected.Meat);

            result.Should().BeOfType<FoodPrices>()
                .Which.Fruit.Should().Be(expected.Fruit);
        }

        [Fact]
        public void Read_LoadZoo_ReturnsRightInfo()
        {
            IDataReader loader = new DataReader();
            var expected = new List<AnimalInZoo>()
            {
                new AnimalInZoo {Name = "Leo", Type = "Lion", Weight = 160},
                new AnimalInZoo {Name = "Tommy", Type = "Zebra", Weight = 62},
                new AnimalInZoo {Name = "Lily", Type = "Piranha", Weight = 0.5m}
            };

            var result = loader.ReadZooAnimals(Path.Combine(Constants.Path, "LoadZoo/zoo.csv"));

            result.Should().BeEquivalentTo(expected);
        }
    }
}