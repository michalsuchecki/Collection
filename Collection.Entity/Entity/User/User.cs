using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Entity.Entity.User
{
    public class User : EntityBase
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int UserRoleId { get; set; }
        public bool IsActive { get; set; }
        public string Activation { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
