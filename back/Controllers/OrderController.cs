using Microsoft.AspNetCore.Mvc;
using OrderTest.Models;
using OrderTest.Services;

namespace OrderTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController(IOrderService _orderService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            if (ModelState.IsValid)
            {
                var orders = _orderService.GetAllOrders();
                return Ok(orders);
            }
            return BadRequest("Incorrect form.");
        }

        [HttpGet]
        public IActionResult GetOrderById(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            if (order != null)
            {
                return Ok(order);
            }
            return BadRequest($"Заказ с id {orderId} не найден.");
        }

        [HttpPost]
        public IActionResult PostOrder(OrderModel model)
        {
            if (_orderService.PostOrder(model))
            {
                return Ok(true);
            }
            return BadRequest("Ошибка при создании заказа");
        }
    }
}
