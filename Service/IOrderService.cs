using CloudShopApp.Model.Entity;

namespace CloudShopApp.Service
{
    // интерфейс сервиса
    public interface IOrderService
    {
        // CRUD-интерфейс для заказа
        List<Order> GetAllOrders(); 
        Order GetOrderById(int id);
        Order AddOrder(Order order);
        void RemoveOrderById(int id);
        void UpdateOrder(Order order);
    }
}
