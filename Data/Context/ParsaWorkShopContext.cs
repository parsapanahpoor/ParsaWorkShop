using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ParsaWorkShopContext : DbContext
    {
        public ParsaWorkShopContext(DbContextOptions<ParsaWorkShopContext> options): base(options)
        {

        }


    }
}
