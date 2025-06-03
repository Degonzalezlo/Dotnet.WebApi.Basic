using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Dependent;

namespace MyVaccine.WebApi.Services.Contracts;

public interface IDependentService
{
    Task<IEnumerable<DependentResponseDto>> GetAll();
    Task <DependentResponseDto> GetById(int id);
    Task<IEnumerable<DependentResponseDto>> GetDependentsByUserId(int userId);

    Task<DependentResponseDto> Add(DependentRequestDto request);
    Task<DependentResponseDto> Update(DependentRequestDto request, int id);
    Task<DependentResponseDto> Delete(int id);
}
