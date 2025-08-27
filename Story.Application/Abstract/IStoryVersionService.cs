using System.Threading.Tasks;
using WriteTheRest.Core.Result;
using Story.Data.Dto.StoryVersion;

namespace Story.Application.Abstract
{
    public interface IStoryVersionService
    {
        Task<Result> GetById(short id);
        Task<Result> GetStoryVersions();
        Task<Result> AddStoryVersion(CreateStoryVersionDto createStoryVersionDto);
        Task<Result> UpdateStoryVersion(UpdateStoryVersionDto updateStoryVersionDto);
        Task<Result> DeleteStoryVersion(short id);
    }
}