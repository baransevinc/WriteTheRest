using System.Threading.Tasks;
using WriteTheRest.Core.Result;
using Story.Data.Dto.Story;

namespace Story.Application.Abstract
{
    public interface IStoryService
    {
        Task<Result> GetById(short id);
        Task<Result> GetStories();
        Task<Result> AddStory(CreateStoryDto createStoryDto);
        Task<Result> UpdateStory(UpdateStoryDto updateStoryDto);
        Task<Result> DeleteStory(short id);
    }
}