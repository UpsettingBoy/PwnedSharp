using System;
using System.Threading.Tasks;
using System.Linq;

namespace PwnedSharp
{
    public class PasswordMeter
    {
        public static byte GetPasswordStrength(string passwd, bool checkPwned = true)
        {
            if (string.IsNullOrWhiteSpace(passwd))
                throw new ArgumentException("Password cannot be null or empty!", nameof(passwd));

            Task<bool> pwnedApi;
            if (checkPwned)
                pwnedApi = PwnedFactory.Instance[ProvidersEnum.HaveIBeenPwned].CheckPwnedPassword(passwd);

            ushort nCharacters = (ushort)passwd.Length;
            //ushort upperLetters = (ushort)
        }
    }
}
