using InterviewSimpleWebApi.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewSimpleWebApi.Repository
{
    public interface ICarRepository
    {
        /// <summary>
        /// Find all existent Cars in db
        /// </summary>
        /// <returns></returns>
        public List<Car> FindAll();

        /// <summary>
        /// Find a Car for the given id if any
        /// If no Car found throws a NotFoundException 
        /// </summary>
        /// <returns></returns>
        public Car Get(long id);

        /// <summary>
        /// Find a Car for the given licensePlate if any
        /// If no Car found throws a NotFoundException 
        /// </summary>
        /// <returns></returns>
        public Car Get(string licensePlate);

        /// <summary>
        /// Method to Add a new Car into db from the given newCar
        /// If the license plate is already present in another Car throws a LicensePlateAlreadyInUseException 
        /// </summary>
        /// <returns></returns>
        public Car Add(Car newCar);

        /// <summary>
        /// Saves changes to the database
        /// </summary>
        /// <returns></returns>
        public void UpdateCar(Car _);
    }
}
