using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;

public class AesCrypter
{
    public Tuple<byte[], byte[]> KeyAndIv;
    AesManaged myAes;
    ICryptoTransform encryptor;
    ICryptoTransform decryptor;
    public AesCrypter()
    {
        KeyAndIv = Tuple.Create<byte[], byte[]>(File.ReadAllBytes("key"), File.ReadAllBytes("iv"));
        myAes = new AesManaged();
        myAes.Key = KeyAndIv.Item1;
        myAes.IV = KeyAndIv.Item2;

        encryptor = myAes.CreateEncryptor(KeyAndIv.Item1, KeyAndIv.Item2);
        decryptor = myAes.CreateDecryptor(KeyAndIv.Item1, KeyAndIv.Item2);

    }

    public MemoryStream Encrypt(Stream s)
    {
        CryptoStream cryptoStream = new CryptoStream(s, encryptor, CryptoStreamMode.Read);
        MemoryStream output = new MemoryStream();

        cryptoStream.CopyTo(output);
        return output;        
    }

    public byte[] Encrypt(byte[] inputBytes) // key and iv is in myAes
    {
        using (MemoryStream input = new MemoryStream(inputBytes))
        using (CryptoStream cryptoStream = new CryptoStream(input, encryptor, CryptoStreamMode.Read))
        using (MemoryStream output = new MemoryStream())
        {
            cryptoStream.CopyTo(output);
            return output.ToArray();
        }
    }

    public MemoryStream Decrypt(Stream s)
    {
        CryptoStream cryptoStream = new CryptoStream(s, decryptor, CryptoStreamMode.Read);
        MemoryStream output = new MemoryStream();

        cryptoStream.CopyTo(output);
        return output;        
    }

    public byte[] Decrypt(byte[] inputBytes)
    {
        using (MemoryStream input = new MemoryStream(inputBytes))
        using (CryptoStream cryptoStream = new CryptoStream(input, decryptor, CryptoStreamMode.Read))
        using (MemoryStream output = new MemoryStream())
        {
            cryptoStream.CopyTo(output);
            return output.ToArray();
        }
    }

    static public void GenerateNewKeyAndIV()
    {
        using (AesManaged myAse = new AesManaged())
        {
            myAse.GenerateKey();
            myAse.GenerateIV();
            File.WriteAllBytes("key", myAse.Key);
            File.WriteAllBytes("iv", myAse.IV);
        }
    }


    
}

