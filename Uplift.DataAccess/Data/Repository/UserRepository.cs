using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void LockUser(string userId)
        {
            var userFromDB = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            userFromDB.LockoutEnd = DateTime.Now.AddYears(100);
            _db.SaveChanges();
        }

        public void UnLockUser(string userId)
        {
            var userFromDB = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            userFromDB.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }

    }
}
