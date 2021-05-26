using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopPizzaHut.Models.EF;

namespace ShopPizzaHut.Models.Dao
{
    public class UserDao
    {
        PizzaHutShopDbContext db = null;
        public UserDao()
        {
            db = new PizzaHutShopDbContext();
        }
        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName);
            if (result == null)
                return 0;
            else
            {
                if (result.Status == null)
                    return -3;
                if (result.Status == false)
                    return -1;
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }

            }
        }
    }
}