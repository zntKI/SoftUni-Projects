using CarDealer.DTO.Car;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Sale
{
    [JsonObject]
    public class ExportSaleFullInfoDto
    {
        public ExportCarDtoSpecificInfo car { get; set; }

        public string customerName { get; set; }

        public decimal Discount { get; set; }

        public decimal price { get; set; }

        public decimal priceWithDiscount { get; set; }
    }
}
