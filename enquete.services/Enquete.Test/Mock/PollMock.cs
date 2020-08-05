using Enquete.Domain.AggregateModel.PollAggregate;
using System.Collections.Generic;

namespace Enquete.Test.Mock
{
    public static class PollMock
    {
        public static List<Poll> GetPollMock() =>
            InitPollSimpleMock();

        private static List<Poll> InitPollSimpleMock()
        {
            return new List<Poll>() {
                new Poll() {
                            Id = 1,
                            PollDescription = "First Poll Description",
                            Options = new List<Option>()
                            {
                                new Option()
                                {
                                    Id = 1,
                                    OptionDescription = "First Option Description"
                                }
                            }
                }
            };
        }
    }
}
