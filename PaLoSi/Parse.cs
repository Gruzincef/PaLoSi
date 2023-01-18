/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 29.02.2020
 * Время: 17:38
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using HtmlAgilityPack;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace PaLoSi
{
	/// <summary>
	/// Description of Pares.
	/// </summary>
public class Parse{
	public Parse(ListSites.Project prjct){
			Prjct=prjct;
			domen=GetDomain(Prjct.addresSite);
			www=GetWWW(Prjct.addresSite);
			if(domen!=null) domen=domen.Trim('/');
			nameThreading=Prjct.nameThreading;
			LoadHref=prjct.addresSite;
			http=GetHttp(prjct.addresSite);
			webQueryr =new WebQuery ();
			CountLoad=0;
	}
		
	private ListSites.Project Prjct;
	private string domen;
	private string http;
	private string www;
	private HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
	private string LoadHref;
	private string LoadCookie="";
	private string nameThreading;
	private int idCategory=0;
	private BLOCKINFO blockinfo=new BLOCKINFO();
	private HtmlNode Title;
	private int hierarchy;
	private WebQuery webQueryr;
	private int CountLoad;
	private MenegerEvent ME=MenegerEvent.getInstance();
	


public void SetLoadCookie(string loadcookie){
	LoadCookie=loadcookie;
}
public void SetIdCategory(int id){
	idCategory=id;
}
public void SetHierarchy(int hi){
	hierarchy=hi;
}
private string GetDomain(string url){
	string[] s=url.Split(new[]{'/'}, StringSplitOptions.RemoveEmptyEntries);
	string tmp;
	if(url.Contains("://")) tmp=s[1];
	else {
		if(s.Length>0) tmp=s[0];
		else return null;
	}
	if(tmp.IndexOf("www")==0) tmp=tmp.Substring(4,tmp.Length-4);
	return tmp;
}
private string GetHttp(string url){
	if(url.IndexOf("https://")==0)	return "https";
	else if(url.IndexOf("http://")==0)	return "http";
	else return "https";
}
private string GetWWW(string url){
	if((url.IndexOf("://www.")<9)&&(url.IndexOf("://www.")>0))	return "www.";
	else return "";
}
public void MessThreading(EVENT_TYPE messthreading){
	//messThreading=messthreading;
	}
	


public string SaveOzer(HtmlAgilityPack.HtmlDocument doc,string bloc, bool clearTeg){
	HtmlNodeCollection HrefAds;
	string s="";
	HrefAds = doc.DocumentNode.SelectNodes(bloc);
	if(HrefAds!=null){
		if(HrefAds.Count>0){
			for(int i=0; i<HrefAds.Count;i++)
				if(clearTeg)
					s+="<i"+i.ToString()+">"+System.Net.WebUtility.HtmlEncode(Regex.Replace(ClearText(HrefAds[i].InnerHtml), "<[^>]+>", string.Empty))+"</i"+i.ToString()+">";
			else s+="<i"+i.ToString()+">"+ClearText(System.Net.WebUtility.HtmlEncode(HrefAds[i].InnerHtml))+"</"+i.ToString()+">";
				return s;
		} else return null;
	} else return null;
}

private bool isFileNameValid(string fileName){
	if((fileName==null)||(fileName.IndexOfAny(Path.GetInvalidPathChars())!=-1)||(fileName.LastIndexOf('?')!=-1))
		return false;
	try {
		string ext = System.IO.Path.GetExtension(@fileName.Replace(" ", "%20")).ToLower();
		if((ext==null)||(ext=="")||(ext==".html")||(ext==".com")||(ext==".php")||(ext==".asp")||(ext==".js")||(ext==".htm")||(ext==".asp")) return false;
		else return true;
	}
	catch(NotSupportedException){
		return false;
	}
}

public bool SaveHref(string LoadCookie,HtmlAgilityPack.HtmlDocument doc,int idCategory, string domen, string Loadhref,string nameThreading,string ViewHref,int hierarchy){
	HtmlNodeCollection HrefAds;
	string Href;
	bool dcmnt=false;
	int idCategory1;
	int hierarchy1;
	List<string> query=new List<string>();
	string tmp="";
	string srt="";
	DataTable RdQr;
	HrefAds = doc.DocumentNode.SelectNodes(ViewHref);
	StringBuilder str1=new StringBuilder();
	string dateload=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").ToString();
	if(HrefAds!=null)
		for(int i=0; i<HrefAds.Count;i++){
		//if(messThreading==EVENT_TYPE.STOP) return false;
		//Проверяем наличие атрибутов у найденной гиперрсыки
			if(HrefAds[i].Attributes.Count>0)
			if(HrefAds[i].Attributes["href"]!=null){
				Href=HrefAds[i].Attributes["href"].Value;
				Href=HrefToHref(Href,Loadhref);
				 dcmnt=isFileNameValid(@Href);
			//Приводим гиперссылку к единому формату
				if(Href!=null){
			//Экранируем одинарные кавычки
					Href = Href.Replace(@"'", @" ");
					//Проверям наличие гиперссылки в БД, гиперссылку обрежим до "?" для гиперссылок содержащих get запрос и уменьшить id
					if(Href.IndexOf("?")>0)	RdQr=Save.SqlRead(nameThreading,"SELECT MIN(idCategory),MIN(hierarchy) FROM "+nameThreading+" WHERE Href LIKE '"+Href.Substring(0,Href.IndexOf("?"))+"%'  LIMIT 1");
					else  RdQr=Save.SqlRead(nameThreading,"SELECT idCategory,hierarchy FROM "+nameThreading+" WHERE Href LIKE '"+Href+"'  LIMIT 1");
					//Проверяем на наличие ошибки чтения БД
					if(RdQr!=null){
					//Проверяем на наличие записи в БД
					if((RdQr.Rows.Count>0)&&(RdQr.Rows[0][0].ToString().Length>0)){
						idCategory1=Convert.ToInt16(RdQr.Rows[0][0].ToString());
						hierarchy1=Convert.ToInt16(RdQr.Rows[0][1].ToString());
						//Если гиперссылка уже существует и находится в нижестоящем разделе меняем корневую директорию
							 if((idCategory1>idCategory)&&(hierarchy1>hierarchy))	tmp=" cookie='"+LoadCookie+"', idCategory="+idCategory+", hierarchy="+hierarchy;
						else if((idCategory1>idCategory)&&(hierarchy1<hierarchy))	tmp=" cookie='"+LoadCookie+"', idCategory="+idCategory;
						else if((idCategory1<idCategory)&&(hierarchy1<hierarchy))	tmp=" cookie='"+LoadCookie+"', hierarchy="+hierarchy;
						else tmp="";
						if(tmp.Length>5){
								//Подменяем запрос на внесение изменений категории 
								query.Add("UPDATE  "+nameThreading+" SET "+tmp+" where Href='"+Href+"'");
						}} else{
						//формируем запрос для записи в БД
						if(srt.LastIndexOf(Href)==-1) str1.Append("('"+dateload+"','"+LoadCookie+"',"+dcmnt+","+(hierarchy+1)+","+idCategory+",'"+Href+"','"+Regex.Replace(HrefAds[i].InnerHtml, "<[^>]+>", string.Empty).Replace(@"'", @" ")+"'),");
							}
						
					} else	if(srt.LastIndexOf(Href)==-1) str1.Append("('"+dateload+"','"+LoadCookie+"',"+dcmnt+","+(hierarchy+1)+","+idCategory+",'"+Href+"','"+Regex.Replace(HrefAds[i].InnerHtml, "<[^>]+>", string.Empty).Replace(@"'", @" ")+"'),");
	
			
				}
			}
		}
	if(str1.ToString().Length>0)
		query.Add("INSERT INTO "+nameThreading+" (dateload,cookie,document,hierarchy,idCategory,Href,txthref) values "+str1.ToString().Substring(0,str1.ToString().Length-1));
	if (query.Count>0)  
		Save.SqlQuery(nameThreading,query);
	srt="";
	query.Clear();
	return true; 
}
public string  ClearText(string txt){
	txt=txt.Replace("\t"," ");
	txt=txt.Replace("\n"," ");
	txt=txt.Replace("\r"," ");
	txt=txt.Replace("  "," ");
	return txt;
}
//public bool SaveHrefImg(string LoadCookie,HtmlAgilityPack.HtmlDocument doc, string domen, string Loadhref,string nameThreading,string ViewHref,int hierarchy){
public void SaveHrefImgInBD(string Href,string txthref){
	bool dcmnt=false;
	int idCategory1;
	int hierarchy1;
	List<string> query=new List<string>();
	Href=HrefToHreFile(Href);
	DataTable RdQr;
	dcmnt=isFileNameValid(@Href);
			//Приводим гиперссылку к единому формату
	if(Href!=null){
			//Экранируем одинарные кавычки
		Href = Href.Replace(@"'", @" ");
					//Проверям наличие гиперссылки в БД, гиперссылку обрежим до "?" для гиперссылок содержащих get запрос и уменьшить id
		if(Href.IndexOf("?")>0)	
			RdQr=Save.SqlRead(nameThreading,"SELECT MIN(idCategory),MIN(hierarchy) FROM "+nameThreading+" WHERE Href LIKE '"+Href.Substring(0,Href.IndexOf("?"))+"%'");
		else  RdQr=Save.SqlRead(nameThreading,"SELECT idCategory,hierarchy FROM "+nameThreading+" WHERE Href LIKE '"+Href+"'");
					//Проверяем на наличие ошибки чтения БД
		if(RdQr!=null){
					//Проверяем на наличие записи в БД
			if((RdQr.Rows.Count>0)&&(RdQr.Rows[0][0].ToString().Length>0)){
				idCategory1=Convert.ToInt16(RdQr.Rows[0][0].ToString());
				hierarchy1=Convert.ToInt16(RdQr.Rows[0][1].ToString());
				string tmp="";
						//Если гиперссылка уже существует и находится в нижестоящем разделе меняем корневую директорию
				 if((idCategory1>idCategory)&&(hierarchy1>hierarchy))	tmp=" cookie='"+LoadCookie+"', idCategory="+idCategory+", hierarchy="+hierarchy;
				else if((idCategory1>idCategory)&&(hierarchy1<hierarchy))	tmp=" cookie='"+LoadCookie+"', idCategory="+idCategory;
				else if((idCategory1<idCategory)&&(hierarchy1<hierarchy))	tmp=" cookie='"+LoadCookie+"', hierarchy="+hierarchy;
				else tmp="";
				if(tmp.Length>5){
								//Подменяем запрос на внесение изменений категории 
					query.Add("UPDATE  "+nameThreading+" SET "+tmp+" where Href='"+Href+"'");
				}} else
						//формируем запрос для записи в БД
					query.Add("INSERT INTO "+nameThreading+" (cookie,document,hierarchy,idCategory,Href,txthref) values ('"+LoadCookie+"',"+dcmnt+","+(hierarchy+1)+","+idCategory+",'"+Href+"','"+Regex.Replace(txthref, "<[^>]+>", string.Empty).Replace(@"'", @" ")+"')");
				} else query.Add("INSERT INTO "+nameThreading+" (document,hierarchy,idCategory,Href,txthref) values ("+dcmnt+","+(hierarchy+1)+","+idCategory+",'"+Href+"','"+Regex.Replace(txthref, "<[^>]+>", string.Empty).Replace(@"'", @" ")+"')");
					//сохраняем запрос					
	}
	if (query.Count>0)  Save.SqlQuery(nameThreading,query);
	query.Clear();
}
public bool SaveHrefImg(string Loadhref){
	HtmlNodeCollection HrefAds;
	string Href;
	
	bool dcmnt=false;
	int idCategory1;
	int hierarchy1;
	List<string> query=new List<string>();
	DataTable RdQr;
	HrefAds = doc.DocumentNode.SelectNodes("//img");
	if(HrefAds!=null)
		for(int i=0; i<HrefAds.Count;i++){
			if(HrefAds[i].Attributes.Count>0)
			if(HrefAds[i].Attributes["src"]!=null){
				Href=HrefAds[i].Attributes["src"].Value;
				SaveHrefImgInBD(Href,HrefAds[i].InnerHtml);
			}	
			if(HrefAds[i].Attributes["data-src"]!=null){
				string[] s=HrefAds[i].Attributes["data-src"].Value.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries);;
				for(int j=0;j<s.Length;j++)
					SaveHrefImgInBD(s[j],HrefAds[i].InnerHtml);
			}
			if(HrefAds[i].Attributes["srcset"]!=null){
				string[] s=HrefAds[i].Attributes["srcset"].Value.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries);;
				for(int j=0;j<s.Length;j++)
					SaveHrefImgInBD(s[j],HrefAds[i].InnerHtml);
			}
		}
	return true; 
}
public string HrefToHreFile(string Href){
	domen=domen.Trim('/');
	int j=Href.IndexOf("/");
	LoadHref=LoadHref.TrimEnd('/');
	Href=Href.Trim(' ');
	if((Href.IndexOf("http://")==0)||(Href.IndexOf("https://")==0)||(Href.IndexOf("https://www.")==0)||(Href.IndexOf("http://www.")==0))
		return Href;
	else if((Href.IndexOf("//"+domen)==0)||(Href.IndexOf("//www."+domen)==0))
		return http+":"+Href;
	else if(Href.IndexOf(domen)==0)
		return http+"://"+www+Href;
	else if(Href.IndexOf("//")==0)
		return http+"://"+www+domen+"/"+Href.TrimStart('/').Substring(1);
	else if(Href.IndexOf("/")==0)
		return http+"://"+www+domen+Href;
	else if(Href.Length==0)
  		return http+"://"+www+domen+"/";
	else if((Href.IndexOf("javascript")>0)||(Href.IndexOf("mailto:")>-1)||(Href.IndexOf("tel:")>-1))
		return null;
 	else return http+"://"+www+domen+"/"+Href;

}


