using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Resumere.TonkaBean.Utils
{
    public sealed class SecureUtils
    {
        public static string GetSecureStringValue(SecureString value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (!value.IsReadOnly())
            {
                throw new ArgumentException("SecureString must be read only.", "value");
            }
            IntPtr ustr = IntPtr.Zero;
            try
            {
                ustr = Marshal.SecureStringToBSTR(value);
                return Marshal.PtrToStringBSTR(ustr);
            }
            finally
            {
                Marshal.FreeBSTR(ustr);
            }
        }

        public static SecureString CreateSecureString(string value)
        {
            SecureString result = new SecureString();
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    foreach (char c in value)
                    {
                        result.AppendChar(c);
                    }
                }
            }
            finally
            {
                result.MakeReadOnly();
            }
            return result;
        }

    }
}
