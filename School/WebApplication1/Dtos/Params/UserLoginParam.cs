namespace StoreManagement.Dtos.Params
{
    public class UserLoginParam
    {
        public UserLoginParam()
        {

        }

        public UserLoginParam(string userName, string passWrod, bool rememberMe)
        {
            UserName = userName;
            Password = passWrod;
            RemeberMe = rememberMe;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
