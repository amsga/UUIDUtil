namespace TensionDev.UUID
{
    /// <summary>
    /// Class Library to generate Universally Unique Identifier (UUID) / Globally Unique Identifier (GUID) based on Version 3 (MD5 namespace name-based).
    /// </summary>
    public class UUIDNamespace
    {
        /// <summary>
        /// Namespace for Domain Name System
        /// </summary>
        public static Uuid DNS = new Uuid(0x6ba7b810, 0x9dad, 0x11d1, 0x80, 0xb4, 0x00, 0xc0, 0x4f, 0xd4, 0x30, 0xc8);
        /// <summary>
        /// Namespace for URLs
        /// </summary>
        public static Uuid URL = new Uuid(0x6ba7b811, 0x9dad, 0x11d1, 0x80, 0xb4, 0x00, 0xc0, 0x4f, 0xd4, 0x30, 0xc8);
        /// <summary>
        /// Namespace for ISO Object IDs (OIDs)
        /// </summary>
        public static Uuid OID = new Uuid(0x6ba7b812, 0x9dad, 0x11d1, 0x80, 0xb4, 0x00, 0xc0, 0x4f, 0xd4, 0x30, 0xc8);
        /// <summary>
        /// Namespace for X.500 Distinguished Names(DNs)
        /// </summary>
        public static Uuid X500 = new Uuid(0x6ba7b814, 0x9dad, 0x11d1, 0x80, 0xb4, 0x00, 0xc0, 0x4f, 0xd4, 0x30, 0xc8);
    }
}
