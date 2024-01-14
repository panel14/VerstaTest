using AutoMapper;
using OrderTest.Domain.Models;
using OrderTest.Domain.UnitOfWork;
using OrderTest.ExceptionsUtils.CustomExceptions;
using OrderTest.Models;

namespace OrderTest.Services.Implementations
{
    public class OrderService(ApplicationDbContext _context, IMapper _mapper) : IOrderService
    {
        private readonly UnitOfWork _unitOfWork = new(_context);

        public IEnumerable<OrderModel> GetAllOrders()
        {
            var result = _unitOfWork.OrderRepository.Get().Select(_mapper.Map<OrderModel>);
            return result;
        }

        public OrderModel GetOrderById(int orderId)
        {
            OrderModel model = new();
            Order? result = _unitOfWork.OrderRepository.GetByID(orderId);
            return (result != null) 
                ? _mapper.Map<OrderModel>(result) 
                : throw new OrderNotFoundException(StatusCodes.Status404NotFound, $"Заказ с id {orderId} не был найден");
        }

        public bool PostOrder(OrderModel order)
        {
            Order posted = _mapper.Map<Order>(order);
            _unitOfWork.OrderRepository.Insert(posted);
            _unitOfWork.Save();
            return true;
        }
    }
}
