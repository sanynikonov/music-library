namespace MusicLibrary.Business;

public interface IJwtService
{
    string CreateToken(string username);
}