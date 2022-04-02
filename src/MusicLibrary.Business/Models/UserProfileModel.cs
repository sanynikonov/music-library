namespace MusicLibrary.Business.Models;

public class UserProfileModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string ProfilePicturePath { get; set; }
}