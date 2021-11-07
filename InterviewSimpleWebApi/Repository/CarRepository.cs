using InterviewSimpleWebApi.Data;
using InterviewSimpleWebApi.Data.Entity;
using InterviewSimpleWebApi.Exceptions;
using Microsoft.EntityFrameworkCore;
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

        public Car Get(long id)
        {
            Car car = _carDbContext.Cars.SingleOrDefault(c => c.Id.Equals(id));
            if (car == default)
                throw new NotFoundException($"No car found in database for the given id {id}");

            return car;
        }

        public Car Get(string licensePlate)
        {
            Car car = _carDbContext.Cars.SingleOrDefault(c => c.LicensePlate.Equals(licensePlate));
            if (car == default)
                throw new NotFoundException($"No car found in database for the given licensePlate {licensePlate}");

            return car;
        }

        public void UpdateCar(Car _)
        {
            _carDbContext.SaveChanges();
        }

        public Car Add(Car newCar)
        {
            _carDbContext.Cars.Add(newCar);
            _carDbContext.SaveChanges();
            return newCar;
        }
    }
}
