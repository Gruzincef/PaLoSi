/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 04.03.2020
 * Время: 20:40
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Threading;
using System.Data;
using System.IO;
using HtmlAgilityPack;
using Jint;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;


namespace PaLoSi
{
	/// <summary>
	/// Description of StartLoad.
	/// </summary>
public class StartLoad : Threaders{
	public StartLoad(){	
		}
	public StartLoad(ListSites.Project prjct){
		Prs=new Parse(prjct);
		Prjct=prjct;
		nameThreading=Prjct.nameThreading;
		time=0;
		loadHref=Prs.HrefToHref(prjct.addresSite);
		CountLoad=0;
	}
		
	public StartLoad(ListSites.Project prjct,int tm){
		Prs=new Parse(prjct);
		Prjct=prjct;
		time=tm;
		nameThreading=Prjct.nameThreading;
		loadHref=Prs.HrefToHref(prjct.addresSite);
		CountLoad=0;
	}
		
	private ListSites.Project Prjct=new ListSites.Project();
	private Parse Prs;
	public Thread Threading;
	public EVENT_TYPE StatusThreading= new EVENT_TYPE();
	public EVENT_TYPE MessThreading= new EVENT_TYPE();
	public int CountLoad;
	private string loadHref;
	private int idCategory;
	private int hierarchy;
	private string nameThreading;
	private string GetCookie;
	private DataTable RdQr;
	private int time=0;	
	private string query;
	private string dateload;
	public EventWaitHandle ewh=new System.Threading.ManualResetEvent(false);
		//Событие отправки сообщений в форму
	//private event OperationDelegate Event_Messeg;
	public delegate void OperationDelegate(MessegTask mess);
	private MenegerEvent ME=MenegerEvent.getInstance();
public void Load(){
	string[] res=new string[2];
	ME.SetEvent(EVENT_TYPE.START,"Starting to download "+Prjct.addresSite,Prjct.nameProject,Prjct.nameThreading);
	dateload=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").ToString();
	RdQr=Save.SqlRead(nameThreading,"SELECT href,id,hierarchy,cookie FROM "+nameThreading+" WHERE  Href='"+loadHref+"' LIMIT 1");
	if(RdQr.Rows.Count>0) query="UPDATE  "+nameThreading+" SET get=false, error=false where Href='"+loadHref+"'";
	else query="INSERT INTO "+nameThreading+" (idCategory,hierarchy,Href,title,dateload) values (0,0,'"+loadHref+"','Главная','"+dateload+"')";
	Save.SqlQuery(nameThreading, query);	
	RdQr=Save.SqlRead(nameThreading,"SELECT href,id,hierarchy,cookie FROM "+nameThreading+" WHERE get=false AND error=false AND document=false  ");
	int error=0;
	bool bl=false;
	int maxload=21;
	if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin")){
		bl=true;
	} else if(!Work.Licens(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin", Encoding.Default))){
		bl=true;
	} else {
		bl=false;
	}
	if(RdQr.Rows.Count>=maxload) maxload=0;
	while((RdQr.Rows.Count>0)&&(MessThreading!=EVENT_TYPE.STOP)){
		
		if(bl)
			maxload--;
		if(maxload<1) 
			break;
		loadHref=RdQr.Rows[0][0].ToString();
		idCategory=Convert.ToInt16(RdQr.Rows[0][1].ToString());
		hierarchy=Convert.ToInt16(RdQr.Rows[0][2].ToString());
		GetCookie=RdQr.Rows[0][3].ToString();
	//Загружаем страницу
		ME.SetEvent(EVENT_TYPE.STARTLOAD,"Loading the page "+loadHref,Prjct.nameProject,Prjct.nameThreading);
		if(Prjct.proxiPort.Count>0)	res=wbQrr.LoadSite(Prjct.proxiPort,loadHref,GetCookie);
		else res=wbQrr.LoadSite(loadHref,GetCookie);
		//else res=wbQrr.GetQyeryWebDriver(loadHref,GetCookie);
		if(res==null){
			error++;
			Save.SqlQuery(nameThreading, "UPDATE  "+nameThreading+" SET get=false, error=true where Href='"+loadHref+"'");
			ME.SetEvent(EVENT_TYPE.ERRORLOAD,"Page loading error "+loadHref,Prjct.nameProject,Prjct.nameThreading);
		} else
		if((res[1]==null)||(res[1].LastIndexOf(Prjct.errorLoad)>-1)||(res[1].ToLower().LastIndexOf("html")<0)){
			error=0;
			//Ошибка загрузки страницы
			Save.SqlQuery(nameThreading, "UPDATE  "+nameThreading+" SET get=false, error=true where Href='"+loadHref+"'");
			ME.SetEvent(EVENT_TYPE.ERRORLOAD,"Page loading error "+loadHref,Prjct.nameProject,Prjct.nameThreading);
		} else {
		error=0;
		CountLoad++;
		GetCookie=res[0];
		Prs.SetIdCategory(idCategory);
		Prs.SetHierarchy(hierarchy);
		Prs.SetLoadCookie(GetCookie);
		Prs.Parsim(res[1],loadHref);
		if(Prjct.listLoadFile.Count>0)	StartLoadFile();
		}
		string tmp="SELECT Href,id,hierarchy,cookie FROM "+nameThreading+" WHERE get=false AND error=false AND document=false AND Href LIKE '%"+Prjct.addresSite+"%'  LIMIT 1";
		if(Prjct.immersionDepth==0) RdQr=Save.SqlRead(nameThreading,tmp);
		else RdQr=Save.SqlRead(nameThreading,"SELECT Href,id,hierarchy,cookie FROM "+nameThreading+" WHERE get=false AND error=false AND document=false AND hierarchy<="+Prjct.immersionDepth+" AND Href LIKE '%"+Prjct.addresSite+"%'  LIMIT 1");
		if(((RdQr.Rows.Count==0)&&(CountLoad<2))||((error>3)&&(CountLoad==0))){
			MessThreading=EVENT_TYPE.ERROR;
			StatusThreading=EVENT_TYPE.ERROR;
			ME.SetEvent(EVENT_TYPE.ERROR,"Upload error, not a valid website adress or cannot access the Internet ",Prjct.nameProject,nameThreading);
			break;
		}
	}
	if(MessThreading==EVENT_TYPE.STOP)	ME.SetEvent(EVENT_TYPE.STOP,"Stopping the download "+Prjct.nameProject,Prjct.nameProject,nameThreading);	
	else {
		if(CountLoad==0) ME.SetEvent(EVENT_TYPE.ERRORLOAD,"Loading error "+Prjct.nameProject,Prjct.nameProject,nameThreading);
		else if(CountLoad>2) ME.SetEvent(EVENT_TYPE.END,"Download completed "+Prjct.nameProject,Prjct.nameProject,nameThreading);
		if(Prjct.theFrequencyOf>0){
			ewh=new EventWaitHandle(true, EventResetMode.AutoReset);
			if(Prjct.AllLoad) StatusThreading=EVENT_TYPE.NEW;
			if(!Prjct.AllLoad) StatusThreading=EVENT_TYPE.RESUME;
			MessThreading=EVENT_TYPE.START;
			ewh=new System.Threading.ManualResetEvent(false);
			ewh.WaitOne(new TimeSpan(0,Prjct.theFrequencyOf,0));
			CountLoad=0;
			StartTheadLoad();
		}
	}
	if(Work.StrtLd.ContainsKey(nameThreading)) 	Work.StrtLd.Remove(nameThreading);
		
}
public void StartTheadLoad(){
		if(StatusThreading==EVENT_TYPE.START){
			StatusThreading=EVENT_TYPE.START;
		if(Save.VerifyBD(nameThreading)){
			StatusThreading=EVENT_TYPE.WORK;
			MessThreading=EVENT_TYPE.WORK;
			ME.SetEvent(EVENT_TYPE.EXISTS,"Start of download "+Prjct.nameProject,Prjct.nameProject,nameThreading);
			Threading=StartThead(Load);
		}else{
			StatusThreading=EVENT_TYPE.STOP;
			MessThreading=EVENT_TYPE.STOP;
			ME.SetEvent(EVENT_TYPE.EXISTS,"The database exists "+Prjct.nameProject,Prjct.nameProject,nameThreading);
		}}
	if(StatusThreading==EVENT_TYPE.NEW){
		StatusThreading=EVENT_TYPE.WORK;
		MessThreading=EVENT_TYPE.WORK;
		Save.DeleteBD(nameThreading);
		Save.VerifyBD(nameThreading);
		Threading=StartThead(Load);
	}
	if(StatusThreading==EVENT_TYPE.RESUME){
		StatusThreading=EVENT_TYPE.WORK;
		MessThreading=EVENT_TYPE.WORK;
		Save.VerifyBD(nameThreading);
		Threading=StartThead(Load);
	}
}
public void StartLoadFile(){
	string query;//Строка запроса
	string GetCookie="";
	string proxi="";
	int port=-1;
	BLOCKINFO blockinfo=new BLOCKINFO();
	DataTable RdQr;
	string[] resload=new string[2];
	//int hierarchy=0;
	bool res=false;
	int idCategory;
	string loadHref;
	RdQr=Save.SqlRead(nameThreading,"SELECT href,cookie,idCategory FROM "+nameThreading+" WHERE get=false AND error=false AND document=true  LIMIT 1");
	while((RdQr.Rows.Count>0)&&(MessThreading!=EVENT_TYPE.STOP)){
		loadHref=RdQr.Rows[0][0].ToString();
		GetCookie=RdQr.Rows[0][1].ToString();
		idCategory=Convert.ToInt16(RdQr.Rows[0][2].ToString());
		if(Prjct.proxiPort.Count==0){
			res=LoadFile(loadHref, idCategory, Prjct);
		} else if((Prjct.proxiPort.Count>0)&&((proxi.Length==0))){
			for(int i=0;i<Prjct.proxiPort.Count;i++){
				res=LoadFile(loadHref, idCategory, Prjct,Prjct.proxiPort[0].proxi,Prjct.proxiPort[0].port);
				if(res){ 
					proxi=Prjct.proxiPort[0].proxi;
					port=Prjct.proxiPort[0].port;
					break;
				}
			}
		}else if((Prjct.proxiPort.Count>0)&&((proxi.Length>0))){
			res=LoadFile(loadHref, idCategory,Prjct, proxi,port);
			if(!res){
				for(int i=0;i<Prjct.proxiPort.Count;i++)
					res=LoadFile(loadHref, idCategory, Prjct,Prjct.proxiPort[0].proxi,Prjct.proxiPort[0].port);
				if(res){
					proxi=Prjct.proxiPort[0].proxi;
					port=Prjct.proxiPort[0].port;
					break;
				}
			}
		}
		query="UPDATE  "+nameThreading+" SET get='"+res.ToString()+"' , error='"+(!res).ToString()+"' where Href='"+loadHref+"'";
		Save.SqlQuery(nameThreading, query);
		RdQr=Save.SqlRead(nameThreading,"SELECT href,cookie,idCategory FROM "+nameThreading+" WHERE get=false AND error=false AND document=true  LIMIT 1");
		}
	}
	

public bool LoadFile(string fileName, int idCategory,ListSites.Project project,string AdresProxi,int PortProxy ){
	DataTable RdQr;
	string title;
	string dr="";
	if(project.DirSaveImg=="id pages") dr=idCategory.ToString()+"\\";
	if(project.DirSaveImg=="Name of the placement page"){
		RdQr=Save.SqlRead(project.nameThreading,"SELECT title  FROM "+project.nameThreading+" WHERE id="+idCategory.ToString()+" LIMIT 1");
		title=RdQr.Rows[0][0].ToString()+"\\";
		if(title!=null)	dr=title+"\\";
		else dr="none\\";
	}
	string ext = System.IO.Path.GetExtension(@fileName.Replace(" ", "%20"));
	for(int i=0;i<project.listLoadFile.Count;i++)
		if(ext.ToLower()=="."+project.listLoadFile[i].ToString().ToLower()){
		if(!Directory.Exists(project.PathLoadIMG)){
			ME.SetEvent(EVENT_TYPE.ERRORLOADFILE,"Not the correct path for saving files "+fileName,project.nameProject,project.nameThreading);
			MessThreading=EVENT_TYPE.STOP;
			return false;
		}
		if(Directory.Exists(project.PathLoadIMG)){
			if(!Directory.Exists(project.PathLoadIMG+"\\"+dr))Directory.CreateDirectory(project.PathLoadIMG+"\\"+dr);
			ME.SetEvent(EVENT_TYPE.STARTLOAD,"Uploading a file "+fileName,project.nameProject,project.nameThreading);
			return wbQrr.LoadFile(fileName,project.PathLoadIMG+"\\"+dr,AdresProxi,PortProxy,project.MaxFileSize,project.MinFileSize);
		   } else {
			ME.SetEvent(EVENT_TYPE.ERRORLOADFILE,"There is no directory to save ",project.nameProject,project.nameThreading);
			return false;
		   }
	}
	return true;
}
public bool LoadFile(string fileName, int idCategory,ListSites.Project project){
	DataTable RdQr;
	string title;
	string dr="";
	if(project.DirSaveImg=="id pages") dr=idCategory.ToString()+"\\";
	if(project.DirSaveImg=="Name of the placement page"){
		RdQr=Save.SqlRead(project.nameThreading,"SELECT title  FROM "+project.nameThreading+" WHERE id="+idCategory.ToString()+" LIMIT 1");
		title=RdQr.Rows[0][0].ToString()+"\\";
		if(title!=null)	dr=title+"\\";
		else dr="none\\";
	}
	string ext = System.IO.Path.GetExtension(@fileName.Replace(" ", "%20"));
	for(int i=0;i<project.listLoadFile.Count;i++)
		if(ext.ToLower()=="."+project.listLoadFile[i].ToString().ToLower()){
		if(!Directory.Exists(project.PathLoadIMG)){
			ME.SetEvent(EVENT_TYPE.ERRORLOADFILE,"Not the correct path for saving files "+fileName,project.nameProject,project.nameThreading);
			MessThreading=EVENT_TYPE.STOP;
			return false;
		}
		if(Directory.Exists(project.PathLoadIMG)){
		if(!Directory.Exists(project.PathLoadIMG+"\\"+dr))Directory.CreateDirectory(project.PathLoadIMG+"\\"+dr);
		ME.SetEvent(EVENT_TYPE.STARTLOAD,"Uploading a file "+fileName,project.nameProject,project.nameThreading);
		return wbQrr.LoadFile(fileName,project.PathLoadIMG+"\\"+dr,project.MaxFileSize,project.MinFileSize);
		} else {
			ME.SetEvent(EVENT_TYPE.ERRORLOADFILE,"There is no directory to save ",project.nameProject,project.nameThreading);
			return false;
		   }
	}
	return true;

}
	
public void Abort(){
	if(Threading!=null)
	if (Threading.IsAlive){
		StatusThreading=EVENT_TYPE.STOP;
		MessThreading=EVENT_TYPE.STOP;
		ewh.Set();
		//Threading.Abort();
		ME.SetEvent(EVENT_TYPE.STOP,"Downloads stop ",Prjct.nameProject,nameThreading);
	}
}
/*****************************/
	}
}
