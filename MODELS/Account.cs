namespace MODELS
{
    public class Account
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Hoster
        {
            get
            {
                var index = Login.LastIndexOf('@');
                if (index == -1)
                    throw new Exception("Missing '@' in the login.");
                return Login.Substring(index);
            }
        }
    }
}
