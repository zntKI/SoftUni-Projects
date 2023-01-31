namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static StringBuilder output;
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();

            string outMsg = GetBooksByCategory(db, input.ToLower());
            Console.WriteLine(outMsg);
            Console.WriteLine(outMsg.Length);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            output = new StringBuilder();

            AgeRestriction ageRestriction;
            bool hasParsed = Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);

            if (hasParsed)
            {
                string[] bookDescrp = context
                    .Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                foreach (var bookD in bookDescrp)
                {
                    output.AppendLine(bookD);
                }
            }

            return output.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            output = new StringBuilder();

            string[] booksTitles = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var title in booksTitles)
            {
                output.AppendLine(title);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            output = new StringBuilder();

            string[] titlesWithPrice = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToArray();

            foreach (var tp in titlesWithPrice)
            {
                output.AppendLine(tp);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            output = new StringBuilder();

            string[] titlesNotInYear = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var title in titlesNotInYear)
            {
                output.AppendLine(title);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            output = new StringBuilder();

            string[] arr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string[] titles = context
                .BooksCategories
                .Where(b => arr.Contains(b.Category.Name.ToLower()))
                .OrderBy(b => b.Book.Title)
                .Select(b => b.Book.Title)
                .ToArray();

            foreach (var title in titles)
            {
                output.AppendLine(title);
            }

            return output.ToString().TrimEnd();
        }//????

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        { 
            
        }
    }
}
