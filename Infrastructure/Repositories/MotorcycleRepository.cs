using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MotorcycleRepository : IMotorcycleRepository
{
    private readonly ApplicationDbContext _context;

    public MotorcycleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Motorcycle> GetByIdAsync(int id)
    {
        return await _context.Motorcycles.FindAsync(id);
    }

    public async Task<IEnumerable<Motorcycle>> GetAllAsync()
    {
        return await _context.Motorcycles.ToListAsync();
    }

    public async Task AddAsync(Motorcycle motorcycle)
    {
        _context.Motorcycles.Add(motorcycle);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Motorcycle motorcycle)
    {
        _context.Motorcycles.Update(motorcycle);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Motorcycle motorcycle)
    {
        _context.Motorcycles.Remove(motorcycle);
        await _context.SaveChangesAsync();
    }
}
