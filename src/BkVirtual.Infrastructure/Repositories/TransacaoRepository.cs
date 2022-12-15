using BkVirtual.Core.Data;
using BkVirtual.Domain.Entities;
using BkVirtual.Domain.Interfaces.Repositories;
using BkVirtual.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Infrastructure.Repositories
{
    internal class TransacaoRepository : ITransacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public TransacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUnityOfWork UnityOfWork => _context;

        public async  Task SalvarAsync(Transacao transacao)
        {
            await _context.AddAsync(transacao);
        }
    }
}
