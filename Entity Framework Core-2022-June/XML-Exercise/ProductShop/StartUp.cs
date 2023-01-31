using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static StringBuilder sb;
        public static void Main(string[] args)
        {
            ProductShopContext shopContext = new ProductShopContext();
            //string xml = File.ReadAllText("../../../Datasets/categories-products.xml");

            string xml = GetUsersWithProducts(shopContext);
            Console.WriteLine(xml);
            //shopContext.Database.EnsureDeleted();
            //shopContext.Database.EnsureCreated();
            //
            //Console.WriteLine($"Database created!");
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);
            UserDto[] userDtos = (UserDto[])xmlSerializer.Deserialize(stringReader);

            User[] users = userDtos
                .Select(u => new User()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);
            ProductDto[] productDtos = (ProductDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Product> products = new List<Product>();
            foreach (var productDto in productDtos)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }

                Product product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);
            CategoryDto[] categoryDtos = (CategoryDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Category> categories = new List<Category>();
            foreach (var categoryDto in categoryDtos)
            {
                if (!IsValid(categoryDto) || categoryDto.Name == null)
                {
                    continue;
                }

                Category category = new Category()
                {
                    Name = categoryDto.Name
                };

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductsDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);
            CategoryProductsDto[] categoryProductsDtos = (CategoryProductsDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();
            foreach (var categoryProductsDto in categoryProductsDtos)
            {
                if (!IsValid(categoryProductsDto))
                {
                    continue;
                }

                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryProductsDto.CategoryId,
                    ProductId = categoryProductsDto.ProductId,
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            sb = new StringBuilder();

            ICollection<ProductInRange> productDtos = new List<ProductInRange>();
            foreach (var productR in context.Products.Include(p => p.Buyer).Where(p => p.Price >= 500 && p.Price <= 1000))
            {
                ProductInRange product;
                if (productR.BuyerId == null)
                {
                    product = new ProductInRange()
                    {
                        Name = productR.Name,
                        Price = productR.Price
                    };
                }
                else
                {
                    product = new ProductInRange()
                    {
                        Name = productR.Name,
                        Price = productR.Price,
                        Buyer = $"{productR.Buyer.FirstName} {productR.Buyer.LastName}"
                    };
                }

                productDtos.Add(product);
            }

            ProductInRange[] products = productDtos
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductInRange[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, products, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            sb = new StringBuilder();

            UserForSoldProducts[] users = context
                .Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserForSoldProducts()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ProductSold()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserForSoldProducts[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, users, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        { 
            sb = new StringBuilder();

            CategoryByCount[] categories = context
                .Categories
                .Select(c => new CategoryByCount()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AvgPrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryByCount[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, categories, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            sb = new StringBuilder();

            UserFullInfo[] users = context
                .Users
                .ToArray()
                .Where(u => u.ProductsSold.Count >= 1)
                .Select(u => new UserFullInfo()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProducts()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                        .Select(ps => new ProductSpecificInfo()
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .OrderByDescending(ps => ps.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            AllUsers allUsers = new AllUsers()
            {
                Count = users.Length,
                Users = users.ToArray().Take(10).ToArray()
            };

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AllUsers), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, allUsers, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}