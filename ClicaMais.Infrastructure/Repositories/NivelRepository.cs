using ClicaMais.Domain.Models;
using ClicaMais.Domain.Repositories;
using ClicaMais.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace ClicaMais.Infrastructure.Repositories;

public class NivelRepository : INivelRepository
{
    private readonly AppDbContext _context;
    public NivelRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AtualizarAsync(Nivel Nivel)
    {
        _context.Niveis.Update(Nivel);
        await _context.SaveChangesAsync();
    }

    public async Task CriarAsync(Nivel Nivel)
    {
        _context.Niveis.Add(Nivel);
        await _context.SaveChangesAsync();
    }
    public async Task<Nivel?> ObterPorIdAsync(int id)
    {
        return await _context.Niveis
            .FirstOrDefaultAsync(n => n.Id == id);
    }
    public async Task<Nivel?> ObterPorNumeroAsync(int num)
    {
        return await _context.Niveis
            .FirstOrDefaultAsync(n => n.Numero == num);
    }
    public async Task<List<Nivel>> ObterTodosAsync()
    {
        return await _context.Niveis.ToListAsync();
    }
}