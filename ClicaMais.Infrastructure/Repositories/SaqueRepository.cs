using ClicaMais.Domain.Models;
using ClicaMais.Domain.Repositories;
using ClicaMais.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace ClicaMais.Infrastructure.Repositories;

public class SaqueRepository : ISaqueRepository
{
    private readonly AppDbContext _context;

    public SaqueRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AtualizarAsync(Saque saque)
    {
        _context.Saques.Update(saque);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Saque>> ObterPendentesAsync()
    {
        return await _context.Saques
        .Where(s => s.Status == "Pendente")
        .ToListAsync();
    }
    public async Task<List<Saque>> ObterTodosAsync()
    {
        return await _context.Saques.ToListAsync();
    }

    public async Task<Saque?> ObterPorIdAsync(Guid id)
    {
        return await _context.Saques.FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task<List<Saque>> ObterPorJogadorIdAsync(Guid id)
    {
        return await _context.Saques
            .Where(s => s.JogadorId == id).ToListAsync();
    }

    public async Task RegistrarAsync(Saque saque)
    {
        _context.Saques.Add(saque);
        await _context.SaveChangesAsync();
    }
}