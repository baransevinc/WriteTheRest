using System.Threading.Tasks;
using WriteTheRest.Core.Result;
using Story.Data.Dto.User;

namespace Story.Application.Abstract
{
    public interface IUserService
    {
        Task<Result> GetById(short id);
        Task<Result> GetUsers();
        Task<Result> AddUser(CreateUserDto createUserDto);
        Task<Result> UpdateUser(UpdateUserDto updateUserDto);
        Task<Result> DeleteUser(short id);
    }
}