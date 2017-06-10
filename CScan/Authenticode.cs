using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace CScan
{
    internal class Authenticode
    {
        private static readonly string tempPath = Path.Combine(Path.GetTempPath(), "signtool.exe");

        public static bool IsSigned(string fileName, bool strict = false)
        {
            return WinTrustVerify.WinTrust.Verify(fileName); ; // Might need to do more verification here.
        }
    }
}