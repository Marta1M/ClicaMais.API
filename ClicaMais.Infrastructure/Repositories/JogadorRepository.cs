using ClicaMais.Domain.Models;
using ClicaMais.Domain.Repositories;
using ClicaMais.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace ClicaMais.Infrastructure.Repositories;

public class JogadorRepository : IJogadorRepository
{
    private readonly AppDbContext _context;
    public JogadorRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AtualizarAsync(Jogador jogador)
    {
        _context.Jogadores.Update(jogador);
        await _context.SaveChangesAsync();
    }

    public async Task CriarAsync(Jogador jogador)
    {
        _context.Jogadores.Add(jogador);
        await _context.SaveChangesAsync();
    }

    public async Task<Jogador?> ObterPorEmailAsync(string email)
    {
        return await _context.Jogadores
            .FirstOrDefaultAsync(j => j.Email == email);
    }

    public async Task<Jogador?> ObterPorIdAsync(Guid id)
    {
        return await _context.Jogadores
            .Include(j => j.NivelAtual)
            .FirstOrDefaultAsync(j => j.Id == id);
    }
    public async Task<bool> ExisteEmailAsync(string email)
    {
        return await _context.Jogadores.AnyAsync(j => j.Email == email);
    }
}