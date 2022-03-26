using System;
using Xunit;

namespace XUnitTestProjectUUID
{
    public class UnitTestUuid
    {
        [Fact]
        public void TestConstructorByteArray1()
        {
            byte[] vs = null;
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => { TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs); });
        }

        [Fact]
        public void TestConstructorByteArray2()
        {
            byte[] vs = new byte[17];
            ArgumentException ex = Assert.Throws<ArgumentException>(() => { TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs); });
        }

        [Fact]
        public void TestConstructorByteArray3()
        {
            string expectedUUID = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            byte[] vs = new byte[] { 0x7d, 0x44, 0x48, 0x40, 0x9d, 0xc0, 0x11, 0xd1, 0xb2, 0x45, 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };

            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);
            Assert.Equal(expectedUUID, uuid.ToString());
        }

        [Fact]
        public void TestConstructorString1()
        {
            string vs = null;
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => { TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs); });
        }

        [Fact]
        public void TestConstructorString2()
        {
            string vs = "(7d444840-9dc0-11d1-b245-5ffdce74fad2}";
            FormatException ex = Assert.Throws<FormatException>(() => { TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs); });
        }

        [Fact]
        public void TestConstructorString3()
        {
            string expectedUUID = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            string vs = "7d444840-9dc0-11d1-b245-5ffdce74fad2";

            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);
            Assert.Equal(expectedUUID, uuid.ToString());
        }

        [Fact]
        public void TestConstructorComponents1()
        {
            uint a = uint.MaxValue;
            ushort b = ushort.MaxValue;
            ushort c = ushort.MaxValue;
            byte d = byte.MaxValue;
            byte e = byte.MaxValue;
            byte[] f = null;
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => { TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(a, b, c, d, e, f); });
        }

        [Fact]
        public void TestConstructorComponents2()
        {
            uint a = uint.MinValue;
            ushort b = ushort.MinValue;
            ushort c = ushort.MinValue;
            byte d = byte.MinValue;
            byte e = byte.MinValue;
            byte[] f = new byte[5];
            ArgumentException ex = Assert.Throws<ArgumentException>(() => { TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(a, b, c, d, e, f); });
        }

        [Fact]
        public void TestConstructorComponents3()
        {
            string expectedUUID = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            uint a = 2101626944;
            ushort b = 40384;
            ushort c = 4561;
            byte d = 178;
            byte e = 69;
            byte[] f = new byte[] { 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };

            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(a, b, c, d, e, f);
            Assert.Equal(expectedUUID, uuid.ToString());
        }

        [Fact]
        public void TestConstructorNodeBytes1()
        {
            string expectedUUID = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            uint a = 2101626944;
            ushort b = 40384;
            ushort c = 4561;
            byte d = 178;
            byte e = 69;
            byte f = 0x5f;
            byte g = 0xfd;
            byte h = 0xce;
            byte i = 0x74;
            byte j = 0xfa;
            byte k = 0xd2;

            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(a, b, c, d, e, f, g, h, i, j, k);
            Assert.Equal(expectedUUID, uuid.ToString());
        }

        [Fact]
        public void TestParse1()
        {
            string expectedUUID = "7d444840-9dc0-11d1-b245-5ffdce74fad2";

            TensionDev.UUID.Uuid uuid = TensionDev.UUID.Uuid.Parse(expectedUUID);
            Assert.Equal(expectedUUID, uuid.ToString());
        }

        [Fact]
        public void TestTryParse1()
        {
            string expectedUUID = "7d444840-9dc0-11d1-b245-5ffdce74fad2";

            bool result = TensionDev.UUID.Uuid.TryParse(expectedUUID, out TensionDev.UUID.Uuid uuid);
            Assert.Equal(expectedUUID, uuid.ToString());
            Assert.True(result);
        }

        [Fact]
        public void TestTryParse2()
        {
            string expectedUUID = "00000000-0000-0000-0000-000000000000";
            string vs = "(7d444840-9dc0-11d1-b245-5ffdce74fad2}";

            bool result = TensionDev.UUID.Uuid.TryParse(vs, out TensionDev.UUID.Uuid uuid);
            Assert.Equal(expectedUUID, uuid.ToString());
            Assert.False(result);
        }

        [Fact]
        public void TestCompareTo1()
        {
            int expectedResult = 1;
            object other = new object();
            string vs = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            TensionDev.UUID.Uuid uuid = TensionDev.UUID.Uuid.Parse(vs);

            int actualResult = uuid.CompareTo(other);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestCompareTo2()
        {
            int expectedResult = 0;
            string vs = "7d4448409dc011d1b2455ffdce74fad2";
            TensionDev.UUID.Uuid uuid1 = TensionDev.UUID.Uuid.Parse(vs);
            TensionDev.UUID.Uuid uuid2 = TensionDev.UUID.Uuid.Parse(vs);

            int actualResult = uuid1.CompareTo(uuid2);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestEquals1()
        {
            object other = new object();
            string vs = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            TensionDev.UUID.Uuid uuid = TensionDev.UUID.Uuid.Parse(vs);

            bool actualResult = uuid.Equals(other);
            Assert.False(actualResult);
        }

        [Fact]
        public void TestEquals2()
        {
            string vs = "{7d444840-9dc0-11d1-b245-5ffdce74fad2}";
            TensionDev.UUID.Uuid uuid1 = TensionDev.UUID.Uuid.Parse(vs);
            TensionDev.UUID.Uuid uuid2 = TensionDev.UUID.Uuid.Parse(vs);

            bool actualResult = uuid1.Equals(uuid2);
            Assert.True(actualResult);
        }

        [Fact]
        public void TestToByteArray3()
        {
            byte[] expected = new byte[] { 0x7d, 0x44, 0x48, 0x40, 0x9d, 0xc0, 0x11, 0xd1, 0xb2, 0x45, 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };
            string vs = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);

            byte[] actual = uuid.ToByteArray();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToString1()
        {
            string expected = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            byte[] vs = new byte[] { 0x7d, 0x44, 0x48, 0x40, 0x9d, 0xc0, 0x11, 0xd1, 0xb2, 0x45, 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };
            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);

            string actual = uuid.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToString2()
        {
            string expected = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            byte[] vs = new byte[] { 0x7d, 0x44, 0x48, 0x40, 0x9d, 0xc0, 0x11, 0xd1, 0xb2, 0x45, 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };
            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);

            string actual = uuid.ToString(null);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToString3()
        {
            string expected = "7d444840-9dc0-11d1-b245-5ffdce74fad2";
            byte[] vs = new byte[] { 0x7d, 0x44, 0x48, 0x40, 0x9d, 0xc0, 0x11, 0xd1, 0xb2, 0x45, 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };
            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);

            string actual = uuid.ToString(String.Empty);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToHexString4()
        {
            string expected = "7d4448409dc011d1b2455ffdce74fad2";
            byte[] vs = new byte[] { 0x7d, 0x44, 0x48, 0x40, 0x9d, 0xc0, 0x11, 0xd1, 0xb2, 0x45, 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };
            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);

            string actual = uuid.ToString("N");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToString5()
        {
            string expected = "{7d444840-9dc0-11d1-b245-5ffdce74fad2}";
            byte[] vs = new byte[] { 0x7d, 0x44, 0x48, 0x40, 0x9d, 0xc0, 0x11, 0xd1, 0xb2, 0x45, 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };
            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);

            string actual = uuid.ToString("B");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToString6()
        {
            string expected = "(7d444840-9dc0-11d1-b245-5ffdce74fad2)";
            byte[] vs = new byte[] { 0x7d, 0x44, 0x48, 0x40, 0x9d, 0xc0, 0x11, 0xd1, 0xb2, 0x45, 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };
            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);

            string actual = uuid.ToString("P");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToString7()
        {
            byte[] vs = new byte[] { 0x7d, 0x44, 0x48, 0x40, 0x9d, 0xc0, 0x11, 0xd1, 0xb2, 0x45, 0x5f, 0xfd, 0xce, 0x74, 0xfa, 0xd2 };
            TensionDev.UUID.Uuid uuid = new TensionDev.UUID.Uuid(vs);

            FormatException ex = Assert.Throws<FormatException>(() => { string actual = uuid.ToString("C"); });
        }
    }
}
