using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nibulon.WebApp.Models
{
    public class Grain
    {
        public int Id { get; set; }
        [DisplayName("Дата обліку")]
        [DataType(DataType.Date)]
        public DateTime RecordDate { get; set; }
        [DisplayName("Підрозділ Код")]
        public int BranchId { get; set; }
        [DisplayName("Рік врожаю")]
        public int CropYear { get; set; }
        [DisplayName("Контрагент")]
        public int CounterpartyId { get; set; }
        [DisplayName("Контрагент")]
        public string CounterpartyName { get; set; }
        [DisplayName("Унікальний номер договору")]
        public int ContactId { get; set; }
        [DisplayName("ТМЦ Код")]
        public string Product { get; set; }
        [DisplayName("Ціна")]
        public decimal Price { get; set; }
        [DisplayName("Кількість нетто")]
        public decimal Amount { get; set; }
        [DisplayName("Напрямок")]
        public string Process { get; set; }
        [DisplayName("вологість")]
        public decimal Wetness { get; set; }
        [DisplayName("сміття")]
        public decimal Garbage { get; set; }
        [DisplayName("зараженість")]
        public string Infection { get; set; }
    }
}
