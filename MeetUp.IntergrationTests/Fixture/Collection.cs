using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MeetUp.IntergrationTests.Fixture
{
    [CollectionDefinition("SystemCollection")]
    public class Collection : ICollectionFixture<TestsBase>
    {

    }
}
