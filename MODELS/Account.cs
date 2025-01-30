namespace MODELS
{
    public class Account
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public HosterType Hoster = HosterType.Laposte;
    }
}
