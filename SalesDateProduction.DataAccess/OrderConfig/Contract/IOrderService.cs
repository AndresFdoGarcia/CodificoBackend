using SalesDateProduction.Data.DTO;
using SalesDateProduction.Data.ResponseModels;
using SalesDateProduction.DataAccess.OrderConfig.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.DataAccess.OrderConfig.Contract
{
    public interface IOrderService
    {
        Task AddNewOrderAsync(OrderCreateDto orderDto);
        Task<List<ProductResponse>> GetProductsAsync();
        Task<List<ClientOrderResponse>> GetClientOrdersAsync(int customerId);
        Task<List<EmployeeResponse>> GetEmployeesAsync();
        Task<List<ShipperResponse>> GetShippersAsync();
        Task<List<SalesDatePredictionResult>> SalesDatePredictionAsync();
    }
}
