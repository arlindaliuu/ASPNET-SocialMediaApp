namespace SocialMediaApp.Configuration
{
    public interface IAuthentication
    {
        string Authenticate(string email);
    }
}
