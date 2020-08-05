using Enquete.Domain.AggregateModel.PollAggregate;
using Enquete.Domain.Commands.PollCommand.Commands;
using Enquete.Domain.Commands.PollCommand.Handlers;
using Enquete.Domain.Queries.PollQueries.Handlers;
using Enquete.Domain.Queries.PollQueries.Queries;
using Enquete.Test.Mock;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enquete.Test.Tests
{
    public class PollTest
    {
        private Mock<IPollRepository> _pollRepositorioMock;
        private List<Poll> _pollMock;

        [SetUp]
        public void SetupAsync()
        {
            _pollRepositorioMock = new Mock<IPollRepository>();

            _pollMock = PollMock.GetPollMock();

            _pollRepositorioMock.Setup(r => r.GetbyId(It.IsAny<int>())).Returns(_pollMock.FirstOrDefault());
            _pollRepositorioMock.Setup(r => r.GetbyId(It.IsAny<int>())).Returns((int id_poll) => _pollMock.Where(x => x.Id == id_poll).FirstOrDefault());

            _pollRepositorioMock.Setup(r => r.Add(It.IsAny<Poll>())).Returns(_pollMock.FirstOrDefault());

            _pollRepositorioMock.Setup(s => s.UnitOfWork.Salvar());
        }

        [Test]
        public void GetPollByIdSuccessAsync()
        {

            var command = new GetByIdQueryHandler(_pollRepositorioMock.Object);

            var result = command.Handle(new GetByIdQuery(1), new CancellationToken()).Result;

            Assert.NotNull(result);
            Assert.AreNotEqual(0, result.Poll_id);
            Assert.AreEqual(_pollMock.FirstOrDefault().PollDescription, result.Poll_description);
        }

        [Test]
        public void GetPollByIdNotFound()
        {
            var command = new GetByIdQueryHandler(_pollRepositorioMock.Object);

            var result = command.Handle(new GetByIdQuery(2), new CancellationToken()).Result;

            Assert.AreEqual(0, result.Poll_id);
            Assert.AreEqual(null, result.Poll_description);
        }

        [Test]
        public void AddPollSuccessAsync()
        {
            var command = new AddPollCommandHandler(_pollRepositorioMock.Object);

            var result = command.Handle(new AddPollCommand("Descrição", new List<string>() { "Descrição" }), new CancellationToken()).Result;

            Assert.NotNull(result);
            Assert.AreNotEqual(0, result.Poll_id);

            _pollRepositorioMock.Verify(p => p.Add(It.IsAny<Poll>()), Times.Once);
            _pollRepositorioMock.Verify(p => p.UnitOfWork.Salvar(), Times.Once);
        }
    }
}