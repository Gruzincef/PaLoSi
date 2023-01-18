/*
 * Создано в SharpDevelop.
 * Пользователь: АРМ162
 * Дата: 19.09.2019
 * Время: 9:25
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Net.Security;
/*
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
*/
namespace PaLoSi
{
	/// <summary>
	/// Description of WebQuery.
	/// </summary>
public class WebQuery{
public WebQuery(){
				System.Net.ServicePointManager.ServerCertificateValidationCallback +=  (sender, cert, chain, sslPolicyErrors) => true;
}
		
//FirefoxDriver firefox;
HttpWebRequest myHttpWebRequest;
HttpWebResponse myHttpWebResponse;

public string[] GetQyery(string http, string AdresProxi,int PortProxy,string SetCookie){
	try{	
		string [] resultPage = new string[2];
		System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		myHttpWebRequest = (HttpWebRequest)WebRequest.Create(http);
		myHttpWebRequest.Proxy = new WebProxy(AdresProxi+":"+PortProxy,true);
		myHttpWebRequest.UserAgent = "Mozila/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;";
		myHttpWebRequest.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
		myHttpWebRequest.Headers.Add("Accept-Language", "ru");
		myHttpWebRequest.ContentType = @"text/html; charset=windows-1251";

		if(myHttpWebResponse!=null)
		if(SetCookie!=null){
			 myHttpWebRequest.Headers.Add(HttpRequestHeader.Cookie, SetCookie);
		}
		myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
		resultPage[0] = "";
		if (!String.IsNullOrEmpty(myHttpWebResponse.Headers["Set-Cookie"]))  resultPage[0] = myHttpWebResponse.Headers["Set-Cookie"];
		using (StreamReader sr = new StreamReader(myHttpWebResponse.GetResponseStream(), Encoding.UTF8, true)){
			resultPage[1] = sr.ReadToEnd();
			sr.Close();
		}
		return resultPage;
	}catch (WebException err){
		return null;
	}
}

public string[] GetQyery(string http,string SetCookie){
try{	
		string [] resultPage = new string[2];
		System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		ServicePointManager.Expect100Continue = true;
		ServicePointManager.DefaultConnectionLimit = 9999;
		//ServicePointManager.ServerCertificateValidationCallback +=   new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => { return true; });
		//ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;
		ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
		//ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		myHttpWebRequest = (HttpWebRequest)WebRequest.Create(http);
		myHttpWebRequest.Credentials = CredentialCache.DefaultCredentials;
		myHttpWebRequest.UserAgent = "Mozila/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;";
		myHttpWebRequest.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
		myHttpWebRequest.Headers.Add("Accept-Language", "utf-8");
	
		//myHttpWebRequest.ContentType = @"text/html; charset=windows-1251";
		myHttpWebRequest.KeepAlive = false;
       // myHttpWebRequest.ProtocolVersion = HttpVersion.Version11;
       // myHttpWebRequest.Timeout = 1000;
		if(myHttpWebResponse!=null)
		if(SetCookie!=null){
			 myHttpWebRequest.Headers.Add(HttpRequestHeader.Cookie, SetCookie);
		}
		myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
		resultPage[0] = "";
		if (!String.IsNullOrEmpty(myHttpWebResponse.Headers["Set-Cookie"]))  resultPage[0] = myHttpWebResponse.Headers["Set-Cookie"];
		using (StreamReader sr = new StreamReader(myHttpWebResponse.GetResponseStream(), Encoding.UTF8, true)){
			resultPage[1] = sr.ReadToEnd();
			sr.Close();
		}
		return resultPage;
	}catch (WebException err){
		
		return null;
		
	}
}
/*
public string[] GetQyeryWebDriver(string http,string SetCookie){
string[] resultPage=new string[2];
try{	
	firefox = new FirefoxDriver();
	firefox.Navigate().GoToUrl(http);
	WebDriverWait wait = new WebDriverWait(firefox,TimeSpan.FromSeconds(60));
	resultPage[1] = firefox.PageSource;
	resultPage[0] ="";
	return resultPage;
	}catch (WebException err){
		
		return null;
		
	}
}
*/
 private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)   {
	if (error == System.Net.Security.SslPolicyErrors.None) {
		return true;
	}
	return false;
}

public bool LoadFile(string patch,string directory,string AdresProxi,int PortProxy,decimal max,decimal min){
	try{	
	if((max==0)&&(min==0)){
		WebClient client = new WebClient();
		client.Proxy= new WebProxy(AdresProxi, PortProxy);
   		client.DownloadFile(new Uri(patch), directory+"\\"+DateTime.Now.ToString("ss_fff")+System.IO.Path.GetFileName(patch));
		return true;
	}else{
		WebRequest webRequest=HttpWebRequest.Create(patch);
		webRequest.Method="HEAD";
		using(var webResponse=webRequest.GetResponse()){
			decimal size=Convert.ToDecimal(webResponse.Headers.Get("Content-Length"));
			size=Math.Ceiling(Convert.ToDecimal(size/1024));
			if(((size>=min)&&(size<=max))||((max==0)&&(size>=min))){
				WebClient client = new WebClient();
				client.Proxy= new WebProxy(AdresProxi, PortProxy);
   				client.DownloadFile(new Uri(patch), directory+"\\"+DateTime.Now.ToString("ss_fff")+System.IO.Path.GetFileName(patch));
				return true;	
			}	else return false;
		}
	}}catch (WebException err){
		return false;
	}
}

public bool LoadFile(string patch,string directory,decimal max,decimal min){
	try{
		WebClient client = new WebClient();		
		if((max==0)&&(min==0)){
			client.DownloadFile(new Uri(patch), directory+"\\"+DateTime.Now.ToString("ss_fff")+System.IO.Path.GetFileName(patch));
			return true;
		}else{
			WebRequest webRequest=HttpWebRequest.Create(patch);
			webRequest.Method="HEAD";
			using(var webResponse=webRequest.GetResponse()){
				decimal size=Convert.ToDecimal(webResponse.Headers.Get("Content-Length"));
				size=Math.Ceiling(Convert.ToDecimal(size/1024));
				if(((size>=min)&&(size<=max))||((max==0)&&(size>=min))){
					client.DownloadFile(new Uri(patch), directory+"\\"+DateTime.Now.ToString().Replace(':',' ').Replace('.',' ')+System.IO.Path.GetFileName(patch));
					return true;
				} else 	return false;		
			}
	}}catch (WebException err){
		
		return false;
		
	}
}

public string[] LoadSite(List<ListSites.ProxiPort> proxiPort,string loadHref, string GetCookie){
	string [] resload= new string[2];
	for(int i=0;i<proxiPort.Count;i++){
		resload=GetQyery(loadHref,proxiPort[i].proxi,proxiPort[i].port,GetCookie);
		if(resload!=null){ return resload; }
	}
	 return resload;
}

public string[] LoadSite(string loadHref, string GetCookie){
	return GetQyery(loadHref,GetCookie);
	}
	
}

}

