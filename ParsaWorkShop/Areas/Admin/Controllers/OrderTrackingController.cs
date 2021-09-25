using Application.Interfaces;
using Application.Security;
using Application.ViewModels;
using Domain.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsaWorkShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderTrackingController : Controller
    {
        private IOrderService _order;
        private IUserService _userservice;
        private IFinancialTransactionService _financial;
        public OrderTrackingController(IOrderService order, IUserService userService, IFinancialTransactionService financial)
        {
            _order = order;
            _userservice = userService;
            _financial = financial;
        }

        [PermissionChecker(1)]
        public IActionResult Index()
        {
            List<Orders> Orders = _order.GetAllOrdersForShowInAdminPanel();

            return View(Orders);
        }

        [PermissionChecker(1)]
        public IActionResult CheckUserInformation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Orders order = _order.GetOrderByOrderID((int)id);
            EditUserViewModel user = _userservice.GetUserForShowInEditMode((int)order.Userid);
            ViewBag.Location = _order.GetUserLocationByOrderID((int)id);

            return View(user);
        }

        [PermissionChecker(1)]
        public IActionResult CheckOrderDetails(int? id)
        {
            if (id == null)
            {
                return View();
            }

            List<OrderDetails> orderDetails = _order.GetAllOrderDetailsByOrderID((int)id);

            return View(orderDetails);
        }

        [PermissionChecker(1)]
        public IActionResult AccountingList()
        {
            List<FinancialTransaction> financials = _financial.GetAllFinancialTransaction();

            return View(financials);
        }
    }
}
