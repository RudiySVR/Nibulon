using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nibulon.WebApp.Models
{
    public class Grain
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; }
        public int BranchId { get; set; }
        public int CropYear { get; set; }
        public int CounterpartyId { get; set; }
        public string CounterpartyName { get; set; }
        public int ContactId { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public string Process { get; set; }
        public decimal Wetness { get; set; }
        public decimal Garbage { get; set; }
        public string Infection { get; set; }
    }
}
