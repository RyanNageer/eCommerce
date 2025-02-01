using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.eCommerce.Services
{
    public class ProductServiceProxy // visible outside
    {
        public ProductServiceProxy()
        {

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

        public List<Product> Products // or public List<Product> Products => List; // lambda expression
        {
            get
            {
                return list;
            }
        }
    }
}