namespace BeiDream.Demo.Web.Model
{
    public class LoginViewModel
    {

        public string UserNameOrEmail { get; set; }

        public string Password { get; set; }
        public string ValidateCode { get; set; }
        public bool RememberMe { get; set; } 
    }
}