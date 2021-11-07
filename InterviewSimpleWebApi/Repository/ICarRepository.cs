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
        /// Find all existent Cars for the given in db
        /// </summary>
        /// <returns></returns>
        public List<Car> FindAllBy(string brand);

        /// <summary>
        /// Find all existent Cars that are rentable in db
        /// </summary>
        /// <returns></returns>
        public List<Car> FindAllRentable();


        /// <summary>
        /// Find all existent Cars that are available to be rented in db
        /// </summary>
        /// <returns></returns>
        public List<Car> FindAllAvailableForRent();

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
        /// Update the given Car
        /// If no Car found in db for the given data throws a NotFoundException 
        /// </summary>
        /// <returns></returns>
        public void UpdateCar(Car car);
        /// <summary>
        /// Set the Car for the given carId as Rentable
        /// If no Car found in db for the given carId throws a NotFoundException 
        /// </summary>
        /// <returns></returns>

        public void NewRentableCar(long carId);

        /// <summary>
        /// Remove the RentableCar for the given id
        /// If no RentableCar found in db for the given id throws a NotFoundException
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void RemoveRentableCar(long id);


    }
}
