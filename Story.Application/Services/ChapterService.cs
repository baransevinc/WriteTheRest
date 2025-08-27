using Story.Application.Abstract;
using Story.Data.Dto.Chapter;
using Story.Domain.Entities;
using System;
using System.Threading.Tasks;
using WriteTheRest.Core.Attributes;
using WriteTheRest.Core.Helpers;
using WriteTheRest.Core.Mapping;
using WriteTheRest.Core.Repository.Abstract;
using WriteTheRest.Core.Result;

namespace Story.Application.Services
{
    [PreferredImplementation(isActive: true)]
    public class ChapterService : IChapterService
    {
        private readonly IGenericRepository<Chapter> _chapterRepository;
        private readonly IGenericMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChapterService(IGenericRepository<Chapter> chapterRepository, IGenericMapper mapper, IUnitOfWork unitOfWork)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddChapter(CreateChapterDto createChapterDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var chapter = _mapper.Map<CreateChapterDto, Chapter>(createChapterDto);
                await _chapterRepository.AddAsync(chapter);
                return new SuccessResult(chapter,"Bölüm eklendi.");
            });
        }

        public async Task<Result> DeleteChapter(short id) 
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                try
            {
                var chapter = await _chapterRepository.GetByIdAsync(id); 
                if (chapter == null)
                    return new ErrorResult("Bölüm bulunamadı.");
                _chapterRepository.Delete(chapter);
                return new SuccessResult(chapter,"Bölüm silindi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Bölüm silinirken hata oluştu: {ex.Message}");
            }

            });
        }

        public async Task<Result> GetById(short id)
        {
            try
            {
                var chapter = await _chapterRepository.GetByIdAsync(id); 
                if (chapter == null)
                    return new ErrorResult("Bölüm bulunamadı.");
                return new SuccessResult(data: _mapper.Map<Chapter, ChapterDto>(chapter));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Bölüm getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> GetChapters()
        {
            try
            {
                var chapters = await _chapterRepository.GetAllAsync();
                return new SuccessResult(data: _mapper.MapList<Chapter, ChapterDto>(chapters));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Bölümler getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> UpdateChapter(UpdateChapterDto updateChapterDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var chapter = await _chapterRepository.GetByIdAsync(updateChapterDto.Id);
                if (chapter == null)
                    return new ErrorResult("Bölüm bulunamadı.");
               _mapper.Map(updateChapterDto, chapter);
                _chapterRepository.Update(chapter);
                return new SuccessResult(chapter, "Bölüm güncellendi.");
            });
        }
    }
}