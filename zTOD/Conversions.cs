namespace zTOD
{
    public static class Conversions
    {
        /// <summary>
        /// Convert z/OS timestamps to Unix style timestampe
        /// </summary>
        /// <param name="fourKusecs">The z/OS TOD timestamp as 8 bytes</param>
        /// <param name="leapfourKusecs">The z/OS leap seconds value from CVTLSO</param>
        /// <returns>A ulong (8 bytes) Unix style representation of the z/OS timestamp</returns>
        public static ulong Convert_zOS_TSTP_2_UNIX_TSTP(ulong fourKusecs, ulong leapfourKusecs = 0UL)
        {
            // z/OS timestamp is the number of clock ticks since January 1, 1900 UTC
            // where 4096 clock ticks equal one microsecond.

            // UNIX timestamp is microseconds after January 1, 1970 UTC.

            // z/OS keeps a leap second count in CVTLSO and *subtracts* that
            // from TOD to get UTC
            fourKusecs -= leapfourKusecs;

            // 4k us from Jan 1, 1900 to Jan 1, 1970, UTC
            fourKusecs -= 9048018124800000000UL;

            // us since January 1, 1970, UTC
            return fourKusecs / 4096UL;
        }

    }
}
