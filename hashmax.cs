using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string logo = @"
 
                  |
                 |.|
                 |.|                    Hashmax      
                |\./|                   by Sahmeran      
                |\./|                         
.               |\./|               .                  
 \^.\          |\\.//|          /.^/         
  \--.|\       |\\.//|       /|.--/          
    \--.| \    |\\.//|    / |.--/            
     \---.|\    |\./|    /|.---/             
        \--.|\  |\./|  /|.--/                
           \ .\  |.|  /. /                   
 _ -_^_^_^_-  \ \\ // /  -_^_^_^_- _         
   - -/_/_/- ^_^/| |\^_^ -\_\_\- -           
             /_ / | \ _\
                  |
";
        Console.WriteLine(logo);

        Console.Write("Type the password you want to hash: ");
        string password = Console.ReadLine();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] salt = Encoding.UTF8.GetBytes("salt_value");

        SHA256 hashObject = SHA256.Create();
        byte[] hashBytes = hashObject.ComputeHash(ConcatenateByteArrays(passwordBytes, salt));

        string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        Console.WriteLine(hashedPassword);
    }

    static byte[] ConcatenateByteArrays(byte[] first, byte[] second)
    {
        byte[] result = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, result, 0, first.Length);
        Buffer.BlockCopy(second, 0, result, first.Length, second.Length);
        return result;
    }
}
