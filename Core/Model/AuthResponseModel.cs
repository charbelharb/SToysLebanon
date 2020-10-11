namespace Core.Model
{
    public class AuthResponseModel
    {
        public string Email { get; set; }

        public string Token { get; set; }

        public int ExpiresIn { get; set; }
    }
}
