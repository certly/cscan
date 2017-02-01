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
            List<Signer> signers = new List<Signer>();
            //WinTrustVerify.WinTrust.Verify(fileName, out signers);

            return true;
            // Crashes in an odd spot. For now, we'll always return true. Just so project builds.
            // NOTE: WILL NEED TO BE DEBUGGED AND FIXED.
            //return signers.Count > 0; // Might need to do more verification here.
        }
    }
}