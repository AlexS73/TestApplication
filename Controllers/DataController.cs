using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientTestApplication.Services;

namespace PatientTestApplication.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IBaseService _baseService;
        
        public DataController (IBaseService baseService)
        {
            _baseService = baseService;
        }
        [Route("api/Calculate")]
        [HttpPost]
        public PatientResult Calculate(PatientModel patient) =>
            _baseService.CalculatePatient(patient);
        
        [Route("api/GetDepartaments")]
        [HttpGet]
        public IEnumerable<Departament> GetDepartaments() =>
            _baseService.GetDepartaments();
    }
}
