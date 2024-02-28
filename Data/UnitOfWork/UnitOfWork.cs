using Data.Context;
using Data.Interface;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
            Clientes = new ClienteRepository(_context);
        }

        public IClienteRepository Clientes { get; }

        public void Guardar()
        {
            _context.SaveChanges();
        }
    }
}
