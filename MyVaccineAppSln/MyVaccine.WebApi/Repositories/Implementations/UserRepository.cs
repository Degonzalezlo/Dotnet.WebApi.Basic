using Azure;
using Microsoft.AspNetCore.Identity;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using System.Transactions;

namespace MyVaccine.WebApi.Repositories.Implementations;

public class UserRepository : BaseRepository<User>,IUserRepository
{
    private readonly MyVaccineAppDbContext _Context;
    private readonly UserManager<IdentityUser> _UserManager;

    public UserRepository(MyVaccineAppDbContext context, UserManager<IdentityUser> userManager): base(context)
    {
        _Context = context;
        _UserManager = userManager;
    }

    public async Task<IdentityResult> AddUser(RegisterRequetDto request)
    {
        var response = new IdentityResult();
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var user = new ApplicationUser
            {
                UserName = request.Email.ToLower(),
                Email = request.Email


            };
            var result = await _UserManager.CreateAsync(user, request.Password);
            response = result;
            if (!result.Succeeded)
            {
                
                return response;
            }
            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AspNetUserId = user.Id,
            };
            await _Context.Users.AddAsync(newUser);
            await _Context.SaveChangesAsync(); 
            scope.Complete();
        }

        return response;
    }
}
