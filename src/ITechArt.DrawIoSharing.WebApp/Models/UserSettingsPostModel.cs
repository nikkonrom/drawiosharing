namespace ITechArt.DrawIoSharing.WebApp.Models
{
    public class UserSettingsPostModel
    {
        public int UserId { get; set; }

        public bool IsApprovedStatusChanged { get; set; }

        public bool IsRightsStatusChanged { get; set; }

        public bool IsBanStatusChanged { get; set; }
    }
}