using System;
using System.Collections.Generic;
using System.Linq;

class Good
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class Program
{
    static void Main()
    {
        List<Good> goods1 = new List<Good>()
        {
            new Good() { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            new Good() { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good() { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good() { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good() { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
            new Good() { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good() { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good() { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good() { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good() { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
        };

        var mobileGoodsAbove1000 = goods1.Where(g => g.Category == "Mobile" && g.Price > 1000)
                                         .Select(g => new { g.Title, g.Price })
                                         .ToList();
        Console.WriteLine("Mobile goods with price above 1000:");
        foreach (var good in mobileGoodsAbove1000)
        {
            Console.WriteLine($"Title: {good.Title}, Price: {good.Price}");
        }

        var nonKitchenGoodsAbove1000 = goods1.Where(g => g.Category != "Kitchen" && g.Price > 1000)
                                             .Select(g => new { g.Title, g.Price })
                                             .ToList();
        Console.WriteLine("\nNon-Kitchen goods with price above 1000:");
        foreach (var good in nonKitchenGoodsAbove1000)
        {
            Console.WriteLine($"Title: {good.Title}, Price: {good.Price}");
        }

        var averagePrice = goods1.Average(g => g.Price);
        Console.WriteLine($"\nAverage price of all goods: {averagePrice}");

        var uniqueCategories = goods1.Select(g => g.Category).Distinct().ToList();
        Console.WriteLine("\nUnique categories:");
        foreach (var category in uniqueCategories)
        {
            Console.WriteLine(category);
        }

        var goodsSortedByTitle = goods1.OrderBy(g => g.Title).Select(g => new { g.Title, g.Category }).ToList();
        Console.WriteLine("\nGoods sorted by title:");
        foreach (var good in goodsSortedByTitle)
        {
            Console.WriteLine($"Title: {good.Title}, Category: {good.Category}");
        }

        var totalGoodsCarAndMobile = goods1.Where(g => g.Category == "Car" || g.Category == "Mobile").Count();
        Console.WriteLine($"\nTotal number of Car and Mobile goods: {totalGoodsCarAndMobile}");

        var categoryCounts = goods1.GroupBy(g => g.Category)
                                   .Select(group => new { Category = group.Key, Count = group.Count() })
                                   .ToList();
        Console.WriteLine("\nCategory counts:");
        foreach (var group in categoryCounts)
        {
            Console.WriteLine($"Category: {group.Category}, Count: {group.Count}");
        }
    }
}
