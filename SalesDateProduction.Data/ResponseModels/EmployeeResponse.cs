using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Data.ResponseModels
{
    public class EmployeeResponse
    {
        [Key]
        public int EmpId { get; set; }
        public string FullName { get; set; }
    }
}
