﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Order
{
    public class FinancialTransaction
    {

        [Key]
        public int FinancialTransactionID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        public int Price { get; set; }

        [MaxLength(250)]
        public string BankReceipt { get; set; }

        [MaxLength(250)]
        public string BankTransferNumber { get; set; }

        public DateTime CreateDate { get; set; }

        #region Navigations

        public Order.Orders Order { get; set; }

        #endregion
    }

}
