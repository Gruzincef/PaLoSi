/*
 * Created by SharpDevelop.
 * User: Админ
 * Date: 05.01.2020
 * Time: 9:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace PaLoSi
{
	/// <summary>
	/// Description of ListSites.
	/// </summary>
	/// 	
public enum LOCATIONAMECLASS_TYPE{
	INPUT,
	OUTPUT
}

public enum BOXTYPE_TYPE{
	CLASS,
	ID	
}
public enum BOXTEG_TYPE{
	SPAN,
	DIV,
	TD,
	TR,
	TABLE,
	A,
	IMG,
	TITLE,
	HEAD,
	P,
	CENTER,
	FONT,
	H1,
	H2,
	H3,
	H4,
	H5,
	H6,
	H7	
}
public enum LISTLOADFILE_TYPE{
	JPEG,
	JPG,
	PNG,
	PNJ,
	PDF,
	DOC,
	DOCX,
	RAR,
	ZIP,
	XLS,
	XLSX,
	DJV,
	AVI,
	FLV,
	WMV,
	MP3,
	AU,	
}
	
public class ListSites{
//Глобальная переменная
public static Dictionary<string, Project> listSites= new Dictionary<string,Project>();


public struct ProxiPort{
	public string proxi;
	public int port;
}
public struct BlocInfo{		
	public string nameInfoBlock;
	public bool clearTeg;
	public LOCATIONAMECLASS_TYPE locationNameClass;
	public string nameClass;
	public BOXTYPE_TYPE boxType;
	public BOXTEG_TYPE boxTeg;
}

public struct Project{
	public string addresSite;
	public string nameProject;
	public string ViewHref;//Вид  гиперссылки
	public int theFrequencyOf; // Периодичность загрузки
	public int immersionDepth; //Глубина погружения
	public string pathAutoExport; //Путь автоматического импорта
	public List<string> nameBlocFileExportXML; //Структура файла импорта
	public string errorLoad;
	public bool loadIntegratedImg;
	public List<LISTLOADFILE_TYPE> listLoadFile;
	public List<BlocInfo> blocInfo;
	public List<ProxiPort> proxiPort;
	public bool StopOldLoad;
	public bool AllLoad;
	public string nameThreading;
	public string DirSaveImg;
	public string PathLoadIMG;
	public decimal MinFileSize;
	public decimal MaxFileSize;
}
	public List<string> nameBlocFileExportXML=new List<string>();
	public List<BlocInfo> listBlocInfo=new List<BlocInfo>();
	public List<ProxiPort> listProxiPort=new List<ProxiPort>();
	public List<LISTLOADFILE_TYPE> listLoadFile=new List<LISTLOADFILE_TYPE>();

	public ListSites(){
	}

public ProxiPort ConvertProxiPort(string proxiPort){
	proxiPort=proxiPort.Trim(' ').Replace(" ", string.Empty);
	ProxiPort proxiport=new ProxiPort();
	if(proxiPort.Length>7){
		if(proxiPort.LastIndexOf(":")!=-1){
			proxiport.proxi=proxiPort.Substring(0,proxiPort.LastIndexOf(":"));
			bool isInt=Int32.TryParse(proxiPort.Substring(proxiPort.LastIndexOf(":")+1,proxiPort.Length-1-proxiPort.LastIndexOf(":")), out proxiport.port);
			if(!isInt)proxiport.port=8080;
		}else{
			proxiport.proxi=proxiPort;
			proxiport.port=8080;
		}
	}	
	return proxiport;
}
public void AddlistProxiPort(string proxiPort){
	listProxiPort.Add(ConvertProxiPort(proxiPort));
}
public List<string> GetlistProxiPort(){
	List<string> s=new List<string>();
	for(int i=0;i<listProxiPort.Count;i++)
		s.Add(listProxiPort[i].proxi+":"+listProxiPort[i].port);
	return s;
}
	
public List<string> GetlistProxiPort(List<ProxiPort> proxiport){
	List<string> s=new List<string>();
	for(int i=0;i<proxiport.Count;i++)
		s.Add(proxiport[i].proxi+":"+proxiport[i].port);
	return s;
}
public void DellistProxiPort(int i){
	if(i>-1)
	listProxiPort.RemoveAt(i);
}
public void AddlistLoadFile(LISTLOADFILE_TYPE loadFile){
	listLoadFile.Add(loadFile);
}

public void AddlistBlocInfo(string nameInfoBlock, bool clearTeg, string locationNameClass, string nameClass, string boxType, string boxTeg){
	if((nameInfoBlock.Length>0)&&(locationNameClass.Length>0)&&(nameClass.Length>0)&&(boxType.Length>0)&&(boxTeg.Length>0)){
		BlocInfo blocInfo;
		blocInfo.nameInfoBlock=nameInfoBlock;
		blocInfo.clearTeg=clearTeg;
		blocInfo.locationNameClass=(LOCATIONAMECLASS_TYPE)Enum.Parse(typeof(LOCATIONAMECLASS_TYPE),locationNameClass);
		blocInfo.nameClass=nameClass;
		blocInfo.boxType= (BOXTYPE_TYPE)Enum.Parse(typeof(BOXTYPE_TYPE),boxType) ;
		blocInfo.boxTeg=(BOXTEG_TYPE)Enum.Parse(typeof(BOXTEG_TYPE),boxTeg);
		if(listBlocInfo.IndexOf(blocInfo)==-1)	listBlocInfo.Add(blocInfo);
	}
}
public List<string> GetlistBlocInfo(){
	List<string> s=new List<string>();
	for(int i=0;i<listBlocInfo.Count;i++)
		s.Add(listBlocInfo[i].nameInfoBlock);
	return s;
}
	
public List<string> GetlistBlocInfo(List<BlocInfo> blocinfo){
	List<string> s=new List<string>();
	for(int i=0;i<blocinfo.Count;i++)
		s.Add(blocinfo[i].nameInfoBlock);
	return s;
}
public void GetVarlistBlocInfo(int i,out string nameInfoBlock, out bool clearTeg,  out string locationNameClass,out  string nameClass,out string boxType,out string boxTeg){
	if(i>-1){
		nameInfoBlock=listBlocInfo[i].nameInfoBlock;
		clearTeg=listBlocInfo[i].clearTeg;
		locationNameClass=listBlocInfo[i].locationNameClass.ToString();
		nameClass=listBlocInfo[i].nameClass;
		boxType=listBlocInfo[i].boxType.ToString();
		boxTeg=listBlocInfo[i].boxTeg.ToString();
	}else{
		nameInfoBlock=null;
		clearTeg=true;
		locationNameClass=null;
		nameClass=null;
		boxType=null;
		boxTeg=null;		
	}
}

public void UpdatelistBlocInfo(int i,string nameInfoBlock, bool clearTeg, string locationNameClass, string nameClass, string boxType, string boxTeg){
		if((i>-1)&&(nameInfoBlock.Length>0)&&(locationNameClass.Length>0)&&(nameClass.Length>0)&&(boxType.Length>0)&&(boxTeg.Length>0)){
		BlocInfo blocInfo;
		blocInfo.nameInfoBlock=nameInfoBlock;
		blocInfo.clearTeg=clearTeg;
		blocInfo.locationNameClass=(LOCATIONAMECLASS_TYPE)Enum.Parse(typeof(LOCATIONAMECLASS_TYPE),locationNameClass);
		blocInfo.nameClass=nameClass;
		blocInfo.boxType= (BOXTYPE_TYPE)Enum.Parse(typeof(BOXTYPE_TYPE),boxType) ;
		blocInfo.boxTeg=(BOXTEG_TYPE)Enum.Parse(typeof(BOXTEG_TYPE),boxTeg);
		listBlocInfo.RemoveAt(i);
		listBlocInfo.Insert(i,blocInfo);
	}
}

public void DellistBlocInfo(int i){
	if(i>-1)
	listBlocInfo.RemoveAt(i);
}
	
public string ClearHref(string addresSite){
	addresSite=addresSite.Trim('/');
	int j=addresSite.IndexOf("/");
	addresSite=addresSite.Trim(' ');
	if(addresSite.IndexOf("http://")==0)  addresSite=addresSite.Substring(8,addresSite.Length-8);
	if(addresSite.IndexOf("https://")==0) addresSite=addresSite.Substring(9,addresSite.Length-9);
	return addresSite;	
}

public void AddListProject(int maxSizeFile,int minSizeFile,string DirSaveImg, string PathLoadIMG, bool stopoldload,string addresSite,  string nameProject,string ViewHref,int theFrequencyOf,int immersionDepth,string pathAutoExport, string errorLoad,bool loadIntegratedImg, List<string> listLoadFile,bool allload){
	ViewHref=ViewHref.Trim(' ').Replace(" ", string.Empty);//Вид гиперссылки+
	pathAutoExport=pathAutoExport.Trim(' ').Replace(" ", string.Empty); //Путь автоматического импорта
	addresSite=addresSite.Trim(' ').Replace(" ", string.Empty);
	addresSite=ClearHref(addresSite);
	nameProject=nameProject.Trim(' ').Replace("  ", " ");
	errorLoad=errorLoad.Trim(' ').Replace("  ", " ");
	
		if((addresSite.Length>0)&&(nameProject.Length>0)){
			Project project=new Project();
			project.addresSite=addresSite;
			project.nameProject=nameProject;
			project.errorLoad=errorLoad;
			project.loadIntegratedImg=loadIntegratedImg;
			project.listLoadFile=new List<LISTLOADFILE_TYPE>();
			project.ViewHref=ViewHref;
			project.StopOldLoad=stopoldload;
			
			project.nameBlocFileExportXML=new List<string>();
			project.nameBlocFileExportXML.Clear();
			project.nameBlocFileExportXML=nameBlocFileExportXML;


			project.immersionDepth=immersionDepth;
			project.theFrequencyOf=theFrequencyOf;
			project.pathAutoExport=pathAutoExport;
			project.nameThreading=Work.TransliterationType(nameProject);
			project.AllLoad=allload;
			project.DirSaveImg=DirSaveImg;
			project.PathLoadIMG=PathLoadIMG;
			project.MaxFileSize=maxSizeFile;
			project.MinFileSize=minSizeFile;
				
			//DirSaveImg; PathLoadIMG;
			for(int i=0;i<listLoadFile.Count;i++)
				project.listLoadFile.Add((LISTLOADFILE_TYPE)Enum.Parse(typeof(LISTLOADFILE_TYPE),listLoadFile[i]));
			if(listBlocInfo.Count>0){  
				project.blocInfo=new List<BlocInfo>();
				project.blocInfo.AddRange(listBlocInfo);
			}
			if(listProxiPort.Count>0){
				project.proxiPort=new List<ProxiPort>();
				project.proxiPort.AddRange(listProxiPort);
			}
			if(!listSites.ContainsValue(project)){
				listSites.Add(project.nameThreading,project);
				
				Save.SaveConfig(project,project.nameThreading);
			}
			listBlocInfo.Clear();
			listProxiPort.Clear();
			listLoadFile.Clear();
			nameBlocFileExportXML.Clear();
		}
	}
public void AddListProject(Project prjct){
	if(!listSites.ContainsValue(prjct)){
		listSites.Add(prjct.nameThreading,prjct);
		Save.SaveConfig(prjct,prjct.nameThreading);
	}
	
 listBlocInfo.Clear();
	listProxiPort.Clear();
	listLoadFile.Clear();
	nameBlocFileExportXML.Clear();
	LoadConfignameProject();
	
	
	//LoadConfig
}
public static void LoadConfig(string fil,MainForm f){
	Project prjct=new Project();
	object ob=new object();
	ob=Save.ReadCopyConfig(prjct,fil);
	if(ob!=null) prjct=(Project)Convert.ChangeType(ob,typeof(Project));
	
	if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin")){
		prjct.immersionDepth=2;
		prjct.theFrequencyOf=0;
	} else if(!Work.Licens(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin", Encoding.Default))){
		prjct.immersionDepth=2;
		prjct.theFrequencyOf=0;
			} 
	
	FormConfiguration frm=new FormConfiguration(prjct,f);
	frm.Show();
	
}

public static List<string> LoadConfignameProject(){
	Project prjct=new Project();
	List<string> s= new List<string>();
	List<object> ob=new List<object>();
	ob=Save.ReadConfig(prjct);
	if(ob!=null){
		listSites.Clear();
		for(int i=0;i<ob.Count;i++){
			prjct=(Project)Convert.ChangeType(ob[i],typeof(Project));
			listSites.Add(prjct.nameThreading,prjct);
			s.Add(listSites[prjct.nameThreading].nameProject);
		}}
	return s;
}
public static List<string> LoadConfignameThreading(){
	Project prjct=new Project();
	List<string> s= new List<string>();
	List<object> ob=new List<object>();
	ob=Save.ReadConfig(prjct);
	if(ob!=null){
		listSites.Clear();
		for(int i=0;i<ob.Count;i++){
			prjct=(Project)Convert.ChangeType(ob[i],typeof(Project));
			listSites.Add(prjct.nameThreading,prjct);
			s.Add(prjct.nameThreading);
		}}
	return s;
}

public void DeleteConfig(string  nameThreading){
	Save.DeleteFileConfig(nameThreading);
	listSites.Remove(nameThreading);
}

public Project GetConfig(string  nameThreading){
	listBlocInfo=listSites[nameThreading].blocInfo;
	listProxiPort=listSites[nameThreading].proxiPort;
	listLoadFile=listSites[nameThreading].listLoadFile;
	nameBlocFileExportXML=listSites[nameThreading].nameBlocFileExportXML;
	return listSites[nameThreading];
}


	}}
