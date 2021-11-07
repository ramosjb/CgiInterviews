using System;
using InterviewSimpleWebApi.Data.Entity;
using InterviewSimpleWebApi.Model;
using InterviewSimpleWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using InterviewSimpleWebApi.Exceptions;

namespace InterviewSimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarRepository _repo;

        public CarController(ILogger<CarController> logger, ICarRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        #region (1) Criar PUT Method para lidar com carros
        // TODO 1
        #endregion

        #region (1) Soluçao Criar PUT Method para lidar com carros
        /// <summary>
        /// Method to Add a new car into the db
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="newCarArrived"></param>
        [HttpPut("/{licensePlate}")]
        public ActionResult<CarDto> Add(string licensePlate, CarDto newCarArrived)
        {
            _logger.LogInformation("CarController Add method was called with {@NewCarArrived}", newCarArrived);
            if (!licensePlate.ToUpper().Equals(newCarArrived.LicensePlate.ToUpper()))
            {
                return BadRequest("License Plate from path doesn't match license plate from body.");
            }
            
            try
            {
                Car car = _repo.Get(licensePlate);
                car.Brand = newCarArrived.Brand;
                car.Color = newCarArrived.Color;
                car.Kilometers = newCarArrived.Kilometers;
                car.LicensePlate = newCarArrived.LicensePlate;
                _repo.UpdateCar(car);
                return Ok(car.TransformEntityToDto());
            }
            catch (NotFoundException)
            {
                Car insertCar = _repo.Add(newCarArrived.ToEntity());
                return Created($"/{licensePlate}", insertCar.TransformEntityToDto());
            }
        }
        #endregion
        
        #region (2) Criar metodo para listar todos os carros
        // TODO 1
        #endregion

        #region (2) Solução método listar carros
        /// <summary>
        /// Method to retrieve the List of available cars 
        /// </summary>
        /// <returns></returns>
        [HttpGet("carList")]
        public ActionResult<IList<CarDto>> List()
        {
            _logger.LogInformation("CarController List method was called");
            return Ok(_repo.FindAll().TransformEntityListToDtoList());
        }
        #endregion
        
        #region (3) Criar metodo para listar todos os carros ordenados por ordem crescente de Kilómetros
        // TODO 1
        #endregion
        
        #region (3) Solução criar metodo para listar todos os carros ordenados por ordem crescente de Kilómetros
        /// <summary>
        /// Method to retrieve the List of available cars 
        /// </summary>
        /// <returns></returns>
        [HttpGet("carList/ordered")]
        public ActionResult<IList<CarDto>> OrderedList()
        {
            _logger.LogInformation("CarController List method was called");
            IList<CarDto> cars = _repo.FindAll().TransformEntityListToDtoList();
            for (int i = 0; i < cars.Count - 1; i++)
            {
                for (int j = i+1; j < cars.Count; j++)
                {
                    if (cars[i].Kilometers > cars[j].Kilometers)
                    {
                        (cars[j], cars[i]) = (cars[i], cars[j]);
                        // CarDto temp = cars[j];
                        // cars[j] = cars[i];
                        // cars[i] = temp;
                    }
                }
            }

            return Ok(cars);
        }
        #endregion
    }
}
