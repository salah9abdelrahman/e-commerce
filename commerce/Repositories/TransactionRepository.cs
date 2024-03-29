﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using commerce.Core.IRepositories;
using commerce.Core.Models;

namespace commerce.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => dbContext as ApplicationDbContext;

        public IEnumerable<Transaction> GetTransactionsWithOrder()
        {
            return ApplicationDbContext.Transactions.Include(t => t.Order).ToList();
        }
        //db.Transactions.Include(t => t.Order);
    }
}