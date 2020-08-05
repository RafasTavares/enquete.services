using Enquete.Domain.AggregateModel.PollAggregate;
using Enquete.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Services.Core.Domain;
using System.Linq;

namespace Enquete.Infra.Repositories
{
    public class OptionRepository : IOptionRepository
    {
        private readonly EnqueteContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public OptionRepository(EnqueteContext context)
        {
            _context = context;
        }


        public Option GetbyId(int id) =>
             _context.Options.AsNoTracking()
                            .FirstOrDefault(o => o.Id == id);

        public Option Update(Option option, Option optinOld)
        {
            _context.Options.Update(optinOld).CurrentValues.SetValues(option);

            return option;
        }
    }
}
