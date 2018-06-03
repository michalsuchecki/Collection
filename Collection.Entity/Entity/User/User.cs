namespace Collection.Entity.Entity.User
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}