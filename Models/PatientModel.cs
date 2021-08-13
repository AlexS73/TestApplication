using System;

namespace PatientTestApplication.Models
{
    public class PatientModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string DepartamentId { get; set; }
        public DPModel[] Diagnoses { get; set; }
        public DPModel[] Procedures { get; set; }
    }

    public class DPModel
    {
        public bool isActive { get; set; }
        public string Name { get; set; }
        public string[] Flags { get; set; }
        public string Description { get; set; }
    }
}