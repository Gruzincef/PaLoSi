/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 02.05.2020
 * Время: 13:59
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Reflection;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace PaLoSi{
	/// <summary>
	/// Description of RsaWithCspKey.
	/// </summary>
public class RsaWithCspKey{
	public RsaWithCspKey(){
		}
		
const string ContainerName = "MyContainer";
public void AssignNewKey1(){
	CspParameters cspParams = new CspParameters(1);
	cspParams.KeyContainerName = ContainerName;
	cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
	cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
	var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = true };
}
public void DeleteKeyInCsp(){
	var cspParams = new CspParameters { KeyContainerName = ContainerName };
	var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = false };
	rsa.Clear();                         
}
public byte[] EncryptData(byte[] dataToEncrypt){
	byte[] cipherbytes;
	var cspParams = new CspParameters { KeyContainerName = ContainerName };
	using (var rsa = new RSACryptoServiceProvider(2048, cspParams)){
		cipherbytes = rsa.Encrypt(dataToEncrypt, false);
	}
	return cipherbytes;
}
public byte[] DecryptData(byte[] dataToDecrypt){
	byte[] plain;
	var cspParams = new CspParameters { KeyContainerName = ContainerName };
	using (var rsa = new RSACryptoServiceProvider(2048, cspParams)) {                               
		plain = rsa.Decrypt(dataToDecrypt, false);
	}
	return plain;
}

public static RSAParameters _publicKey;
public static RSAParameters _privateKey;

public static string CryptoKey(string key){
	RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(2048);
	rsa.FromXmlString(File.ReadAllText("spu.bin"));
	_publicKey=rsa.ExportParameters(false);
	return BitConverter.ToString(rsa.Encrypt(Encoding.Default.GetBytes(key),true));
}
private static byte[] DeBitconvert(string s){
	string[] ss=s.Split('-');
	byte[] array=new byte[ss.Length];
	for(int i=0;i<ss.Length;i++) array[i]=Convert.ToByte(ss[i],16);
	return array;
}

public static string DecryptoKey(string key){
	RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(2048);
	rsa.FromXmlString(File.ReadAllText("kpr.bin"));
	_privateKey=rsa.ExportParameters(true);
	byte[] s=Encoding.Default.GetBytes(key);
	Encoding encoding=Encoding.Default;
	
	return encoding.GetString(rsa.Decrypt(DeBitconvert(key),true));
}
public byte[] SignData(byte[] hashOfDataToSign){
	using (var rsa = new RSACryptoServiceProvider(2048)){
		rsa.PersistKeyInCsp = false;
		rsa.ImportParameters(_privateKey);
		var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);                
 		rsaFormatter.SetHashAlgorithm("SHA256");
 		return rsaFormatter.CreateSignature(hashOfDataToSign);
	}
}
public bool VerifySignature(byte[] hashOfDataToSign, byte[] signature){
	using (var rsa = new RSACryptoServiceProvider(2048)){
		rsa.ImportParameters(_publicKey);
		var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
		rsaDeformatter.SetHashAlgorithm("SHA256");
		return rsaDeformatter.VerifySignature(hashOfDataToSign, signature);
	}
}   
    
}
}

	




