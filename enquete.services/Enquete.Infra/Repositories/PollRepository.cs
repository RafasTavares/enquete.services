using Enquete.Domain.AggregateModel.PollAggregate;
using Enquete.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Services.Core.Domain;
using System.Linq;

namespace Enquete.Infra.Repositories
{
    public class PollRepository : IPollRepository
    {
        private readonly EnqueteContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public PollRepository(EnqueteContext context)
        {
            _context = context;
        }

        public Poll Add(Poll poll)
        {
            _context.Polls.Add(poll);

            return poll;
        }

        public Poll GetbyId(int id) =>
            _context.Polls.AsNoTracking().Where(p => p.Id == id).Include(p => p.Options).FirstOrDefault();

        public Poll Update(Poll poll, Poll pollOld)
        {
            _context.Polls.Update(pollOld).CurrentValues.SetValues(poll);
            
            return poll;
        }
    }
}