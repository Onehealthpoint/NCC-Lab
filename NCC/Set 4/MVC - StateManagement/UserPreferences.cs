namespace set4_StateManagement.Models
{
    public class UserPreferences
    {
        public string Theme { get; set; } = "light";
        public int ItemsPerPage { get; set; } = 10;
        public bool NotificationsEnabled { get; set; } = true;
        public string Language { get; set; } = "English";
    }
}
