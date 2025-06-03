using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Services.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace MyVaccine.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DependentsController : ControllerBase
{
    private readonly IDependentService _dependentService;
    private readonly IValidator<DependentRequestDto> _validator;


    public DependentsController(IDependentService dependentService, IValidator<DependentRequestDto> validator)
    {
        _dependentService = dependentService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dependents = await _dependentService.GetAll();
        return Ok(dependents);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dependents = await _dependentService.GetById(id);
        return Ok(dependents);
    }

    [HttpGet("get-dependents-by-userid/{userId}")]
    public async Task<IActionResult> GetDependentByUserId(int userId)
    {
        var dependents = await _dependentService.GetDependentsByUserId(userId);
        return Ok(dependents);
    }

    [HttpPost]
    public async Task<IActionResult> Create(DependentRequestDto dependentsDto)
    {
        var validationResult = await _validator.ValidateAsync(dependentsDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var dependents = await _dependentService.Add(dependentsDto);
        return Ok(dependents);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update( int id, DependentRequestDto dependentsDto)
    {
        var dependent = await _dependentService.Update(dependentsDto, id);
        if (dependent == null) 
        {
            return NotFound();
        }
        return Ok(dependent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var dependent = await _dependentService.Delete( id);
        if (dependent == null) 
        {
            return NotFound();
        }
        return Ok(dependent);
    }

}
