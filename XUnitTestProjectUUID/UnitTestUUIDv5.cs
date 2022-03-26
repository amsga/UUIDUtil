using System;
using Xunit;

namespace XUnitTestProjectUUID
{
    public class UnitTestUUIDv5
    {
        [Fact]
        public void TestNewUUIDv5_DNS()
        {
            TensionDev.UUID.Uuid expectedGuid = new TensionDev.UUID.Uuid("016ab729-5c3f-55fe-9d10-e30cb958f0e0");

            String name = "www.contoso.com";
            TensionDev.UUID.Uuid guid = TensionDev.UUID.UUIDv5.NewUUIDv5(TensionDev.UUID.UUIDNamespace.DNS, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv5_URL()
        {
            TensionDev.UUID.Uuid expectedGuid = new TensionDev.UUID.Uuid("1bf6935b-49e6-54cf-a9c8-51fb21c41b46");

            String name = "https://www.contoso.com";
            TensionDev.UUID.Uuid guid = TensionDev.UUID.UUIDv5.NewUUIDv5(TensionDev.UUID.UUIDNamespace.URL, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv5_OID()
        {
            TensionDev.UUID.Uuid expectedGuid = new TensionDev.UUID.Uuid("8d3d0edc-5b53-56a7-953b-f11fbc48388a");

            String name = "1.0.3166.1";
            TensionDev.UUID.Uuid guid = TensionDev.UUID.UUIDv5.NewUUIDv5(TensionDev.UUID.UUIDNamespace.OID, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv5_X500()
        {
            TensionDev.UUID.Uuid expectedGuid = new TensionDev.UUID.Uuid("61c75a15-eedd-5349-ab65-b35f0ef81d7c");

            String name = "/c=us/o=Sun/ou=People/cn=Rosanna Lee";
            TensionDev.UUID.Uuid guid = TensionDev.UUID.UUIDv5.NewUUIDv5(TensionDev.UUID.UUIDNamespace.X500, name);

            Assert.Equal(expectedGuid, guid);
        }
    }
}
