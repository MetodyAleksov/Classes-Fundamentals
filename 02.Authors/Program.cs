
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Authors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>(n);
            for (int i = 0; i < n; i++)
            {
                string[] newartivle = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Article article = new Article(newartivle[0], newartivle[1], newartivle[2]);
                articles.Add(article);
            }
            string itemToTake = Console.ReadLine();
            if (itemToTake == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (itemToTake == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (itemToTake == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }
            foreach (Article item in articles)
            {
                Console.WriteLine($"{item.Title} - {item.Content}: {item.Author}");
            }
        }
    }
    class Article
    {
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
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
