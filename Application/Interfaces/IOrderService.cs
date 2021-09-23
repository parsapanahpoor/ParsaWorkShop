using Domain.Models.Order;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {

        #region Order

        bool IsExistOrderFromUserFromToday(int userid);
        Orders GetOrderForShopCart(int userid);
        int AddOrderToTheShopCart(int userid);
        Orders GetOrderByOrderID(int orderid);
        Orders UpdateOrderByLocationid(Orders orders, int locationid);
        Locations GetUserLocationByOrderId(int orderid);
        void IsfinallyForOredr(Orders orders);
        List<Orders> GetAllOrdersForShowInAdminPanel();
        Locations GetUserLocationByOrderID(int orderid);
        bool IsExistLocationInOrder(int Locationid);
        List<Orders> GetOrdersByUsersId(int userid);

        #endregion
    }
}
