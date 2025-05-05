using JamSeekersAPI.Dtos.AppUser.User;
using JamSeekersAPI.Interfaces;
using JamSeekersAPI.Mappers;
using JamSeekersAPI.Models;
using JamSeekersAPI.Repositories;

namespace JamSeekersAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IPlatformRepository _platformRepositiory;


    public UserService(IUserRepository userRepository, ITagRepository tagRepository, IGenreRepository genreRepository, IPlatformRepository platformRepository)
    {
        _userRepository = userRepository;
        _tagRepository = tagRepository;
        _genreRepository = genreRepository;
        _platformRepositiory = platformRepository;
    }
    public async Task<ResultWrapper<List<AppUserDto>>> GetAppUsersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ResultWrapper<AppUserDto>> GetAppUserByIdAsync(string id)
    {
        var appUser = await _userRepository.GetById(id);
        if (appUser == null)
        {
            return ResultWrapper<AppUserDto>.Fail(new List<string>{"cannot find specified user"});
        }

        var appUserDto = appUser.FromAppUserToAppUserDto();
        return ResultWrapper<AppUserDto>.Success(new List<AppUserDto>
        {
            appUserDto,
        });
    }

    public async Task<ResultWrapper<AppUser>> UpdateAppUserAsync(string id, UpdateUserAppDto updateUserAppDto)
    {
        var appUser = await _userRepository.GetById(id);
        if (appUser == null)
        {
            return ResultWrapper<AppUser>.Fail(["user not Found"]);
        }
        if (updateUserAppDto.DisplayName != null)
        {
            appUser.DisplayName = updateUserAppDto.DisplayName;
        }

        if (updateUserAppDto.BioDescription != null)
        {
            appUser.BioDescription = updateUserAppDto.BioDescription;
        }

        if (updateUserAppDto.CityId != null)
        {
           appUser.CityId = updateUserAppDto.CityId; 
        }

        if (updateUserAppDto.TagsToAdd != null)
        {
            var tags = await _tagRepository.GetTagsByIdsAsync(updateUserAppDto.TagsToAdd);
            // each of the tags check if its a part of the user, if its not then put it in var
                                                                    // this is stechnically LINQ
                                                                    // appUser.Tags actually accesses the middle table
                                                                    // thats why u have to do TagId
            var tagsNotPartOfUser =  tags.Where(t => !appUser.UserTags.Any(ut => ut.TagId == t.Id));
            
            foreach (var tag in tagsNotPartOfUser)
            {
                
                
                
                //LINQ  autokmatically infers it thats why no need for ID
                appUser.UserTags.Add(new UserTag{ TagId = tag.Id });
            }
            
        }

        if (updateUserAppDto.TagsToRemove != null)
        {
            var tags= await _tagRepository.GetTagsByIdsAsync(updateUserAppDto.TagsToRemove);
            
           /*
            * pEF Core, many-to-many relationships require you to manipulate the join entity (UserTag), not the related entity (Tag). The original code tried to remove Tag objects, which aren't part of the appUser.Tags collection.
            */
            var tagsToRemove = appUser.UserTags.Where(ut=> tags.Any(t => ut.TagId == t.Id)).ToList();
            foreach (var tag in tagsToRemove)
            { 
                appUser.UserTags.Remove(tag);
            }
        }

        if (updateUserAppDto.GenresToAdd != null)
        {
            var genres = await _tagRepository.GetTagsByIdsAsync(updateUserAppDto.GenresToAdd);
            var validGenres = genres.Where((g) => !appUser.UserGenres.Any(ug => ug.GenreId == g.Id));

            foreach (var validGenre in validGenres)
            {
                appUser.UserGenres.Add(new UserGenre
                {
                    GenreId = validGenre.Id,
                    UserId = appUser.Id
                });
            }
        }

        if (updateUserAppDto.GenresToRemove != null)
        {
            var genres = (await _genreRepository.GetGenresById(updateUserAppDto.GenresToRemove)).ToList();
            // no need for await if already list already called and put through wmemoryu
            //as long as appUser.UserGenres and genres are already in memory (like from a previous database query).
            var genresPartOfUser =
                appUser.UserGenres.Where(ug => genres.Any(g => ug.GenreId == g.Id)).ToList();
            foreach (var genre in genresPartOfUser)
            {
                appUser.UserGenres.Remove(new UserGenre
                {
                    GenreId = genre.GenreId,
                    UserId = appUser.Id,
                });
            }
        }

        if (updateUserAppDto.SocialLinksToRemove != null && updateUserAppDto.SocialLinks.Count > 0)
        {
           var linksToRemove = appUser.SocialLinks.Where(s => updateUserAppDto.SocialLinksToRemove!.Contains(s.Id)).ToList();

           foreach (var link in linksToRemove)
           {
               appUser.SocialLinks.Remove(link);
           }
        }

        if (updateUserAppDto.SocialLinks != null && updateUserAppDto.SocialLinks.Count > 0)
        {
            foreach (var socialLink in updateUserAppDto.SocialLinks)
            {
                if (socialLink.Id == null)
                {
                    var platformExists = await _platformRepositiory.PlatformExists(socialLink.PlatformId);
                    if (!platformExists)
                    {
                       throw new InvalidOperationException("Platform doesnt exist "); 
                    }

                    var newSociaLink = new SocialLink
                    {
                        PlatformId = socialLink.PlatformId,
                        Url = socialLink.Url,
                    };
                    appUser.SocialLinks.Add(newSociaLink);
                }
                else if (socialLink.Id != null)
                {
                    var existingLink = appUser.SocialLinks.FirstOrDefault(s => s.Id == socialLink.Id);
                    if (existingLink is null) continue;

                    existingLink.Url = socialLink.Url;
                    existingLink.PlatformId = socialLink.PlatformId;
                }
            }
        }

        return ResultWrapper<AppUser>.Success([
            appUser
        ]); 
    }
    
}