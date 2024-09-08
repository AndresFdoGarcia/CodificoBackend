using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Data.ResponseModels
{
    public class ClientOrderResponse
    {
        [Key]
        public int OrderId { get; set; }       
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
    }
}
