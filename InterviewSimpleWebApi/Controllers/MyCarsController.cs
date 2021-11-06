using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyCarsController : ControllerBase
    {
        private readonly ILogger<MyCarsController> _logger;

        public MyCarsController(ILogger<MyCarsController> logger)
        {
            _logger = logger;
        }
        // Se nao tiver experience em EF use ICarRepository & 


    }
}
