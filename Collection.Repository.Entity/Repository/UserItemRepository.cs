using Collection.Core.Repositories;
using Collection.Entity.Enums;
using Collection.Entity.User;
using Collection.Repository.Entity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collection.Repository.Entity.Repository
{
    public class UserItemRepository : Repository<UserItem>, IUserItemRepository
    {
        public UserItemRepository(EntityDBContext context) : base(context)
        {

        }

        public IEnumerable<UserItem> GetItems(StateEnum itemState)
        {
            return List(true).Where(x => x.StateId == itemState).ToList();
        }

        public IEnumerable<UserItem> GetUserItems(int userId, StateEnum itemState)
        {
            return List(true).Where(x => x.UserId == userId && x.StateId == itemState).ToList();
        }
    }
}
