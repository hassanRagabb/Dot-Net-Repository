using System;
using System.Linq;
using EfLect11LazyLoading.Data;
using Microsoft.EntityFrameworkCore;  // For Include and EF features
using EfLect11LazyLoading.Data;      // Namespace where your DbContext is
using EfLect11LazyLoading.Models;    // Namespace where your models (Product, Category) are
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net.NetworkInformation;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        #region lazy loading

        //using var context = new NorthwindContext();
        //var productCategory = (from p in context.Products
        //                   where p.UnitsInStock == 0
        //                     select p).ToList();


        //foreach (var item in productCategory)
        //{
        //  // Console.WriteLine($"Product: {item.ProductName}, Category: {item.Category?.CategoryName??"NA"}");
        //    if(item.Category == null) //without proxy 
        //    {

        //        context.Entry(item).Reference(p => p.Category).Load();//one category
        //        //context.Entry(item).Collection(p => p.Category).Load();//MANY CATEGORIES
        //        Console.WriteLine($"Product: {item.ProductName}, Category: {item.Category?.CategoryName ?? "NA"}");
        //    }
        //    Console.WriteLine($"Product: {item.ProductName}, Category: {item.Category.CategoryName}");
        //}


        ///*
        //   var prdCategory = (from p in context.Products
        //                      where p.UnitsInStock>0
        //                     //select p.ProductName
        //                     select new { p.ProductName , p.Category.CategoryName})
        //                     .ToList();

        //   foreach (var item in prdCategory)
        //   {
        //       Console.WriteLine($"Product: {item.ProductName}, Category: {item.CategoryName}");
        //   }


        //   var productsWithCategories = context.Products
        //       //.Include(p => p.Category)//just Category
        //       .Include(p =>new { p.Category ,p.Supplier}) //same like .Include(p => p.Category).Include(s => s.Supplier)
        //       .Select(p => new
        //       {
        //           ProductName = p.ProductName,
        //           CategoryName = p.Category.CategoryName
        //       })
        //       .ToList();

        //   foreach (var item in productsWithCategories)
        //   {
        //       Console.WriteLine($"Product: {item.ProductName}, Category: {item.CategoryName}");
        //   }
        //*/
        #endregion

        /// Using Raw SQL(for non - query commands) non select like update delete insert 
        /// context.Database.ExecuteSqlRaw("DELETE FROM Products WHERE UnitsInStock = 0");





    }
}