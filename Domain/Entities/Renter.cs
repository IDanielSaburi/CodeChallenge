using System;

namespace Domain.Entities
{
    public class Renter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; } // Unique
        public DateTime BirthDate { get; set; }
        public string CNHNumber { get; set; } // Unique
        public string CNHType { get; set; }
        public string CNHImagePath { get; set; }
    }
}
