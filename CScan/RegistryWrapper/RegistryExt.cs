using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScan.RegistryWrapper
{
    public static class RegistryExt
    {
        public static string toEntryString(this RegistryView view)
        {
            return view == RegistryView.Registry64 ? "(x64)" : "(x32)";
        }
    }
}
