using System.Collections.Generic;
using PatientTestApplication.Models;

namespace PatientTestApplication.Services
{
    public interface IBaseService
    {
        PatientResult CalculatePatient(PatientModel patient);
        IEnumerable<Departament> GetDepartaments();
    }
}