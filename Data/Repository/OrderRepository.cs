using Data.Context;
using Domain.Interfaces;
using Domain.Models.Order;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ParsaWorkShopContext _context;
        public OrderRepository(ParsaWorkShopContext context)
        {
            _context = context;
        }

        public void AddOneMoreProductToTheShopCart(int orderid, int productid)
        {
            throw new NotImplementedException();
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public void AddOrderToTheShopCart(Orders orders)
        {
            _context.Orders.Add(orders);
            SaveChanges();
        }

        public void AddProductToOrderDetail(int OrderID, int ProductID, decimal Price)
        {
            throw new NotImplementedException();
        }

        public bool CheckForProductCount(int Orderid)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> GetAllOrderDetailsByOrderID(int orderid)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetAllOrdersForShowInAdminPanel()
        {
            return _context.Orders.Where(p => p.IsFinally == true)
                            .Include(p => p.User).Include(p => p.OrderDetails).ToList();
        }

        public Orders GetOrderByOrderID(int orderid)
        {
            return _context.Orders.Find(orderid);
        }

        public OrderDetails GetOrderDetailByID(int orderdetailid)
        {
            throw new NotImplementedException();
        }

        public Orders GetOrderForShopCart(int userid)
        {
            return _context.Orders.SingleOrDefault(p => p.Userid == userid && p.CreateDate.Year == DateTime.Now.Year
                                   && p.CreateDate.Month == DateTime.Now.Month&& p.CreateDate.Day == DateTime.Now.Day                                                  
                                   && p.IsFinally == false);                                                  
        }

        public List<Orders> GetOrdersByUsersId(int userid)
        {
            return _context.Orders.Where(p => p.IsFinally == true && p.Userid == userid)
                                        .Include(p => p.OrderDetails).Include(p => p.Locations).ToList();
        }

        public Locations GetUserLocationByOrderId(int orderid)
        {
            return _context.Orders.Where(p => p.OrderId == orderid)
                                           .Include(p => p.Locations).Select(p => p.Locations).Single();
        }

        public Locations GetUserLocationByOrderID(int orderid)
        {
            return _context.Orders.Where(p => p.OrderId == orderid)
                                    .Include(p => p.Locations).Select(p => p.Locations).Single();
        }

        public bool IsExistLocationInOrder(int Locationid)
        {
            return _context.Orders.Any(p => p.LocationID == Locationid);
        }

        public bool IsExistOrderDetailFromUserFromToday(int orderid, int productid)
        {
            throw new NotImplementedException();
        }

        public bool IsExistOrderFromUserFromToday(int userid)
        {
            return _context.Orders.Any(p => p.Userid == userid && p.CreateDate.Year == DateTime.Now.Year
                                   && p.CreateDate.Month == DateTime.Now.Month&& p.CreateDate.Day == DateTime.Now.Day                                       
                                   && p.IsFinally == false);                                       
        }

        public void MinusProductToTheOrderDetails(int orderdetailid)
        {
            throw new NotImplementedException();
        }

        public void PlusProductToTheOrderDetails(int orderdetailid)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductFromShopCart(int orderdetailid)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateOrder(Orders orders)
        {
            _context.Orders.Update(orders);
            SaveChanges();
        }

        public void UpdateOrderByLocationid(Orders orders)
        {
            _context.Orders.Update(orders);
            SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
