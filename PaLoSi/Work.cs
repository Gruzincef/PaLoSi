/*
 * Создано в SharpDevelop.
 * Пользователь: Админ
 * Дата: 06.01.2020
 * Время: 17:36
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.IO;
using HtmlAgilityPack;
using Jint;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;



namespace PaLoSi
{
	//Тип события
	public enum EVENT_TYPE {
	STOP,
	PAUSE,
	FIRSTSTART,
	END,
	STOPLOAD,
	ENDLOAD,
	NEW,
	RESUME,
	START,
	STARTLOAD,
	MESSEG,
	EXISTS,
	SAVE,
	ENDSAVE,
	WORK,
	NONE,
	ERRORLOAD,
	ERROR,
	ERRORLOADFILE
	};
	public enum EVENT_LOAD {
	NEW,
	RESUME,
	FIRSTSTART,
	END,
	PAUSE,
	START,
	STOP,
	WORK,
	NONE,
	ERROR
	};
	//От кого
	public enum EVENT_WHO {
	THEARD,
	FORM,
	};
	//Кому
	public enum EVENT_WHOM {
	THEARD,
	FORM,
	};
	
	/// <summary>
	/// Description of Work.
	/// </summary>
	/// 

	
public class BLOCKINFO{
	public string nameBlock;
	public string[]value;
}


public class Work{
	List<BLOCKINFO> blockInfo=new List<BLOCKINFO>();
	public int CounProject=10;
	public WebQuery WbQr;
	public Save SQLQr;
	/*Новый код*/
	public static Work Wrk=new Work();
	public static Thread WorkThreading;
	public static bool LoadAllTheard;
	public static EventWaitHandle ewh;
	//Делегат отправки сообщений в форму 
	public delegate void OperationDelegate(MessegTask mess);
	//Событие отправки сообщений в форму
	private MenegerEvent ME=MenegerEvent.getInstance();
	
	public static Dictionary<string, StartLoad> StrtLd=new Dictionary<string, StartLoad>();
	public static Dictionary<string, Export> Exprt=new Dictionary<string, Export>();
	private ListSites LstSts=new ListSites();
public void StartLoadProject(List<string> lst,EVENT_TYPE ld){
	
	for(int i=0;i<lst.Count;i++){
		if(!StrtLd.ContainsKey(lst[i])){
			StrtLd.Add(lst[i],new StartLoad(LstSts.GetConfig(lst[i])));
			StrtLd[lst[i]].StatusThreading=ld;
			ME.SetEvent(ld,"Launch ",LstSts.GetConfig(lst[i]).nameProject,lst[i]);
			StrtLd[lst[i]].StartTheadLoad();
		}else if((ld==EVENT_TYPE.NEW)||(ld==EVENT_TYPE.RESUME)){
			StrtLd[lst[i]].StatusThreading=ld;
			ME.SetEvent(ld,"Launch ",LstSts.GetConfig(lst[i]).nameProject,lst[i]);
			StrtLd[lst[i]].StartTheadLoad();
		}
	}			
}

public EVENT_TYPE GetEventLoad(string NAMETHREAING){
if(StrtLd.ContainsKey(NAMETHREAING)){
	return StrtLd[NAMETHREAING].MessThreading;
	}else return EVENT_TYPE.NONE;
}
	
public void UpdtStts(object ob){
	
	Rrr RRR=new Rrr();
	RRR=(Rrr)ob;
	List<string> query=new List<string>();
	for(int i=0;i<RRR.RRR.Count;i++){
		query.Clear();
		query.Add("UPDATE  "+RRR.RRR[i]+" SET error=false WHERE error=true");
		Save.SqlQuery(RRR.RRR[i],query);
	}
	query.Clear();
}
public void UpdateStatus(List<string>RRR){
	Rrr rrr=new Rrr(RRR);
	Thread t= new Thread(new ParameterizedThreadStart(UpdtStts));
	t.Start(rrr);
}

public static void UpdateStatus(List<string> lst, EVENT_TYPE eventtype){
	for(int i=0;i<lst.Count;i++)
		StrtLd[lst[i]].StatusThreading=eventtype;
}

