using Story.Application.Abstract;
using Story.Data.Dto.Story;
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
    public class StoryService : IStoryService
    {
        private readonly IGenericRepository<Domain.Entities.Story> _storyRepository;
        private readonly IGenericMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StoryService(IGenericRepository<Domain.Entities.Story> storyRepository, IGenericMapper mapper, IUnitOfWork unitOfWork)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddStory(CreateStoryDto createStoryDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var story = _mapper.Map<CreateStoryDto, Domain.Entities.Story>(createStoryDto);
                await _storyRepository.AddAsync(story);
                return new SuccessResult(story,"Hikaye eklendi.");
            });
        }

        public async Task<Result> DeleteStory(short id) 
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                try
            {
                var story = await _storyRepository.GetByIdAsync(id); 
                if (story == null)
                    return new ErrorResult("Hikaye bulunamadı.");
                _storyRepository.Delete(story);
                return new SuccessResult(story,"Hikaye silindi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Hikaye silinirken hata oluştu: {ex.Message}");
            }

            });
        }

        public async Task<Result> GetById(short id) 
        {
            try
            {
                var story = await _storyRepository.GetByIdAsync(id); 
                if (story == null)
                    return new ErrorResult("Hikaye bulunamadı.");
                return new SuccessResult(data: _mapper.Map<Domain.Entities.Story, StoryDto>(story));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Hikaye getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> GetStories()
        {
            try
            {
                var stories = await _storyRepository.GetAllAsync();
                return new SuccessResult(data: _mapper.MapList<Domain.Entities.Story, StoryDto>(stories));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Hikayeler getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> UpdateStory(UpdateStoryDto updateStoryDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var story = await _storyRepository.GetByIdAsync(updateStoryDto.Id);
                if (story == null)
                    return new ErrorResult("Hikaye bulunamadı.");
                _mapper.Map(updateStoryDto, story);
                _storyRepository.Update(story);
                return new SuccessResult(story, "Hikaye güncellendi.");
            });
        }
    }
}