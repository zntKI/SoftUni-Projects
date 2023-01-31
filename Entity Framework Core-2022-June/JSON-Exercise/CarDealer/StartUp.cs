using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Car;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Part;
using CarDealer.DTO.Sale;
using CarDealer.DTO.Supplier;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string filePath;
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));
            CarDealerContext dbContext = new CarDealerContext();
            InitializeDatasetFilePath("sales-discounts.json");
            //string inputJson = File.ReadAllText(filePath);

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine($"Database created successfully!");
            string json = GetSalesWithAppliedDiscount(dbContext);
            File.WriteAllText(filePath, json);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSupplierDto[] supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            ICollection<Supplier> suppliers = new List<Supplier>();
            foreach (ImportSupplierDto supplierDto in supplierDtos)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ImportPartDto[] partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            List<int> ids = new List<int>();
            foreach (Supplier supplier in context.Suppliers)
            {
                ids.Add(supplier.Id);
            }

            ICollection<Part> parts = new List<Part>();
            foreach (ImportPartDto partDto in partDtos)
            {
                if (!ids.Contains(partDto.SupplierId))
                {
                    continue;
                }

                Part part = Mapper.Map<Part>(partDto);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            ICollection<Car> cars = new List<Car>();
            foreach (ImportCarDto carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                ICollection<PartCar> currCarParts = new List<PartCar>();
                foreach (int partId in carDto.Parts.Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    currCarParts.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }

                car.PartCars = currCarParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ImportCustomerDto[] customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            ICollection<Customer> customers = new List<Customer>();
            foreach (var cDto in customerDtos)
            {
                Customer customer = Mapper.Map<Customer>(cDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ImportSaleDto[] saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            ICollection<Sale> sales = new List<Sale>();
            foreach (var sDto in saleDtos)
            {
                Sale sale = Mapper.Map<Sale>(sDto);
                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ThenBy(c => c.Name)
                .Select(c => new 
                { 
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarDtoFullInfo[] cars = context
                .Cars
                .Select(c => new ExportCarDtoFullInfo()
                {
                    car = new ExportCarDtoSpecificInfo()
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c
                        .PartCars
                        .Select(pc => new
                        {
                            Part = pc.Part
                        })
                        .Select(p => new ExportPartForCarDtoSpecificInfo()
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .ToArray()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Select(s => s.Car)
                                        .SelectMany(car => car.PartCars)
                                        .Select(pc => pc.Part.Price)
                                        .Sum()
                    //.Select(car => car.PartCars)
                    //.SelectMany(pc => pc.C)
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleFullInfoDto[] sales = context
                .Sales
                .Select(s => new ExportSaleFullInfoDto()
                {
                    car = new ExportCarDtoSpecificInfo()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount + (s.Customer.IsYoungDriver ? 5 : 0),
                    price = s.Car.PartCars
                             .Select(pc => pc.Part.Price)
                             .Sum(),
                    priceWithDiscount = decimal.Parse(((s.Car.PartCars
                             .Select(pc => pc.Part.Price)
                             .Sum()) * ((100 - s.Discount) / 100)).ToString("f2"))
                })
                .Take(10)
                .ToArray();

            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        public static void InitializeDatasetFilePath(string fileName)
        { 
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Exports/", $"{fileName}");
        }
    }
}