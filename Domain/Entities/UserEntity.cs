﻿namespace Domain.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
