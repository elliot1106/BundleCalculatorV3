using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace BundleCalculatorV3.Utility
{
    public static class IniHelper
    {

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
        private static string iniFilename = Directory.GetCurrentDirectory() + "\\Config.ini";

        /// <summary>
        /// read all the sections in Config.ini
        /// </summary>
        /// <returns>List{``0}</returns>
        public static List<string> ReadSections()
        {
            List<string> result = new List<string>();

            if (!File.Exists(iniFilename))
            {
                throw new FileNotFoundException(iniFilename);
            }
            try
            {
                Byte[] buf = new Byte[65536];
                int len = GetPrivateProfileString(null, null, null, buf, buf.Length, iniFilename);
                int j = 0;
                for (int i = 0; i < len; i++)
                {
                    if (buf[i] == 0)
                    {
                        result.Add(Encoding.Default.GetString(buf, j, i - j));
                        j = i + 1;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return result;
            }
        }

        /// <summary>
        /// read all the keys in the one section
        /// </summary>
        /// <param name="SectionName">section name in ini file</param>
        /// <returns>List{``0}</returns>
        public static List<string> ReadKeys(string SectionName)
        {
            List<string> result = new List<string>();
            try
            {
                Byte[] buf = new Byte[65536];
                int len = GetPrivateProfileString(SectionName, null, null, buf, buf.Length, iniFilename);
                int j = 0;
                for (int i = 0; i < len; i++)
                    if (buf[i] == 0)
                    {
                        result.Add(Encoding.Default.GetString(buf, j, i - j));
                        j = i + 1;
                    }
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return result;
            }

        }

        /// <summary>
        /// read the value of one key in one section
        /// </summary>
        /// <param name="SectionName"> section name in ini file</param>
        /// <param name="KeyName">key name in one section</param>
        /// <returns></returns>
        public static string ReadValue(string SectionName, string KeyName)
        {
            string result = string.Empty;
            try
            {
                Byte[] buf = new Byte[65536];
                int len = GetPrivateProfileString(SectionName, KeyName, null, buf, buf.Length, iniFilename);
                result = Encoding.Default.GetString(buf, 0, len);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;
            }
        }
    }
}
