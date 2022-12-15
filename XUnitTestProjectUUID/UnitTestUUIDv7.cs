using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProjectUUID
{
    public class UnitTestUUIDv7
    {
        [Fact]
        public void TestGetRandomA()
        {
            byte[] randA = TensionDev.UUID.UUIDv7.GetRandomA();

            Assert.True(randA.Length == 2);
        }

        [Fact]
        public void TestRandomGetRandomA()
        {
            byte[] randA1 = TensionDev.UUID.UUIDv7.GetRandomA();
            byte[] randA2 = TensionDev.UUID.UUIDv7.GetRandomA();

            Assert.NotEqual(randA1, randA2);
        }

        [Fact]
        public void TestGetRandomB()
        {
            byte[] randB = TensionDev.UUID.UUIDv7.GetRandomB();

            Assert.True(randB.Length == 8);
        }

        [Fact]
        public void TestRandomGetRandomB()
        {
            byte[] randB1 = TensionDev.UUID.UUIDv7.GetRandomB();
            byte[] randB2 = TensionDev.UUID.UUIDv7.GetRandomB();

            Assert.NotEqual(randB1, randB2);
        }

        [Fact]
        public void TestNewUUIDv7()
        {
            TensionDev.UUID.Uuid expectedUUID = new TensionDev.UUID.Uuid("017f22e2-79B0-7cc3-98c4-dc0c0c07398f");

            byte[] randA = new byte[] { 0x7c, 0xc3 };
            byte[] randB = new byte[] { 0x98, 0xc4, 0xdc, 0x0c, 0x0c, 0x07, 0x39, 0x8f };
            DateTime dateTime = DateTime.Parse("2022-02-22T19:22:22.000000Z");
            TensionDev.UUID.Uuid uuid = TensionDev.UUID.UUIDv7.NewUUIDv7(dateTime, randA, randB);

            Assert.Equal(expectedUUID, uuid);
        }

        [Fact]
        public void TestUUIDVariantField()
        {
            IList<char> expectedVariantField = new List<char>() { '8', '9', 'a', 'b' };

            ConcurrentBag<String> concurrentBag = new ConcurrentBag<String>();

            Parallel.For(0, UInt16.MaxValue,
                body =>
                {
                    concurrentBag.Add(TensionDev.UUID.UUIDv7.NewUUIDv7().ToString());
                });

            foreach (String value in concurrentBag)
            {
                Assert.Contains<char>(value[19], expectedVariantField);
            }
        }

        [Fact]
        public void TestNewUUIDv7NullRandomA()
        {
            byte[] randA = null;
            byte[] randB = new byte[] { 0x98, 0xc4, 0xdc, 0x0c, 0x0c, 0x07, 0x39, 0x8f };
            Assert.Throws<ArgumentNullException>(() => TensionDev.UUID.UUIDv7.NewUUIDv7(DateTime.UtcNow, randA, randB));
        }

        [Fact]
        public void TestNewUUIDv7ReducedRandomA()
        {
            byte[] randA = new byte[] { 0x7c };
            byte[] randB = new byte[] { 0x98, 0xc4, 0xdc, 0x0c, 0x0c, 0x07, 0x39, 0x8f };
            Assert.Throws<ArgumentException>(() => TensionDev.UUID.UUIDv7.NewUUIDv7(DateTime.UtcNow, randA, randB));
        }

        [Fact]
        public void TestNewUUIDv7NullRandomB()
        {
            byte[] randA = new byte[] { 0x7c, 0xc3 };
            byte[] randB = null;
            Assert.Throws<ArgumentNullException>(() => TensionDev.UUID.UUIDv7.NewUUIDv7(DateTime.UtcNow, randA, randB));
        }

        [Fact]
        public void TestNewUUIDv7ReducedRandomB()
        {
            byte[] randA = new byte[] { 0x7c, 0xc3 };
            byte[] randB = new byte[] { 0x98, 0xc4, 0xdc, 0x0c, 0x0c, 0x07, 0x39 };
            Assert.Throws<ArgumentException>(() => TensionDev.UUID.UUIDv7.NewUUIDv7(DateTime.UtcNow, randA, randB));
        }
    }
}
