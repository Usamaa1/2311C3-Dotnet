namespace Authentication.Models
{
    public class SignupDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> RoleNames { get; set; }
    }
}
