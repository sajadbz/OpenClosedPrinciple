using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenClosedPrinciple.AbstractSample;
using OpenClosedPrinciple.InterfaceSample;

namespace OpenClosedPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            // AbstractSample
            //var user1 = new GoldUser(1, "Sajad", 15000);
            //var user2 = new SilverUser(2, "Mona", 15000);
            //Console.WriteLine(user1.ToString());
            //Console.WriteLine(user2.ToString());

            // InterfaceSample
            var apple = new Product("Apple", Color.Green, Size.Small,5000);
            var tree = new Product("Tree", Color.Green, Size.Big,24000);
            var house = new Product("House", Color.Blue, Size.Big,150000);

            Product[] products = {apple, tree, house};

            var pf = new ProductFilter();
            foreach (var p in pf.FilterByColor(products,Color.Green))
            {
                Console.WriteLine($"{p.Name} is green");
            }
            foreach (var p in pf.FilterBySize(products, Size.Small))
            {
                Console.WriteLine($"{p.Name} is small");
            }
            foreach (var p in pf.FilterByColorAndSize(products,Color.Blue, Size.Big))
            {
                Console.WriteLine($"{p.Name} is blue and big");
            }

            Console.WriteLine("-----------------------------");

            var bf = new BetterFilter();
            foreach (var p in bf.Filter(products,new ColorSpecification(Color.Green)))
                Console.WriteLine($"{p.Name} is green");

            foreach (var p in bf.Filter(products, new SizeSpecification(Size.Small)))
                Console.WriteLine($"{p.Name} is small");

            foreach (var p in bf.Filter(products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Blue),
                    new SizeSpecification(Size.Big)
                    )))
            {
                Console.WriteLine($"{p.Name} is blue and big");
            }
            foreach (var p in bf.Filter(products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Green),
                    new PriceSpecification(1000,10000)
                )))
            {
                Console.WriteLine($"{p.Name} is green and price");
            }
        }
    }
}
