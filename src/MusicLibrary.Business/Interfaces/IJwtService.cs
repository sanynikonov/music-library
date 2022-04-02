namespace MusicLibrary.Business.Interfaces;

public interface IJwtService
{
    string CreateToken(string username);
}