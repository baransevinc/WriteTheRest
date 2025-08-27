using AutoMapper;
using Story.Domain.Entities;
using Story.Data.Dto.Story;
using Story.Data.Dto.StoryVersion;
using Story.Data.Dto.Chapter;
using Story.Data.Dto.Rating;
using Story.Data.Dto.User;

namespace Story.Application.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Story
            CreateMap<Domain.Entities.Story, StoryDto>().ReverseMap();
            CreateMap<Domain.Entities.Story, CreateStoryDto>().ReverseMap();
            CreateMap<Domain.Entities.Story, UpdateStoryDto>().ReverseMap();

            // StoryVersion
            CreateMap<StoryVersion, StoryVersionDto>().ReverseMap();
            CreateMap<StoryVersion, CreateStoryVersionDto>().ReverseMap();
            CreateMap<StoryVersion, UpdateStoryVersionDto>().ReverseMap();

            // Chapter
            CreateMap<Chapter, ChapterDto>().ReverseMap();
            CreateMap<Chapter, CreateChapterDto>().ReverseMap();
            CreateMap<Chapter, UpdateChapterDto>().ReverseMap();

            // Rating
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Rating, CreateRatingDto>().ReverseMap();
            CreateMap<Rating, UpdateRatingDto>().ReverseMap();

            // User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}