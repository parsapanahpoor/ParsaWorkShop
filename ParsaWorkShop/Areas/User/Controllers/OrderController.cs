using Application.Interfaces;
using Domain.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsaWorkShop.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class OrderController : Controller
    {
        #region Ctor
        private IUserService _userService;
        private ILocationService _location;
        private IOrderService _order;

        public OrderController(IUserService userService, ILocationService location, IOrderService order)
        {
            _userService = userService;
            _location = location;
            _order = order;
        }
        #endregion

        public IActionResult Index()
        {
            int userid = _userService.GetUserIdByUserName(User.Identity.Name);

            List<Orders> orders = _order.GetOrdersByUsersId(userid);
            return View(orders);
        }
        public IActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return View();
            }
            List<OrderDetails> orderDetails = _order.GetAllOrderDetailsByOrderID((int)id);

            return View(orderDetails);
        }
    }
}
