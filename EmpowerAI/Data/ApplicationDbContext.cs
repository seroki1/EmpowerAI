using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmpowerAI.Data
{
    public class EmpowerAIDbContext : IdentityDbContext
    {
        public EmpowerAIDbContext(DbContextOptions<EmpowerAIDbContext> options)
            : base(options)
        {
        }
    }
}
