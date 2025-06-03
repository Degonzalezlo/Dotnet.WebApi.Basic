using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Models;
using System.Threading.Tasks;

namespace MyVaccine.WebApi.Services.Contracts;

public interface IUserService
{
    Task<AuthResponseDto> AddUserAsync(RegisterRequetDto request);
    Task<AuthResponseDto> Login(LoginRequestDto request);
    Task<AuthResponseDto> RefreshToken(string email);
    Task<User> GetUserInfo(string email);
}
