using Microsoft.AspNetCore.Identity;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Repositories.Contracts;

public interface IUserRepository : IBaseRepository<User>
{
    Task<IdentityResult> AddUser(RegisterRequetDto request);
}
