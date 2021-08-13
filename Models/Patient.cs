using System;

namespace PatientTestApplication.Models
{
    public class Patient
    {
        public string ID { get; set; }
        
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string DepartamentId { get; set; }
        public string[] Diagnoses { get; set; }
        public string[] Procedures { get; set; }
    }

    public class PatientResult
    {
     
        public CodeResult[] Diagnoses { get; set; }
        public CodeResult[] Procedures { get; set; }

        public string Mdc { get; set; }
        public string MdcDescription { get; set; }
        
        public string Drg { get; set; }
        public string DrgDescription { get; set; }
        
        public decimal Entgelt { get; set; }
    }


    public class CodeResult
    {
        public string Description { get; set; }
        public string[] Flags { get; set; }
    }
}