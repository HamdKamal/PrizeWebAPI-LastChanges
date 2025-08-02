using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CategoryRepository : ICategoryRepository
{

    private readonly PrizeDbContext _context;

    public CategoryRepository(PrizeDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task AddAsync(Category student)
    {
        _context.Categories.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category student)
    {
        _context.Categories.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await _context.Categories.FindAsync(id);
        if (student != null)
        {
            _context.Categories.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}

