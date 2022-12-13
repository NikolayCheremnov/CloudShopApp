using CloudShopApp.Model;
using CloudShopApp.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CloudShopApp.Service
{
    public class DbOrderService : IOrderService
    {
        // контекст БД встроить через DI
        private CloudShopDbContext context;

        public DbOrderService(CloudShopDbContext context)
        {
            this.context = context;
        }

        // добавление заказа
        public Order AddOrder(Order order)
        {
            context.Orders.Add(order);
            return order;
        }

        // получение всех заказов
        public List<Order> GetAllOrders()
        {
            return context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.FirstOrDefault(order => order.Id == id);
        }

        public void RemoveOrderById(int id)
        {
            Order removeable = GetOrderById(id);
            if (removeable != null)
            {
                context.Orders.Remove(removeable);
            }
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
        }
    }
}
