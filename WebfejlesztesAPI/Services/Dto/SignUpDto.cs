namespace WebfejlesztesAPI.Services.Dto
{
    public class SignUpDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
        public SignUpDto() { }
        public SignUpDto(string email, string password, string name, string phoneNumber, string address, string role, string gender)
        {
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Role = role;
            Gender = gender;
        }
    }
}
