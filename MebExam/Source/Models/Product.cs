using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MebExam.Source.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProducingCompany { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
