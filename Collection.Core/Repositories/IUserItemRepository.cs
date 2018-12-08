using Collection.Entity.Enums;
using Collection.Entity.Item;
using Collection.Entity.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Core.Repositories
{
    public interface IUserItemRepository : IRepository<UserItem>
    {
        IEnumerable<UserItem> GetItems(StateEnum itemState);
        IEnumerable<UserItem> GetUserItems(int userId, StateEnum itemState);
    }
}
