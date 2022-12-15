using BkVirtual.Core.Data;
using BkVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Domain.Interfaces.Repositories
{
    public interface ITransacaoRepository
    {
        IUnityOfWork UnityOfWork { get; }
        Task SalvarAsync(Transacao transacao);
    }
}