public void UpdateStatusLoadFirst(string nameThreading){
		Save.SqlQuery(nameThreading, "UPDATE  "+nameThreading+" SET get=false where Href='"+ListSites.listSites[nameThreading].addresSite+"'" );
}

public Work(){
	SQLQr=new Save();
}

public class Paramet{
	public ListSites.Project Project;
	public string NameThreading;
	public EVENT_LOAD Ld;
	public  Paramet(){}
	public  Paramet(ListSites.Project project,string nameThreading,EVENT_LOAD ld){
			this.Project=project;
			this.NameThreading=nameThreading;
			this.Ld=ld;
	}
}

public void StopAll(){
	foreach(KeyValuePair<string, ListSites.Project> p in ListSites.listSites){
		if(StrtLd.ContainsKey(p.Key)){
			StrtLd[p.Key].Abort();
			StrtLd.Remove(p.Key);
		}
	}
}
public void StopSelect(List<string> list){
		for(int i=0;i<list.Count;i++)
			if(StrtLd.ContainsKey(list[i])){
		StrtLd[list[i]].Abort();
		StrtLd.Remove(list[i]);
	}
}

public void AddPostInThreading(string nameThreading, EVENT_TYPE eventType){
	if (StrtLd.ContainsKey (nameThreading)) StrtLd[nameThreading].MessThreading=eventType;
}

/***************************************/

string GetDomain(string url){
	string[] s=url.Split(new[]{'/'}, StringSplitOptions.RemoveEmptyEntries);
	if(url.Contains("://")) return s[1];
	else return s[0];
}
public void Export(VarExportFile VrExprtFl, List<string> ListNameThreading){
	for(int i=0;i<ListNameThreading.Count;i++)
		if((!Exprt.ContainsKey(ListNameThreading[i].ToString()))&&(!StrtLd.ContainsKey(ListNameThreading[i].ToString()))){
			Exprt.Add(ListNameThreading[i].ToString(), new Export(VrExprtFl,ListSites.listSites[ListNameThreading[i].ToString()]));
			Exprt[ListNameThreading[i].ToString()].StartThreadExport();
	}
}
public void StopExport(List<string> ListNameThreading){
	for(int i=0;i<ListNameThreading.Count;i++)
		if(Exprt.ContainsKey(ListNameThreading[i].ToString()))
			Exprt[ListNameThreading[i].ToString()].StopExport();
}
public void DeleteProject(string NameThreading){
	Save.DeleteFileConfig(NameThreading);
	Save.DeleteBD(NameThreading);
}
public bool StatusThread(string NameThreading){
	if(StrtLd.ContainsKey(NameThreading))
	return StrtLd[NameThreading].Threading.IsAlive;
	else return false;
}
class Rrr{
	public List<string>RRR=new List<string>();
	public Rrr(List<string>rrr){
		this.RRR=rrr;
	}
	public Rrr(){
}
}
public static string TransliterationType (string txt){
	Regex regex = new Regex(@"\W");
    txt = regex.Replace(txt, "");
	txt=txt.Replace("Є","EH");
    txt=txt.Replace('І', 'I');
    txt=txt.Replace('і', 'i');
    txt=txt.Replace('№', '#');
    txt=txt.Replace("є","eh");
    txt=txt.Replace('А','A');
    txt=txt.Replace('Б','B');
    txt=txt.Replace('В','V');
    txt=txt.Replace('Г','G');
    txt=txt.Replace('Д','D');
    txt=txt.Replace('Е','E');
    txt=txt.Replace("Ё","JO");
    txt=txt.Replace("Ж","ZH");
    txt=txt.Replace('З','Z');
    txt=txt.Replace('И','I');
    txt=txt.Replace("Й","JJ");
    txt=txt.Replace('К','K');
    txt=txt.Replace('Л','L');
    txt=txt.Replace('М','M');
    txt=txt.Replace('Н','N');
    txt=txt.Replace('О','O');
    txt=txt.Replace('П','P');
    txt=txt.Replace('Р','R');
    txt=txt.Replace('С','S');
    txt=txt.Replace('Т','T');
    txt=txt.Replace('У','U');
    txt=txt.Replace('Ф','F');
    txt=txt.Replace("Х","KH");
    txt=txt.Replace('Ц','C');
    txt=txt.Replace("Ч","CH");
    txt=txt.Replace("Ш","SH");
    txt=txt.Replace("Щ","SHH");
    txt=txt.Replace('Ъ','_');
    txt=txt.Replace('Ы','Y');
    txt=txt.Replace('Ь','_');
    txt=txt.Replace("Э","EH");
    txt=txt.Replace("Ю","YU");
    txt=txt.Replace("Я","YA");
    txt=txt.Replace('а','a');
    txt=txt.Replace('б','b');
    txt=txt.Replace('в','v');
    txt=txt.Replace('г','g');
    txt=txt.Replace('д','d');
	txt=txt.Replace('е','e');
	txt=txt.Replace("ё","jo");
	txt=txt.Replace("ж","zh");
	txt=txt.Replace('з','z');
	txt=txt.Replace('и','i');
	txt=txt.Replace("й","jj");
	txt=txt.Replace('к','k');
	txt=txt.Replace('л','l');
	txt=txt.Replace('м','m');
	txt=txt.Replace('н','n');
	txt=txt.Replace('о','o');
	txt=txt.Replace('п','p');
	txt=txt.Replace('р','r');
	txt=txt.Replace('с','s');
	txt=txt.Replace('т','t');
	txt=txt.Replace('у','u');
	txt=txt.Replace('ф','f');
	txt=txt.Replace("х","kh");
	txt=txt.Replace('ц','c');
	txt=txt.Replace("ч","ch");
	txt=txt.Replace("ш","sh");
	txt=txt.Replace("щ","shh");
	txt=txt.Replace('ъ','_');
	txt=txt.Replace('ы','y');
	txt=txt.Replace('ь','_');
	txt=txt.Replace("э","eh");
	txt=txt.Replace(' ','_');
	txt=txt.Replace("ю","yu");
	txt=txt.Replace("я","ya");
	return txt;
}


