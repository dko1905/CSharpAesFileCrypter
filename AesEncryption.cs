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
    public AesCrypter(Tuple<byte[], byte[]> KeyAndIv)
    {
        myAes = new AesManaged();
        myAes.Key = KeyAndIv.Item1;
        myAes.IV = KeyAndIv.Item2;

        encryptor = myAes.CreateEncryptor(KeyAndIv.Item1, KeyAndIv.Item2);
        decryptor = myAes.CreateDecryptor(KeyAndIv.Item1, KeyAndIv.Item2);
    }

    public Stream Encrypt(Stream s)
    {
        CryptoStream cryptoStream = new CryptoStream(s, encryptor, CryptoStreamMode.Read);

        return cryptoStream;        
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

    public Stream Decrypt(Stream s)
    {
        CryptoStream cryptoStream = new CryptoStream(s, decryptor, CryptoStreamMode.Read);

        return cryptoStream;        
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

    static public Tuple<byte[], byte[]> GenerateNewKeyAndIV()
    {
        using (AesManaged myAse = new AesManaged())
        {
            Tuple<byte[], byte[]> keyAndIv;
            myAse.GenerateKey();
            myAse.GenerateIV();
            keyAndIv = Tuple.Create<byte[], byte[]>(myAse.Key, myAse.IV);
            return keyAndIv;
        }
    }
}

