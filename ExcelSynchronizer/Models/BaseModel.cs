using System;
using System.Collections.Generic;

namespace ExcelHelper.Models
{
    public enum ComissionType
    {
        Client,
        Partner,
        PaySystem
    }

    public class Comission
    {
        public ComissionType Type { get; set; }
        public decimal Amount { get; set; }
    }

    public class BaseModel
    {
        public string TransId { get; set; }
        public string PSTransId { get; set; }
        public DateTime PayedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Comission> Comissions { get; set; }
        public string PaySystem { get; set; }
        public string Account { get; set; }
        public bool Successed { get; set; }
        public decimal Amount { get; set; }
        public decimal FullAmount { get; set; }
    }
}
