using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DataContracts
{
    public class RecordDto 
    {
        public DateTime Date { get; set; }
        public string RegistrationNumber { get; set; }
        public double Speed { get; set; }
    }
}