public string HrefToHref(string Href){
	int j=Href.IndexOf("/");
	LoadHref=LoadHref.TrimEnd('/');
	Href=Href.Trim(' ');
	if((Href.IndexOf("http://")==0)||(Href.IndexOf("https://")==0)||(Href.IndexOf("https://www.")==0)||(Href.IndexOf("http://www.")==0))
		return Href;
	else if((Href.IndexOf("//"+domen)==0)||(Href.IndexOf("//www."+domen)==0))
		return http+":"+Href;
	else if(Href.IndexOf(domen)==0)
		return (http+"://"+www+Href);
	else if(Href.IndexOf("//")==0)
		return (http+"://"+www+domen+"/"+Href.TrimStart('/').Substring(1));
	else if(Href.IndexOf("/")==0)
		return http+"://"+www+domen+Href;
	else if(Href.Length==0)
  		return http+"://"+www+domen+"/";
	else if((Href.IndexOf("javascript")>0)||(Href.IndexOf("mailto:")>-1)||(Href.IndexOf("tel:")>-1))
		return null;
 	else if(Href.IndexOf("/")!=0) return http+"://"+www+domen+"/"+Href;
 		else return http+"://"+www+domen+"/"+Href;
	
}

public string HrefToHref(string Href,string starthref){
	starthref=starthref.Substring(0,starthref.LastIndexOf('/'));
	int j=Href.IndexOf("/");
	LoadHref=LoadHref.TrimEnd('/');
	Href=Href.Trim(' ');
	if(Href.Length>1){
	if((Href.IndexOf("http://")==0)||(Href.IndexOf("https://")==0)||(Href.IndexOf("https://www.")==0)||(Href.IndexOf("http://www.")==0))
		return Href;
	else if((Href.IndexOf("//"+domen)==0)||(Href.IndexOf("//www."+domen)==0))
		return http+":"+Href;
	else if(Href.IndexOf(domen)==0)
		return (http+"://"+www+Href);
	else if(Href.IndexOf("//")==0)
		return (http+"://"+www+domen+"/"+Href.TrimStart('/').Substring(1));
	else if(Href.IndexOf("/")==0)
		return http+"://"+www+domen+Href;
	else if(Href.Length==0)
  		return http+"://"+www+domen+"/";
	else if((Href.IndexOf("javascript")>0)||(Href.IndexOf("mailto:")>-1)||(Href.IndexOf("tel:")>-1))
		return null;
	else {
		if(starthref.IndexOf('/')==0)return starthref+Href;
		return starthref+"/"+Href;
	}} else return null;
	
}

