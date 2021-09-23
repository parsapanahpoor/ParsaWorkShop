using Data.Context;
using Domain.Interfaces;
using Domain.Models.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        private ParsaWorkShopContext _context;
        public FinancialTransactionRepository(ParsaWorkShopContext context)
        {
            _context = context;
        }

        public void AddFinancialTransactionAfterPaymentOrder(FinancialTransaction financial)
        {
            _context.FinancialTransactions.Add(financial);
            SaveChanges();
        }

        public List<FinancialTransaction> GetAllFinancialTransaction()
        {
            return _context.FinancialTransactions.Include(p => p.Order)
                                             .ThenInclude(p => p.User).ToList();                                
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
