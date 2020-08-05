using Enquete.Domain.AggregateModel.PollAggregate;
using Microsoft.EntityFrameworkCore;
using Services.Core.Domain;

namespace Enquete.Infra.Context
{
    public class EnqueteContext : DbContext, IUnitOfWork
    {
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Option> Options { get; set; }

        public EnqueteContext(DbContextOptions<EnqueteContext> options) : base(options) { }

        public void Salvar()
        {
            SaveChanges();
        }
    }
}
