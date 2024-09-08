using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Data.ResponseModels
{
    public class ShipperResponse
    {
        [Key]
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
    }
}
