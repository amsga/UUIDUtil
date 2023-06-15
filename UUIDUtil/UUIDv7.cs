//   Copyright 2021 TensionDev <TensionDev@outlook.com>
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;

namespace TensionDev.UUID
{
    /// <summary>
    /// Class Library to generate Universally Unique Identifier (UUID) / Globally Unique Identifier (GUID) based on Version 7 (date-time).
    /// </summary>
    public class UUIDv7
    {
        protected internal static DateTime s_epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Initialises a new GUID/UUID based on Version 7 (date-time)
        /// </summary>
        /// <returns>A new Uuid object</returns>
        public static Uuid NewUUIDv7()
        {
            return NewUUIDv7(DateTime.UtcNow);
        }

        /// <summary>
        /// Initialises the 12-bit rand_a and returns it.<br />
        /// Returns a randomly genrated 16-bit rand_a.
        /// </summary>
        /// <returns>A byte-array representing the 16-bit rand_a</returns>
        public static Byte[] GetRandomA()
        {
            using (System.Security.Cryptography.RNGCryptoServiceProvider cryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                Byte[] fakeNode = new Byte[2];
                cryptoServiceProvider.GetBytes(fakeNode);
                return fakeNode;
            }
        }

        /// <summary>
        /// Initialises the 62-bit rand_b and returns it.<br />
        /// Returns a randomly genrated 64-bit rand_b.
        /// </summary>
        /// <returns>A byte-array representing the 64-bit rand_b</returns>
        public static Byte[] GetRandomB()
        {
            using (System.Security.Cryptography.RNGCryptoServiceProvider cryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                Byte[] fakeNode = new Byte[8];
                cryptoServiceProvider.GetBytes(fakeNode);
                return fakeNode;
            }
        }

        /// <summary>
        /// Initialises a new GUID/UUID based on Version 7 (date-time), based on the given date and time.
        /// </summary>
        /// <param name="dateTime">Given Date and Time</param>
        /// <returns>A new Uuid object</returns>
        public static Uuid NewUUIDv7(DateTime dateTime)
        {
            return NewUUIDv7(dateTime, GetRandomA(), GetRandomB());
        }

        /// <summary>
        /// Initialises a new GUID/UUID based on Version 7 (date-time), based on the given date and time, Clock Sequence with Variant and Node ID.
        /// </summary>
        /// <param name="dateTime">Given Date and Time</param>
        /// <param name="randomA">Given 16-bit rand_a</param>
        /// <param name="randomB">Given 64-bit rand_b</param>
        /// <returns>A new Uuid object</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static Uuid NewUUIDv7(DateTime dateTime, Byte[] randomA, Byte[] randomB)
        {
            if (randomA == null)
                throw new ArgumentNullException(nameof(randomA));

            if (randomA.Length < 2)
                throw new ArgumentException(String.Format("rand_a contains less than 16-bit: {0} bytes", randomA.Length), nameof(randomA));

            if (randomB == null)
                throw new ArgumentNullException(nameof(randomB));

            if (randomB.Length < 8)
                throw new ArgumentException(String.Format("rand_b contains less than 64-bit: {0} bytes", randomB.Length), nameof(randomB));

            TimeSpan timesince = dateTime.ToUniversalTime() - s_epoch.ToUniversalTime();
            Int64 timeinterval = ((Int64)timesince.TotalMilliseconds) << 16;

            Byte[] time = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(timeinterval));

            Byte[] hex = new Byte[16];

            hex[0] = time[0];
            hex[1] = time[1];
            hex[2] = time[2];
            hex[3] = time[3];

            hex[4] = time[4];
            hex[5] = time[5];

            hex[6] = (Byte)((randomA[0] & 0x0F) + 0x70);
            hex[7] = randomA[1];

            hex[8] = (Byte)((randomB[0] & 0x3F) | 0x80);
            hex[9] = randomB[1];
            hex[10] = randomB[2];
            hex[11] = randomB[3];
            hex[12] = randomB[4];
            hex[13] = randomB[5];
            hex[14] = randomB[6];
            hex[15] = randomB[7];

            Uuid Id = new Uuid(hex);

            return Id;
        }
    }
}
