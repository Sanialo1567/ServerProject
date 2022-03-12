﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class WebPortalRepository : Repository<WebPortalEntityModel>, IWebPortalRepository
    {
        public WebPortalRepository(AppDbContext context)
            : base(context)
        { }
    }
}
