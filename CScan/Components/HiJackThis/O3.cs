using CScan.RegistryWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace CScan.Components.HiJackThis
{
    internal class O3 : IComponent
    {
        protected string ToolbarKey = @"SOFTWARE\Microsoft\Internet Explorer\Toolbar";
        public void Run(ref Report report, List<Dictionary<string, string>> list)
        {

            foreach (RegistryResult result in RegistryWrapper.RegistryWrapper.QuerySubKey(RegistryHive.LocalMachine, ToolbarKey))
            {
                foreach (var toolbarClsid in result.key.GetValueNames())
                {
                    string companyName = Clsid.GetName(toolbarClsid,result.view);
                    string filePath = Clsid.GetFile(toolbarClsid, result.view);

                    list.Add(new Dictionary<string, string>() {
                        {"Token","O3" },
                        {"regview",result.view.toEntryString()},
                        {"company", companyName ?? "()"},
                        {"clsid", toolbarClsid},
                        {"path", filePath ?? "<File not found>" }
                    });
                }
            }


            report.Add(list);
        }

    }
}
