using NoteBook.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBook.Domain.Entity;

namespace NoteBook.Domain.Concrete
{
    public class EFRepository : IRepository
    {
        private EFDbContext db = new EFDbContext();

        //private NoteBookEntities db = new NoteBookEntities();

        public IQueryable<State> States { get => db.States; }
        public IQueryable<AnOrder> Orders { get => db.AnOrders; }
    }
}
