using SalesDateProduction.Data.DTO;
using SalesDateProduction.Data.ResponseModels;
using SalesDateProduction.DataAccess.OrderConfig.Contract;
using SalesDateProduction.DataAccess.OrderConfig.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Business.Service
{
    public class SalesDateProductionConfigurationBusiness
    {
        private readonly IOrderService _orderService;

        public SalesDateProductionConfigurationBusiness(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Response<List<ProductResponse>> GetProducts()
        {
            try
            {
                var products = _orderService.GetProductsAsync().Result;
                return new Response<List<ProductResponse>> { Success = true, Data = products };
            }
            catch (Exception ex)
            {
                return new Response<List<ProductResponse>> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public Response<List<ClientOrderResponse>> GetClientOrders(int customerId)
        {
            try
            {
                var orders = _orderService.GetClientOrdersAsync(customerId).Result;
                return new Response<List<ClientOrderResponse>> { Success = true, Data = orders };
            }
            catch (Exception ex)
            {
                return new Response<List<ClientOrderResponse>> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public Response<List<EmployeeResponse>> GetEmployees()
        {
            try
            {
                var employees = _orderService.GetEmployeesAsync().Result;
                return new Response<List<EmployeeResponse>>
                {
                    Success = true,
                    Data = employees
                };
            }
            catch (Exception ex)
            {
                return new Response<List<EmployeeResponse>> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public Response<List<ShipperResponse>> GetShippers()
        {
            try
            {
                var shippers = _orderService.GetShippersAsync().Result;
                return new Response<List<ShipperResponse>> { Success = true, Data = shippers };
            }
            catch (Exception ex)
            {
                return new Response<List<ShipperResponse>> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public Response<List<SalesDatePredictionResult>> SalesDatePrediction()
        {
            try
            {
                var predictionResults = _orderService.SalesDatePredictionAsync().Result;
                return new Response<List<SalesDatePredictionResult>> { Success = true, Data = predictionResults };
            }
            catch (Exception ex)
            {
                return new Response<List<SalesDatePredictionResult>> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public Response<OrderCreateDto> CreateOrder( OrderCreateDto order)
        {
            try
            {
                _orderService.AddNewOrderAsync(order);
                return new Response<OrderCreateDto> { Success = true, Data = order };            
            }
            catch (Exception ex)
            {
                return new Response<OrderCreateDto> { Success = false, ErrorMessage = ex.Message };
            }
        }

    }

    public class Response<T>
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }
    }
}
