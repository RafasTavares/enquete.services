using Enquete.Domain.AggregateModel.PollAggregate;
using Enquete.Domain.Commands.OptionCommand.Commands;
using Enquete.Domain.Commands.OptionCommand.Handlers;
using Enquete.Test.Mock;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Enquete.Test.Tests
{
    public class OptionTest
    {

        private Mock<IOptionRepository> _optionsRepositorioMock;
        private Mock<IPollRepository> _pollRepositorioMock;

        private List<Option> _optionMock;

        [SetUp]
        public void Setup()
        {
            _optionMock = OptionMock.GetOptionMock();

            _optionsRepositorioMock = new Mock<IOptionRepository>();
            _pollRepositorioMock = new Mock<IPollRepository>();

            _optionsRepositorioMock.Setup(s => s.GetbyId(It.IsAny<int>())).Returns(_optionMock.FirstOrDefault());
            _optionsRepositorioMock.Setup(r => r.GetbyId(It.IsAny<int>())).Returns((int id_option) => _optionMock.Where(x => x.Id == id_option).FirstOrDefault());

            _optionsRepositorioMock.Setup(s => s.UnitOfWork.Salvar());
        }

        [Test]
        public void VoteOptionsExceptionNotFound()
        {
            var command = new AddPollToOptionCommandHandler(_optionsRepositorioMock.Object);

            var result = command.Handle(new AddPollToOptionCommand(999), new CancellationToken()).Result;
            
             _optionsRepositorioMock.Setup(s => s.GetbyId(It.IsAny<int>())).Returns((Option)null);

            _optionsRepositorioMock.Verify(p => p.Update(It.IsAny<Option>(), It.IsAny<Option>()), Times.Never);
        }

        [Test]
        public void VoteOptionsSuccess()
        {
            _optionMock.FirstOrDefault().Count = 1;
            _optionsRepositorioMock.Setup(s => s.Update(It.IsAny<Option>(), It.IsAny<Option>())).Returns(_optionMock.FirstOrDefault());

            var optionsMock = OptionMock.GetOptionMock();
            var command = new AddPollToOptionCommandHandler(_optionsRepositorioMock.Object);

            var result = command.Handle(new AddPollToOptionCommand(optionsMock.FirstOrDefault().Id), new CancellationToken()).Result;

            Assert.NotNull(result);
            Assert.True(result);
            _optionsRepositorioMock.Verify(p => p.Update(It.IsAny<Option>(), It.IsAny<Option>()), Times.Once);
        }
    }
}
