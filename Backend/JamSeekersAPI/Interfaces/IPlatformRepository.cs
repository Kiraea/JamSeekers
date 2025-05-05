namespace JamSeekersAPI.Interfaces;

public interface IPlatformRepository
{
   public Task<bool> PlatformExists(int id); 
}