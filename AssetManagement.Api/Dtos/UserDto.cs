namespace AssetManagement.Api.Dtos
{
    public class UserDto
    {
        public string UserId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DisplayName { get; set;} = null!;
        public string Token { get; set; } = null!;
    }
}