public static string FullMachineInfo { get; private set; }
static string keyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.bin");
/*
 * private string ByteConvertor16F(byte[] bt){
	for(int i=0i<bt.len
	
}*/
public static string Protector() {
	var hsch=new HMACSHA1();
	FullMachineInfo=GetProcessor_ID()+"_"+GetMotherBoard_ID();
	return FullMachineInfo;
}
public static bool Licens(string key){
	try{
	string s=RsaWithCspKey.DecryptoKey(key);
	MD5 md5Hash=MD5.Create();
	Encoding encoding=Encoding.Default;
	if(s==encoding.GetString(md5Hash.ComputeHash(Encoding.Default.GetBytes(Protector()))))
	return true;
	else return false;
	} catch{
		return false;
		
	}
}
/*
public static bool GetRegisterResult() {
	if (!File.Exists(keyFilePath)) {
		return false;
	}
	if (!Decrypt(keyFilePath)) {
		return false;
	}
	return true;
}

static bool Decrypt(string path) {
	List<byte> providerKey = new List<byte>(Encoding.Default.GetBytes(FullMachineInfo));
	if (providerKey.Count < 0x20) {
		providerKey.AddRange(new byte[0x20 - providerKey.Count]);
	}else {
		 providerKey.RemoveRange(0x20, providerKey.Count - 0x20);
	}
	byte[] providerIV = Enumerable.Range(0, 0x10).Select(i => (byte)i).ToArray();
 	Assembly asm = Assembly.GetExecutingAssembly();
	MethodBody mainMethodBody = asm.EntryPoint.GetMethodBody();
	byte[] entryPointOriginal = mainMethodBody.GetILAsByteArray();
	byte[] entryPointEncrypted = File.ReadAllBytes(path);
	using (Aes provider = Aes.Create()) {
		provider.IV = providerIV;
		provider.Key = providerKey.ToArray();
    	using (ICryptoTransform decryptor = provider.CreateDecryptor()) {
			try {
    	        byte[] entryPointDecrypted =decryptor.TransformFinalBlock(entryPointEncrypted, 0, entryPointEncrypted.Length);
				if (entryPointOriginal.Length != entryPointDecrypted.Length) {
					return false;
				}
				for (int i = 0; i < entryPointDecrypted.Length; i++) {
					if (entryPointDecrypted[i] != entryPointOriginal[i]) {
						return false;
					}
				}
			}catch {
			return false;
			} 
		}
  	}
	return true;
}
*/
 //Метод получения информации о целевом ПК
