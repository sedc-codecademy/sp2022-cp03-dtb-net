namespace ProductivityApp.Dtos.UserDtos
{
    public  class RegisterUserDto
    {
       
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
