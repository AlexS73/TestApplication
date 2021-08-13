using PatientTestApplication.Models;
using System.Collections.Generic;

namespace PatientTestApplication.Services
{
    public interface IPatientService
    {
        PatientResult CalculatePatient(Patient patient);
        IEnumerable<Departament> GetDepartaments();
    }
}