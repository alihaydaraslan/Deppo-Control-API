namespace DeppoControlBackend.Entities.Model
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
