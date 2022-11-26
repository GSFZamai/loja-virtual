using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Core.Integration
{
    public class MovimentarEstoqueRequest : IRequest<bool>
    {
        public IEnumerable<Item>  Itens { get; set; } 
    }
}
