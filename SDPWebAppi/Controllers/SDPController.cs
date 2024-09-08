using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesDateProduction.Business.Service;
using SalesDateProduction.Data.DTO;
using SalesDateProduction.DataAccess.OrderConfig.Contract;
using SalesDateProduction.DataAccess.OrderConfig.Implementation;

namespace SDPWebAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SDPController : ControllerBase
    {
        private readonly SalesDateProductionConfigurationBusiness _context;

        public SDPController(SalesDateProductionConfigurationBusiness context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> healthcheck()
        {
            return StatusCode(200, "Todo va bien");
        }

        [HttpGet("SalesDatePrediction")]
        public async Task<IActionResult> SalesDatePrediction()
        {
            var results = _context.SalesDatePrediction();
            return Ok(results);
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            var response = _context.GetEmployees();

            if (!response.Success)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("GetAllShippers")]
        public async Task<IActionResult> GetShippers()
        {
            var response = _context.GetShippers();

            if (!response.Success)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var response = _context.GetProducts();

            if (!response.Success)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("GetClientOrders/{customerId}")]
        public async Task<IActionResult> GetClientOrders(int customerId)
        {
            var results = _context.GetClientOrders(customerId);
            return Ok(results);
        }

        [HttpPost("CreateNewOrder")]
        public async Task<IActionResult> CreateNewOrder([FromBody]OrderCreateDto order)
        {
            var response = _context.CreateOrder(order);
            if (!response.Success)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }

    }
}