static void GetUserConfigurationInfo() {
 	//System.Management.Instrumentation.management
 	SelectQuery[] queries = new SelectQuery[3]{
		new SelectQuery("Win32_Processor"),
		new SelectQuery("Win32_BaseBoard"),
		new SelectQuery("Win32_VideoController")
	};
	string[] infoQueries = { "processorId", "SerialNumber", "AdapterRAM" };
	string[] results = new string[3];
	int index = 0;
	foreach (SelectQuery query in queries) {
		ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
		ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator();
		while (enumerator.MoveNext()) {
			ManagementObject info = (ManagementObject)enumerator.Current;
			results[index] = info[infoQueries[index]].ToString().Trim();
		}
		index++;
	}
	FullMachineInfo = new string(string.Join("@", results).Select(ch => (char)(ch + 1)).ToArray());
}
//Метод для получения ProcessorID
private static string GetProcessor_ID() {
	string ProcessorID = string.Empty;
	SelectQuery query = new SelectQuery("Win32_processor");
	ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
	ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator();
	while (enumerator.MoveNext()) {
		ManagementObject info = (ManagementObject)enumerator.Current;
		ProcessorID = info["processorId"].ToString().Trim();
	}
	return ProcessorID;
}
        //Метод для получения MotherBoardID
private static string GetMotherBoard_ID() {
	string MotherBoardID = string.Empty;
	SelectQuery query = new SelectQuery("Win32_BaseBoard");
	ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
	ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator();
	while (enumerator.MoveNext()) {
		ManagementObject info = (ManagementObject)enumerator.Current;
		MotherBoardID = info["SerialNumber"].ToString().Trim();
	}
	return MotherBoardID;
}
        //Метод для получения VideoController_RAM
        /*
private static string GetVideoAdapter_ID() {
	string MotherBoardID = string.Empty;
	SelectQuery query = new SelectQuery("Win32_VideoController");
	ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
	ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator();
	while (enumerator.MoveNext()) {
		ManagementObject info = (ManagementObject)enumerator.Current;
		MotherBoardID = info["AdapterRAM"].ToString().Trim();
	}
	return MotherBoardID;
 }*/


/******************/
}
	
	}


/*
public void DeleteThreading(string NameThreading){
	ListThreading[NameThreading].Abort();
	ListThreading.Remove(NameThreading);
	IndexProject.Remove(NameThreading);
	StatusThreading.Remove(NameThreading);
	MessThreading.Remove(NameThreading);
	ListTimer.Remove(NameThreading);
	CountLoad.Remove(NameThreading);
	StartLF.Remove(NameThreading);
	//thrd.Remove(NameThreading);
}
public void StartTheardTime(){
	ewh=new EventWaitHandle(true, EventResetMode.AutoReset);
	StartLoad StrtLd=new PaLoSi.StartLoad();
	
}

public  class LP{
	public EVENT_LOAD LD=new EVENT_LOAD();
	public List<int> LIST=new List<int>();
	public LP(){}
	public LP(List<int> list,EVENT_LOAD ld){
		this.LD=ld;
		this.LIST=list;
	}
}*
public void ExportInXML(List<int> lst,string path){
	ParametSave pr=new ParametSave(lst,path);
	//Thread thrd=new Thread(new ParameterizedThreadStart(ExportInXMLThreading));
	//thrd.Start(pr);
}
*/