using AutoMapper;
using AuthSystem.WebApi.Data.Entities.Identity;
using AuthSystem.WebApi.Providers.JwtBearer;

namespace AuthSystem.WebApi.Models.Identity
{
    public class UserSessionModel : UserProfileModel
    {
        public string TokenType { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public DateTimeOffset AccessTokenExpiresAt { get; set; }
        public string RefreshToken { get; set; } = null!;
        public DateTimeOffset RefreshTokenExpiresAt { get; set; }
    }

    public class UserSessionModelProfile : Profile
    {
        public UserSessionModelProfile()
        {
            CreateMap<User, UserSessionModel>();
            CreateMap<UserProfileModel, UserSessionModel>();
            CreateMap<JwtTokenInfo, UserSessionModel>();
        }
    }
}
