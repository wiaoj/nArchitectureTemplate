using System.Security.Cryptography;
using System.Text;

namespace Core.Security.Hashing;

public class HashingHelper {
    public static void CreatePasswordHash(String password, out Byte[] passwordHash, out Byte[] passwordSalt) {
        using HMACSHA512 hmac = new();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash(String password, Byte[] passwordHash, Byte[] passwordSalt) {
        using(HMACSHA512 hmac = new(passwordSalt)) {
            Byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for(int i = 0; i < computedHash.Length; ++i)
                if(computedHash[i] != passwordHash[i]) //TODO passWordHash !=
                    return false;
        }
        return true;
    }
}