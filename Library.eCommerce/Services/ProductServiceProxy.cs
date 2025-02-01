using Spring2025_Samples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.eCommerce.Services
{
    public class ProductServiceProxy // visible outside
    {
        private ProductServiceProxy()
        {
            Products = new List<Product?>();
        }

        private int LastKey
        {
            get 
            {
                if (Products.Any())
                {
                    return 0;
                }
                else
                {
                    return Products.Select(p => p?.Id ?? -1).Max(); // returns the (maximum) Id value from the Products collection
                }
            }
        }

        private static ProductServiceProxy instance; // holds the single instance of the ProductServiceProxy class
    private static object instanceLock = new object();

        public static ProductServiceProxy Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductServiceProxy();
                }
                return instance;
            }
        }

        private List<Product> list = new List<Product>();

        public List<Product> Products {get; private set;} // or public List<Product> Products => List; // lambda expression
        
        public void Add(Product product)
        {
            if(product.Id == 0)
            {
                product.Id = LastKey + 1;
            }
            list.Add(product);
        }
    }
}