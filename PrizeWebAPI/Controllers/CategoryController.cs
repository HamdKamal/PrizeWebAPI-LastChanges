using Application.Abstractions.Common;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
  
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper, IAuthService authService)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _authService = authService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
    {
        try
        {
            var categories = await _categoryRepository.GetAllAsync();
            var result = _mapper.Map<List<CategoryDTO>>(categories);

            return Ok(new ApiResponse<List<CategoryDTO>>
            {
                Success = true,
                Message = "Categories retrieved successfully.",
                Data = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<List<CategoryDTO>>
            {
                Success = false,
                Message = "An error occurred while retrieving categories.",
                Error = ex.Message
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
    {
        try
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var result = _mapper.Map<CategoryDTO>(category);

            if (category == null || result == null) 
            {
                return NotFound(new ApiResponse<CategoryDTO>
                {
                    Success = false,
                    Message = $"Category with ID {id} not found."
                });
            }
            
            return Ok(new ApiResponse<CategoryDTO>
            {
                Success = true,
                Message = "Category retrieved successfully.",
                Data = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<CategoryDTO>
            {
                Success = false,
                Message = "An error occurred while retrieving the category.",
                Error = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CategoryDTO>>> CreateCategory([FromBody] CategoryDTO categoryDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();

                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Validation failed.",
                    Error = string.Join(" | ", errors)
                });
            }

            Category category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);
            var result = _mapper.Map<CategoryDTO>(category);

       
            return CreatedAtAction(nameof(CreateCategory), new { id = categoryDto.Id }, new ApiResponse<CategoryDTO>
            {
                Success = true,
                Message = "Category added successfully.",
                Data = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<CategoryDTO>
            {
                Success = false,
                Message = "An error occurred while creating the category.",
                Error = ex.Message
            });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<CategoryDTO>>> UpdateCategory(int id, [FromBody] CategoryDTO categoryDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();

                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Validation failed.",
                    Error = string.Join(" | ", errors)
                });
            }

            Category? existingCategory = await _categoryRepository.GetByIdAsync(id);

            if (existingCategory is null)
            {
                return NotFound(new ApiResponse<CategoryDTO>
                {
                    Success = false,
                    Message = $"Category with ID {id} not found."
                });
            }

            if (!(existingCategory.Id.Equals(categoryDto.Id)))
            {
                return BadRequest(new ApiResponse<CategoryDTO>
                {
                    Success = false,
                    Message = "Category ID mismatch."
                });
            }

            var updatedCategory = _mapper.Map(categoryDto, existingCategory);
            await _categoryRepository.UpdateAsync(updatedCategory);
            var result = _mapper.Map<CategoryDTO>(updatedCategory);

            return Ok(new ApiResponse<CategoryDTO>
            {
                Success = true,
                Message = "Category updated successfully.",
                Data = categoryDto
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<CategoryDTO>
            {
                Success = false,
                Message = "An error occurred while updating the category.",
                Error = ex.Message
            });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<string>>> DeleteCategory(int id)
    {
        try
        {
            Category? existingCategory = await _categoryRepository.GetByIdAsync(id);

            if (existingCategory is null)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = $"Category with ID {id} not found."
                });
            }

            await _categoryRepository.DeleteAsync(id);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Category deleted successfully."
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<string>
            {
                Success = false,
                Message = "An error occurred while deleting the category.",
                Error = ex.Message
            });
        }
    }
}

