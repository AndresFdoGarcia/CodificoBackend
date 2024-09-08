using Microsoft.EntityFrameworkCore;
using SalesDateProduction.Data.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.DataAccess.Context
{
    public class SDP_DBContext : DbContext
    {
        public SDP_DBContext(DbContextOptions<SDP_DBContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
        }

        // DbSets para tus entidades
       
        //public DbSet<OrderDetail> OrderDetails { get; set; }        
        public DbSet<EmployeeResponse> employeesR { get; set; }
        public DbSet<ProductResponse> productsR { get; set; }
        public DbSet<ShipperResponse> shippersR { get; set; }
        public DbSet<ClientOrderResponse> clientOrdersR { get; set; }
        public DbSet<SalesDatePredictionResult> salesDatePredictions { get; set; }
    }
}
