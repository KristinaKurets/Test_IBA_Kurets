using System;

namespace Data.Model
{
    public class Record : BaseEntity
    {
        public DateTime Date { get; set; }
        public string RegistrationNumber { get; set; }
        public double Speed { get; set; }
    }
}
