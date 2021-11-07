using InterviewSimpleWebApi.Data.Entity;
using InterviewSimpleWebApi.Model;
using InterviewSimpleWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace InterviewSimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;

        #region Helper se não tiver experiência a trabalhar com EntityFramework
        private readonly ICarRepository _repo;
        #endregion

        #region Caso tenha conhecimento sobre EntityFramework
        //public CarsController(ILogger<CarsController> logger)
        //{
        //    _logger = logger;
        //}
        #endregion

        #region Caso não tenha experiência a trabalhar com EntityFramework
        public CarController(ILogger<CarController> logger, ICarRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        #endregion

        #region (1) Criar metodo para adicionar novo carro
        // TODO 1
        #endregion

        #region (1) Soluçao metodo para adicionar novo carro
        /// <summary>
        /// Method to Add a new car into the db
        /// </summary>
        /// <param name="newCarArrived"></param>
        [HttpPut("add")]
        public ActionResult Add(CarDto newCarArrived)
        {
            _logger.LogInformation("CarController Add method was called with {@newCarArrived}", newCarArrived);
            _repo.Add(newCarArrived.ToEntity());
            return Created("add", newCarArrived.LicensePlate);
        }
        #endregion


        #region (1) Criar metodo para colocar carro existente disponivel para ser alugado
        // TODO 1
        #endregion

        #region (2) Criar metodo para listar todos os carros
        // TODO 1
        #endregion

        #region (3) Criar metodo para listar todos os carros que podemos alugar
        // TODO 1
        #endregion

        #region (2) Solução método listar carros
        /// <summary>
        /// Method to retrieve the List of available cars 
        /// </summary>
        /// <returns></returns>
        [HttpGet("s-list")]
        public IList<CarDto> List()
        {
            _logger.LogInformation("CarController List method was called");
            return _repo.FindAll().TransformEntityListToDtoList();
        }
        #endregion

        #region (3) Solução para listar os carros que é possível alugar 
        /// <summary>
        /// Method to retrieve the List of available cars 
        /// </summary>
        /// <returns></returns>
        [HttpGet("s-list-all-available-for-renting")]
        public IList<CarDto> ListAllAvailableForRenting()
        {
            _logger.LogInformation("CarController ListAllAvailableForRenting method was called");
            return _repo.FindAllAvailableForRent().TransformEntityListToDtoList();
        }
        #endregion
    }
}
