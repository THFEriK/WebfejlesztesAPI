namespace WebfejlesztesAPI.Services.Dto
{
    public class SignInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public SignInDto() { }
        public SignInDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
