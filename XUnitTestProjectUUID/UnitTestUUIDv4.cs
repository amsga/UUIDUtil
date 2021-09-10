using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProjectUUID
{
    public class UnitTestUUIDv4
    {
        [Fact]
        public void TestNewUUIDv4()
        {
            char expectedVersionField = '4';

            ConcurrentBag<String> concurrentBag = new ConcurrentBag<String>();

            Parallel.For(0, UInt16.MaxValue,
                body =>
                {
                    concurrentBag.Add(TensionDev.UUID.UUIDv4.NewUUIDv4().ToString());
                });

            foreach (String value in concurrentBag)
            {
                Assert.Equal(value[14], expectedVersionField);
            }
        }

        [Fact]
        public void TestUUIDVariantField()
        {
            IList<char> expectedVariantField = new List<char>() { '8', '9', 'a', 'b' };

            ConcurrentBag<String> concurrentBag = new ConcurrentBag<String>();

            Parallel.For(0, UInt16.MaxValue,
                body =>
                {
                    concurrentBag.Add(TensionDev.UUID.UUIDv4.NewUUIDv4().ToString());
                });

            foreach (String value in concurrentBag)
            {
                Assert.Contains<char>(value[19], expectedVariantField);
            }
        }
    }
}
