using Domain.Models.Order;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        #region Order
        void UpdateOrder(Orders orders);
        bool IsExistOrderFromUserFromToday(int userid);
        Orders GetOrderForShopCart(int userid);
        void AddOrderToTheShopCart(Orders orders);
        Orders GetOrderByOrderID(int orderid);
        void UpdateOrderByLocationid(Orders orders);
        Locations GetUserLocationByOrderId(int orderid);
        List<Orders> GetAllOrdersForShowInAdminPanel();
        Locations GetUserLocationByOrderID(int orderid);
        bool IsExistLocationInOrder(int Locationid);
        List<Orders> GetOrdersByUsersId(int userid);
        #endregion


        #region OrderDetails

        bool IsExistOrderDetailFromUserFromToday(int orderid, int productid);
        void AddOneMoreProductToTheShopCart(int orderid, int productid);
        void UpdateOrderDetail(OrderDetails orderDetails);
        void AddProductToOrderDetail(int OrderID, int ProductID, decimal Price);
        void AddOrderDetails(OrderDetails orderDetails);
        List<OrderDetails> GetAllOrderDetailsByOrderID(int orderid);
        bool CheckForProductCount(int Orderid);
        void RemoveProductFromShopCart(int orderdetailid);
        void PlusProductToTheOrderDetails(int orderdetailid);
        void MinusProductToTheOrderDetails(int orderdetailid);
        OrderDetails GetOrderDetailByID(int orderdetailid);
        void SaveChanges();

        #endregion
    }
}
