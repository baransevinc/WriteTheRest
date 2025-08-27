using System.Threading.Tasks;
using WriteTheRest.Core.Result;
using Story.Data.Dto.Chapter;

namespace Story.Application.Abstract
{
    public interface IChapterService
    {
        Task<Result> GetById(short id);
        Task<Result> GetChapters();
        Task<Result> AddChapter(CreateChapterDto createChapterDto);
        Task<Result> UpdateChapter(UpdateChapterDto updateChapterDto);
        Task<Result> DeleteChapter(short id);
    }
}