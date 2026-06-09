using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureEmployeeManagementSystem.Application.DTOs;
using SecureEmployeeManagementSystem.Application.Interfaces;
using SecureEmployeeManagementSystem.Domain.Entities;

namespace SecureEmployeeManagementSystem.API.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase

{
    private readonly IEmployeeService _service;
    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var emp = await _service.GetByIdAsync(id);
        return emp == null ? NotFound() : Ok(emp);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CreateEmployeeDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string? keyword,
        [FromQuery] string? department,
        [FromQuery] string? designation,
        [FromQuery] bool? isActive)
    {
        var result = await _service.SearchAsync(keyword, department, designation, isActive);
        return Ok(result);
    }
    
    [HttpGet("dashboard")]
    [AllowAnonymous]
    public async Task<IActionResult> GetDashboard()
    {
        var data = await _service.GetDashboardAsync();
        return Ok(data);
    }

}