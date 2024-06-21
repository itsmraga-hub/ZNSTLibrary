namespace ZNSTLibrary.Authentication
{
    public class UserSession
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; } = false;
        public string Role { get; set; } = string.Empty;
    }
}