public void Parsim(string ldHTML,string loadHref){
	string query;
	string tmp;
	doc.LoadHtml(ldHTML);
	CountLoad++;
	ME.SetEvent(EVENT_TYPE.MESSEG,"Processing "+loadHref,Prjct.nameProject,nameThreading);
	Title = doc.DocumentNode.SelectSingleNode("//title");
   	if(Title!=null){
		query="UPDATE  "+nameThreading+" SET cookie='"+LoadCookie+"', title='"+Regex.Replace(Title.InnerHtml, "<[^>]+>", string.Empty).Replace(@"'", @" ")+"' WHERE href='"+loadHref+"'";
		Save.SqlQuery(nameThreading, query);
	}
	query="UPDATE  "+nameThreading+" SET get="+SaveHref(LoadCookie,doc,idCategory,domen,loadHref,nameThreading,Prjct.ViewHref,hierarchy).ToString()+", error=false where Href='"+loadHref+"'";
	Save.SqlQuery(nameThreading, query);
	string s="";
	string bloc="";
	for(int i=0;i<Prjct.blocInfo.Count;i++){
		bloc="//"+Prjct.blocInfo[i].boxTeg.ToString()+" [@"+Prjct.blocInfo[i].boxType.ToString()+"='"+Prjct.blocInfo[i].nameClass.ToString()+"']";
		tmp=SaveOzer(doc,bloc.ToLower(),Prjct.blocInfo[i].clearTeg);
		if(tmp!=null)
			s=s+"<"+Prjct.blocInfo[i].nameInfoBlock+">"+tmp+"</"+Prjct.blocInfo[i].nameInfoBlock+">";
	}
	if(s.Length>1){
		s="<bloc>"+s+"</bloc>";
		query="UPDATE  "+nameThreading+" SET xml='"+s+"', error=false where Href='"+loadHref+"'";
		Save.SqlQuery(nameThreading, query);
	}
	if(Prjct.loadIntegratedImg){
		query="UPDATE  "+nameThreading+" SET get="+SaveHrefImg(ldHTML).ToString()+", error=false where Href='"+loadHref+"'";
		Save.SqlQuery(nameThreading, query);
	}

	
}
	


	}
}
