using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using PatientTestApplication.Helpers;
using PatientTestApplication.Models;

namespace PatientTestApplication.Services
{
    public class PatientService: IPatientService
    {
        public IEnumerable<Departament> GetDepartaments()
        {
            return Enumerable.Range(1, 10).Select(id => new Departament()
            {
                Id = id.ToString(),
                Name = $"Departament {id}"
            });
        }

        public PatientResult CalculatePatient(Patient patient)
        {
            var rnd = new Random();

            var mdc = rnd.Next(1, 10);
            var drg = $"{rnd.NextCharacter()}{rnd.Next(0, 10)}{rnd.Next(0, 10)}{rnd.Next(0, 10)}";

            return new PatientResult()
            {
                Diagnoses = patient.Diagnoses?.Select((i, idx) => new CodeResult()
                {
                    Description = $"Diagnose code description {i}",
                    Flags = Enumerable.Range(0, rnd.Next(1, 3)).Select(j => $"Flag {j}").ToArray(),
                }).ToArray(),
                Procedures = patient.Procedures?.Select((i, idx) => new CodeResult()
                {
                    Description = $"Procedure code description {i}",
                    Flags = Enumerable.Range(0, rnd.Next(1, 3)).Select(j => $"Flag {j}").ToArray(),
                }).ToArray(),
                Mdc = mdc.ToString(),
                MdcDescription = $"{mdc} Text Description",
                Drg = drg,
                DrgDescription = $"{drg} Text Description",
                Entgelt = Math.Round((decimal) (rnd.NextDouble() * 10000), 2)
            };
        }
    }
}