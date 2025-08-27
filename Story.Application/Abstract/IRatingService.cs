using System.Threading.Tasks;
using WriteTheRest.Core.Result;
using Story.Data.Dto.Rating;

namespace Story.Application.Abstract
{
    public interface IRatingService
    {
        Task<Result> GetById(short id);
        Task<Result> GetRatings();
        Task<Result> AddRating(CreateRatingDto createRatingDto);
        Task<Result> UpdateRating(UpdateRatingDto updateRatingDto);
        Task<Result> DeleteRating(short id);
    }
}