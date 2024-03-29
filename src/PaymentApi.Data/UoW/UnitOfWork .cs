﻿using PaymentApi.Data.Context;
using PaymentApi.Domain.Interfaces;

namespace PaymentApi.Data.UoW;
public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context) =>
        _context = context;

    public async Task<bool> Commit()
    {
        var success = (await _context.SaveChangesAsync()) > 0;

        return success;
    }

    public void Dispose() =>
        _context.Dispose();

    public Task Rollback()
    {
        Dispose();
        return Task.CompletedTask;        
    }
}
