using InterviewSimpleWebApi.Data.Entity;
using System.Collections.Generic;

namespace InterviewSimpleWebApi.Model
{
    public class CarDto
    {
        public string Brand { get; set; }

        public string Color { get; set; }

        public long Kilometers { get; set; }

        public string LicensePlate { get; set; }

        /// <summary>
        /// Method to transform this CarDto into a related EF Entity (Car)
        /// </summary>
        /// <returns></returns>
        public Car ToEntity()
        {
            return new Car
            {
                Brand = Brand,
                Color = Color,
                Kilometers = Kilometers,
                LicensePlate = LicensePlate
            };
        }

    }

    /// <summary>
    /// Helper class to do transformation between dto and Entity
    /// </summary>
    public static class CardDtoHelper
    {
        /// <summary>
        /// Method to transform a list given Car Entities to a list of CarDto's
        /// </summary>
        /// <param name="listOfCars"></param>
        /// <returns></returns>
        public static IList<CarDto> TransformEntityListToDtoList(this IList<Car> listOfCars)
        {
            IList<CarDto> dtoList = new List<CarDto>();
            foreach (Car c in listOfCars)
            {
                dtoList.Add(c.TransformEntityToDto());
            }
            return dtoList;
        }

        /// <summary>
        /// Method to transform a given Car Entity to a CarDto
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public static CarDto TransformEntityToDto(this Car car)
        {
            return new CarDto
            {
                Brand = car.Brand,
                Color = car.Color,
                Kilometers = car.Kilometers,
                LicensePlate = car.LicensePlate
            };
        }
    }
}
