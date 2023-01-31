using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article article = new Article(input[0], input[1], input[2]);
                articles.Add(article);
            }
            string sortCriteria = Console.ReadLine();
            if (sortCriteria == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (sortCriteria == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (sortCriteria == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }
            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
