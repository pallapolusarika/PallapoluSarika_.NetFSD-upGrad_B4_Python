/*Problem Level-1 and 2:
1.Write a LINQ query to search and display all products with category “FMCG”.
2. Write a LINQ query to search and display all products with category “Grain”.
3. Write a LINQ query to sort products in ascending order by product code.
4. Write a LINQ query to sort products in ascending order by product Category.
5. Write a LINQ query to sort products in ascending order by product Mrp.
6. Write a LINQ query to sort products in descending order by product Mrp.
7. Write a LINQ query to display products group by product Category.
8. Write a LINQ query to display products group by product Mrp.
9. Write a LINQ query to display product detail with highest price in FMCG category.
10. Write a LINQ query to display count of total products.
11. Write a LINQ query to display count of total products with category FMCG.
12.Write a LINQ query to display Max price.
13.Write a LINQ query to display Min price.
14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem1
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
     //1.Write a LINQ query to search and display all products with category “FMCG”.
            var q1 = products.Where(p => p.ProCategory == "FMCG");
            foreach (var p in q1)
                Console.WriteLine(p.ProCategory + " " + p.ProMrp);
     //2.Write a LINQ query to search and display all products with category “Grain”.
            var q2 = products.Where(p => p.ProCategory == "Grain");
            foreach (var p in q2)
                Console.WriteLine(p.ProCategory + " " + p.ProMrp);
    //3.Write a LINQ query to sort products in ascending order by product code.
            var q3 = products.OrderBy(p => p.ProCategory);
     //4.Write a LINQ query to sort products in ascending order by product Category.
                        var q4 = products.OrderBy(p => p.ProCategory);
            var q5 = products.OrderBy(p => p.ProMrp);
            var q6 = products.OrderByDescending(p => p.ProMrp);

            foreach (var p in q6)
            {
                Console.WriteLine(p.ProName + " " + p.ProMrp);
            }
            var q7 = products.GroupBy(p => p.ProCategory);

            foreach (var group in q7)
            {
                Console.WriteLine("Category: " + group.Key);

                foreach (var p in group)
                {
                    Console.WriteLine(p.ProName);
                }
            }
            var q8 = products.GroupBy(p => p.ProMrp);
            var q9 = products
         .Where(p => p.ProCategory == "FMCG")
         .OrderByDescending(p => p.ProMrp)
         .FirstOrDefault();

                  Console.WriteLine(q9.ProName + " " + q9.ProMrp);
            var q10 = products.Count();
                  Console.WriteLine("Total Products: " + q10);
            var q11 = products.Count(p => p.ProCategory == "FMCG");
                  Console.WriteLine("FMCG Count: " + q11);
            var q12 = products.Max(p => p.ProMrp);
                  Console.WriteLine("Max Price: " + q12);
            var q13 = products.Min(p => p.ProMrp);
                 Console.WriteLine("Min Price: " + q13);
            var q14 = products.All(p => p.ProMrp < 30);
                 Console.WriteLine(q14);
            var q15 = products.Any(p => p.ProMrp < 30);
                 Console.WriteLine(q15);




            var result = products.Where(p => p.ProCategory == "FMCG").ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            Console.ReadLine();
        }
    }
}
