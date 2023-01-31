using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Part
{
    [JsonObject]
    public class ExportPartForCarDtoSpecificInfo
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
