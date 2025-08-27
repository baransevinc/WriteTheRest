using Story.Application.Abstract;
using Story.Data.Dto.User;
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
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IGenericRepository<User> userRepository, IGenericMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddUser(CreateUserDto createUserDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var user = _mapper.Map<CreateUserDto, User>(createUserDto);
                user.PasswordHash=PasswordHelper.HashPassword(createUserDto.Password); 
                await _userRepository.AddAsync(user);
                return new SuccessResult(user,"Kullanıcı eklendi.");
            });
        }

        public async Task<Result> DeleteUser(short id) // Change parameter type from short to match repository method
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                    try
                {
                    var user = await _userRepository.GetByIdAsync(id); 
                    if (user == null)
                        return new ErrorResult("Kullanıcı bulunamadı.");
                    _userRepository.Delete(user);
                    return new SuccessResult(user,"Kullanıcı silindi.");
                }
                catch (Exception ex)
                {
                    return new ErrorResult($"Kullanıcı silinirken hata oluştu: {ex.Message}");
                }
            });
        }

        public async Task<Result> GetById(short id) 
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id); 
                if (user == null)
                    return new ErrorResult("Kullanıcı bulunamadı.");
                return new SuccessResult(data: _mapper.Map<User, UserDto>(user));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Kullanıcı getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return new SuccessResult(data: _mapper.MapList<User, UserDto>(users));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Kullanıcılar getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> UpdateUser(UpdateUserDto updateUserDto)
        {
            return await TransactionHelper.ExecuteInTransactionAsync(_unitOfWork, async () =>
            {
                var user = await _userRepository.GetByIdAsync(updateUserDto.Id);
                if (user == null)
                    return new ErrorResult("Kullanıcı bulunamadı.");
                user = _mapper.Map<UpdateUserDto, User>(updateUserDto);
                _userRepository.Update(user);
                return new SuccessResult(user, "Kullanıcı güncellendi.");
            });
        }
    }
}