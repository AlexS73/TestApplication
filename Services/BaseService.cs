using System;
using System.Collections.Generic;
using System.Linq;
using PatientTestApplication.Models;

namespace PatientTestApplication.Services
{
    public class BaseService: IBaseService
    {
        private IPatientService _patientService;

        public BaseService(IPatientService patientService)
        {
            _patientService = patientService;
        }
        
        public PatientResult CalculatePatient(PatientModel patientModel)
        {
            Patient patient = new Patient()
            {
                Birthday = patientModel.Birthday,
                DepartamentId = patientModel.DepartamentId,
                Diagnoses = patientModel.Diagnoses.Where(_=>_.isActive).Select(_=>_.Name).ToArray(),
                ID = patientModel.Id,
                Name = patientModel.Name,
                Procedures = patientModel.Procedures.Where(_=>_.isActive).Select(_=>_.Name).ToArray(),
                Sex = MatchSex(patientModel.Sex)
            };

            return _patientService.CalculatePatient(patient);
        }

        private Sex MatchSex(string sex)
        {
            switch (sex)
            {
                case "Man":
                    return Sex.Man;
                case "Woman":
                    return Sex.Woman;
                default:
                    return Sex.Undefined;   
            }
        }

        public IEnumerable<Departament> GetDepartaments() =>
            _patientService.GetDepartaments();
    }
}