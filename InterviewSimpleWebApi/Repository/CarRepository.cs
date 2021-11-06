using InterviewSimpleWebApi.Data;
using InterviewSimpleWebApi.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSimpleWebApi.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalContext _carDbContext;

        public CarRepository(CarRentalContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public List<Car> FindAll()
        {
            return _carDbContext.Cars.ToList();
        }

        public List<Car> FindAllBy(string brand)
        {
            return _carDbContext.Cars.Where(c => c.Brand.ToUpper().Equals(brand.ToUpper())).ToList();
        }

        public List<Car> FindAllRentable(string brand)
        {
            return _carDbContext.Cars.Where(c => c.Brand.ToUpper().Equals(brand.ToUpper())).ToList();
        }

        public Car Get(long id)
        {
            Car car = _carDbContext.Cars.SingleOrDefault(c => c.Id.Equals(id));
            if (car == default)
                throw new DllNotFoundException($"No car found in database for the given id {id}");

            return car;
        }

        public Car Get(string licensePlate)
        {
            Car car = _carDbContext.Cars.SingleOrDefault(c => c.LicensePlate.Equals(licensePlate));
            if (car == default)
                throw new DllNotFoundException($"No car found in database for the given licensePlate {licensePlate}");

            return car;
        }

        public void NewRentableCar(long carId)
        {
            Car carToSetAsRentable = Get(carId);
            RentableCar newRentableCar = new RentableCar()
            {
                Car = carToSetAsRentable,
                CarId = carId
            };
            _carDbContext.RentableCars.Add(newRentableCar);
            _carDbContext.SaveChanges();
        }

        public void RemoveRentableCar(long id)
        {
            RentableCar r = _carDbContext.RentableCars.SingleOrDefault(r => r.Id.Equals(id));
            if (r == default)
                throw new DllNotFoundException($"No RentableCar found in database for the given id {id}");
            _carDbContext.RentableCars.Remove(r);
            _carDbContext.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            Car carToSetAsRentable = Get(car.Id);
            carToSetAsRentable.Brand = car.Brand;
            carToSetAsRentable.Color = car.Color;
            carToSetAsRentable.Kilometers = car.Kilometers;
            carToSetAsRentable.LicensePlate = car.LicensePlate;
            _carDbContext.SaveChanges();
        }
    }
}
