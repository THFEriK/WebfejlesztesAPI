namespace WebfejlesztesAPI.Services.Dto
{
    public class UserInfoDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public UserInfoDto() { }
        public UserInfoDto(long id, string email, string name, string phoneNumber, DateOnly birthDate, string address, string gender)
        {
            Id = id;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Address = address;
            Gender = gender;
        }
    }
}
