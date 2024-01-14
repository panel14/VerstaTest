using OrderTest.Domain.Models;
using OrderTest.Models;

namespace OrderTest.Services
{
    public interface IOrderService
    {
        public IEnumerable<OrderModel> GetAllOrders();
        public OrderModel GetOrderById(int orderId);
        public bool PostOrder(OrderModel order);
    }
}
