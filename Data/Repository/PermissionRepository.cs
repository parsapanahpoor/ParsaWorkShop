using Data.Context;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
   public class PermissionRepository : IPermissionRepository
    {
        #region Ctor

        private ParsaWorkShopContext _context;

        public PermissionRepository(ParsaWorkShopContext context)
        {
            _context = context;
        }

        #endregion

    }
}
