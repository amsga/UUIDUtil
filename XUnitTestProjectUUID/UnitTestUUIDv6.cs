using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProjectUUID
{
    public class UnitTestUUIDv6
    {
        [Fact]
        public void TestGetNodeID()
        {
            byte[] nodeID = TensionDev.UUID.UUIDv6.GetNodeID();

            Assert.True(nodeID.Length == 6);
        }

        [Fact]
        public void TestRandomGetNodeID()
        {
            byte[] nodeID1 = TensionDev.UUID.UUIDv6.GetNodeID();
            byte[] nodeID2 = TensionDev.UUID.UUIDv6.GetNodeID();

            Assert.NotEqual(nodeID1, nodeID2);
        }

        [Fact]
        public void TestNewUUIDv6()
        {
            TensionDev.UUID.Uuid expectedUUID = new TensionDev.UUID.Uuid("1ec9414c-232a-6b00-82a8-0242ac130003");

            byte[] nodeID = new byte[] { 0x02, 0x42, 0xac, 0x13, 0x00, 0x03 };
            byte[] clockSequence = new byte[] { 0x82, 0xa8 };
            DateTime dateTime = DateTime.Parse("2022-02-22T19:22:22.000000Z");
            TensionDev.UUID.Uuid uuid = TensionDev.UUID.UUIDv6.NewUUIDv6(dateTime, clockSequence, nodeID);

            Assert.Equal(expectedUUID, uuid);
        }

        [Fact]
        public void TestGetClockSequence()
        {
            ConcurrentDictionary<UInt16, Boolean> concurrentDictionary = new ConcurrentDictionary<UInt16, Boolean>();
            Int32 expectedMaxSequence = 0x4000;

            Parallel.For(0, UInt16.MaxValue,
                clock =>
                {
                    Byte[] vs = TensionDev.UUID.UUIDv6.GetClockSequence();
                    Int16 networkorder = BitConverter.ToInt16(vs);
                    UInt16 key = (UInt16)System.Net.IPAddress.NetworkToHostOrder(networkorder);
                    concurrentDictionary.TryAdd(key, true);
                });

            Assert.Equal(expectedMaxSequence, concurrentDictionary.Values.Count);
            ICollection<UInt16> keys = concurrentDictionary.Keys;
            foreach (UInt16 key in keys)
            {
                Assert.InRange(key, 0x8000, 0xBFFF);
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
                    concurrentBag.Add(TensionDev.UUID.UUIDv6.NewUUIDv6().ToString());
                });

            foreach (String value in concurrentBag)
            {
                Assert.Contains<char>(value[19], expectedVariantField);
            }
        }

        [Fact]
        public void TestNewUUIDv6NullClockSequence()
        {
            byte[] nodeID = new byte[] { 0x02, 0x42, 0xac, 0x13, 0x00, 0x03 };
            byte[] clockSequence = null;
            Assert.Throws<ArgumentNullException>(() => TensionDev.UUID.UUIDv6.NewUUIDv6(DateTime.UtcNow, clockSequence, nodeID));
        }

        [Fact]
        public void TestNewUUIDv6ReducedClockSequence()
        {
            byte[] nodeID = new byte[] { 0x02, 0x42, 0xac, 0x13, 0x00, 0x03 };
            byte[] clockSequence = new byte[] { 0x82 };
            Assert.Throws<ArgumentException>(() => TensionDev.UUID.UUIDv6.NewUUIDv6(DateTime.UtcNow, clockSequence, nodeID));
        }

        [Fact]
        public void TestNewUUIDv6NullNodeID()
        {
            byte[] nodeID = null;
            byte[] clockSequence = new byte[] { 0x82, 0xa8 };
            Assert.Throws<ArgumentNullException>(() => TensionDev.UUID.UUIDv6.NewUUIDv6(DateTime.UtcNow, clockSequence, nodeID));
        }

        [Fact]
        public void TestNewUUIDv6ReducedNodeID()
        {
            byte[] nodeID = new byte[] { 0x02, 0x42, 0xac, 0x13 };
            byte[] clockSequence = new byte[] { 0x82, 0xa8 };
            Assert.Throws<ArgumentException>(() => TensionDev.UUID.UUIDv6.NewUUIDv6(DateTime.UtcNow, clockSequence, nodeID));
        }
    }
}
