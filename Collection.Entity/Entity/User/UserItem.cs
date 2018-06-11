using Collection.Entity.Enums;
using System;

namespace Collection.Entity.Entity.User
{
    public class UserItem : EntityBase
    {
        public int UserItemId { get; set; }
        public int UserId { get; set; }
        public decimal PriceBuy { get; set; }
        public decimal PriceSell { get; set; }
        public bool ForSale { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? SellDate { get; set; }
        public StateEnum StateId { get; set; }
        public ConditionEnum ConditionId { get; set; }
    }
}
