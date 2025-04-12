using System.Security.Cryptography;
using System.Text;

namespace Lans.Core.Security;

public static class PasswordHelpers
{
    public static string EncodePasswordMD5(string pass)
    {
        byte[] originalBytes;
        byte[] encodedBytes;

        MD5 md5 = MD5.Create();

        originalBytes = ASCIIEncoding.Default.GetBytes(pass);
        encodedBytes = md5.ComputeHash(originalBytes);

        return BitConverter.ToString(encodedBytes);
    }
}
