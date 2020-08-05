using Enquete.Domain.AggregateModel.PollAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enquete.Test.Mock
{
    public static class OptionMock
    {
        public static List<Option> GetOptionMock() =>
             InitOptionSimpleMock();

        private static List<Option> InitOptionSimpleMock()
        {
            return new List<Option>() {
                new Option() {
                            Id = 1,
                            OptionDescription = "First Option Description",
                            Count = 0
                        }
                    };
        }
    }
}
