using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDateProduction.Data.DTO;
using SalesDateProduction.Data.ResponseModels;
using SalesDateProduction.DataAccess.Context;
using SalesDateProduction.DataAccess.OrderConfig.Contract;

namespace SalesDateProduction.DataAccess.OrderConfig.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly SDP_DBContext _context;

        public OrderService(SDP_DBContext Apcontext)
        {
            _context = Apcontext;
        }

        public async Task AddNewOrderAsync(OrderCreateDto orderDto)
        {
            var parameters = new[]
            {
            new SqlParameter("@Empid", orderDto.EmpId),
            new SqlParameter("@CustId",orderDto.CustId),
            new SqlParameter("@Shipperid", orderDto.ShipperId),
            new SqlParameter("@Shipname", orderDto.ShipName),
            new SqlParameter("@Shipaddress", orderDto.ShipAddress),
            new SqlParameter("@Shipcity", orderDto.ShipCity),
            new SqlParameter("@Orderdate", orderDto.OrderDate),
            new SqlParameter("@Requireddate", orderDto.RequiredDate),
            new SqlParameter("@Shippeddate", orderDto.ShippedDate ?? (object)DBNull.Value),
            new SqlParameter("@Freight", orderDto.Freight),
            new SqlParameter("@Shipcountry", orderDto.ShipCountry),
            new SqlParameter("@Productid", orderDto.ProductId),
            new SqlParameter("@Unitprice", orderDto.UnitPrice),
            new SqlParameter("@Qty", orderDto.Qty),
            new SqlParameter("@Discount", orderDto.Discount)
        };

            await _context.Database.ExecuteSqlRawAsync("EXEC Sales.AddNewOrder @Empid, @Shipperid, @Shipname, @Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry, @Productid, @Unitprice, @Qty, @Discount", parameters);
        }

        public async Task<List<ProductResponse>> GetProductsAsync()
        {
            return await _context.productsR.FromSqlRaw("EXEC Production.GetProducts").ToListAsync();
        }

        public async Task<List<ClientOrderResponse>> GetClientOrdersAsync(int customerId)
        {
            var parameter = new SqlParameter("@CustomerID", customerId);
            return await _context.clientOrdersR.FromSqlRaw("EXEC Sales.GetClientOrders @CustomerID", parameter).ToListAsync();
        }

        public async Task<List<EmployeeResponse>> GetEmployeesAsync()
        {
            var response = await _context.employeesR.FromSqlRaw("EXEC Sales.GetEmployees").ToListAsync();            
            return response;
        }

        public async Task<List<ShipperResponse>> GetShippersAsync()
        {
            return await _context.shippersR.FromSqlRaw("EXEC Sales.GetShippers").ToListAsync();
        }

        public async Task<List<SalesDatePredictionResult>> SalesDatePredictionAsync()
        {
            return await _context.Set<SalesDatePredictionResult>().FromSqlRaw("EXEC Sales.SalesDatePrediction").ToListAsync();
        }
    }    
}
