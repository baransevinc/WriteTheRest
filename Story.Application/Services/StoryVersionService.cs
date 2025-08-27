using Microsoft.AspNetCore.Mvc;
using Story.Application.Abstract;
using Story.Data.Dto.Story;
using Story.Data.Dto.StoryVersion;
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
    public class StoryVersionService : IStoryVersionService
    {
        private readonly IGenericRepository<StoryVersion> _storyVersionRepository;
        private readonly IGenericMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StoryVersionService(IGenericRepository<StoryVersion> storyVersionRepository, IGenericMapper mapper, IUnitOfWork unitOfWork)
        {
            _storyVersionRepository = storyVersionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddStoryVersion([FromBody] CreateStoryVersionDto createStoryVersionDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var storyVersion = _mapper.Map<CreateStoryVersionDto, StoryVersion>(createStoryVersionDto);
                await _storyVersionRepository.AddAsync(storyVersion);
                return new SuccessResult(storyVersion,"Versiyon eklendi.");
            });
        }

        public async Task<Result> DeleteStoryVersion(short id)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                try
            {
                var storyVersion = await _storyVersionRepository.GetByIdAsync(id);
                if (storyVersion == null)
                    return new ErrorResult("Versiyon bulunamadı.");
                _storyVersionRepository.Delete(storyVersion);
                return new SuccessResult(storyVersion,"Versiyon silindi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Versiyon silinirken hata oluştu: {ex.Message}");
            }

            });
        }

        public async Task<Result> GetById(short id)
        {
            try
            {
                var storyVersion = await _storyVersionRepository.GetByIdAsync(id);
                if (storyVersion == null)
                    return new ErrorResult("Versiyon bulunamadı.");
                return new SuccessResult(data: _mapper.Map<StoryVersion, StoryVersionDto>(storyVersion));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Versiyon getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> GetStoryVersions()
        {
            try
            {
                var storyVersions = await _storyVersionRepository.GetAllAsync();
                return new SuccessResult(data: _mapper.MapList<StoryVersion, StoryVersionDto>(storyVersions));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Versiyonlar getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> UpdateStoryVersion(UpdateStoryVersionDto updateStoryVersionDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var storyVersion = await _storyVersionRepository.GetByIdAsync(updateStoryVersionDto.Id);
                if (storyVersion == null)
                    return new ErrorResult("Versiyon bulunamadı.");
                _mapper.Map(updateStoryVersionDto, storyVersion);
                _storyVersionRepository.Update(storyVersion);
                return new SuccessResult(storyVersion,"Versiyon güncellendi.");
            });
        }
    }
}