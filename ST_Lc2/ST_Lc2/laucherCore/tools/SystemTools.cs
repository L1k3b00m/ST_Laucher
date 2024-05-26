using DynamicData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_Lc2.laucherCore.tools
{
    public class SystemTools
    {
        public static IEnumerable<String> FindJava()
        {
            try {
                var rootReg = Registry.LocalMachine.OpenSubKey("SOFTWARE");
                return rootReg == null ?
                    new string[0]
                    : FindJavaInternal(rootReg);
            }
            catch { 
                    return new string[0];
            }
        }
        public static IEnumerable<string> FindJavaInternal(RegistryKey registry)
        {
            try
            {
                var registryKey = registry.OpenSubKey("JavaSoft");
                var registryKey1 = registry.OpenSubKey("JavaSoft");
                var registryKey2 = registry.OpenSubKey("JavaSoft");
                var registry1 = registry;
                var registry2 = registry;
                //打开子表
                if (registryKey != null)
                {
                    if (registryKey1.OpenSubKey("Java Runtime Environment") == null &&  registryKey2.OpenSubKey("JDK") == null) return new string[0];
                    else
                    {
                        registry1 = registryKey1.OpenSubKey("Java Runtime Environment");
                        registry2 = registryKey2.OpenSubKey("JDK");
                        Debug.WriteLine(registry1);
                        Debug.WriteLine(registry2);
                    }
                }
                else
                {
                    return new string[0];
                }
               var below1_8 = from ver in registry1.GetSubKeyNames()
                              select registry1.OpenSubKey(ver)
               into command
                              where command != null
                              select command.GetValue("JavaHome")
               into javaHomes
                              where javaHomes != null
                              select javaHomes.ToString()
               into str
                              where !String.IsNullOrWhiteSpace(str)
                              select str + @"\bin\javaw.exe";
              var up1_8 = from ver in registry2.GetSubKeyNames()
                              select registry2.OpenSubKey(ver)
               into command
                              where command != null
                              select command.GetValue("JavaHome")
               into javaHomes
                              where javaHomes != null
                              select javaHomes.ToString()
               into str
                              where !String.IsNullOrWhiteSpace(str)
                              select str + @"\bin\javaw.exe";


                return below1_8.Union(up1_8);
            }

            catch
            {
                return new string[0];
            }
        }
    }
}
