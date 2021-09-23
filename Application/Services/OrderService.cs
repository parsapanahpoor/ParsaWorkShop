using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models.Order;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _order;
        public OrderService(IOrderRepository order)
        {
            _order = order;
        }

        public int AddOrderToTheShopCart(int userid)
        {
            Orders order = new Orders()
            {
                Userid = userid,
                CreateDate = DateTime.Now,
                IsFinally = false,
                LocationID = null
            };
            _order.AddOrderToTheShopCart(order);

            return order.OrderId;
        }

        public List<Orders> GetAllOrdersForShowInAdminPanel()
        {
            return _order.GetAllOrdersForShowInAdminPanel();
        }

        public Orders GetOrderByOrderID(int orderid)
        {
            return _order.GetOrderByOrderID(orderid);
        }

        public Orders GetOrderForShopCart(int userid)
        {
            return _order.GetOrderForShopCart(userid);
        }

        public List<Orders> GetOrdersByUsersId(int userid)
        {
            return _order.GetOrdersByUsersId(userid);
        }

        public Locations GetUserLocationByOrderId(int orderid)
        {
            return _order.GetUserLocationByOrderId(orderid);
        }

        public Locations GetUserLocationByOrderID(int orderid)
        {
            return _order.GetUserLocationByOrderID(orderid);
        }

        public bool IsExistLocationInOrder(int Locationid)
        {
            if (_order.IsExistLocationInOrder(Locationid))
            {
                return true;
            }
            return false;
        }

        public bool IsExistOrderFromUserFromToday(int userid)
        {
            return _order.IsExistOrderFromUserFromToday(userid);
        }

        public void IsfinallyForOredr(Orders orders)
        {
            orders.IsFinally = true;

            _order.UpdateOrder(orders);
        }

        public Orders UpdateOrderByLocationid(Orders orders, int locationid)
        {
            orders.LocationID = locationid;
            _order.UpdateOrderByLocationid(orders);

            return orders;
        }
    }
}
