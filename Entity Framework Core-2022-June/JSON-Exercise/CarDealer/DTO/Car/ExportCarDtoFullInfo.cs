using CarDealer.DTO.Part;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Car
{
    [JsonObject]
    public class ExportCarDtoFullInfo
    {
        public ExportCarDtoSpecificInfo car { get; set; }

        public ExportPartForCarDtoSpecificInfo[] parts { get; set; }
    }
}
