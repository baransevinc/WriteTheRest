using Story.Application.Abstract;
using Story.Data.Dto.Rating;
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
    public class RatingService : IRatingService
    {
        private readonly IGenericRepository<Rating> _ratingRepository;
        private readonly IGenericMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RatingService(IGenericRepository<Rating> ratingRepository, IGenericMapper mapper, IUnitOfWork unitOfWork)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddRating(CreateRatingDto createRatingDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var rating = _mapper.Map<CreateRatingDto, Rating>(createRatingDto);
                await _ratingRepository.AddAsync(rating);
                return new SuccessResult(rating,"Puan eklendi.");
            });
        }

        public async Task<Result> DeleteRating(short id)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                try
            {
                var rating = await _ratingRepository.GetByIdAsync(id);
                if (rating == null)
                    return new ErrorResult("Puan bulunamadı.");
                _ratingRepository.Delete(rating);
                return new SuccessResult(rating,"Puan silindi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Puan silinirken hata oluştu: {ex.Message}");
            }

            });
        }

        public async Task<Result> GetById(short id)
        {
            try
            {
                var rating = await _ratingRepository.GetByIdAsync(id);
                if (rating == null)
                    return new ErrorResult("Puan bulunamadı.");
                return new SuccessResult(data: _mapper.Map<Rating, RatingDto>(rating));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Puan getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> GetRatings()
        {
            try
            {
                var ratings = await _ratingRepository.GetAllAsync();
                return new SuccessResult(data: _mapper.MapList<Rating, RatingDto>(ratings));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Puanlar getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> UpdateRating(UpdateRatingDto updateRatingDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var rating = await _ratingRepository.GetByIdAsync(updateRatingDto.Id);
                if (rating == null)
                    return new ErrorResult("Puan bulunamadı.");
                _mapper.Map(updateRatingDto,rating);
                _ratingRepository.Update(rating);
                return new SuccessResult(rating,"Puan güncellendi.");
            });
        }
    }
}