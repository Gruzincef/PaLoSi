/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 13.03.2020
 * Время: 20:25
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Collections.Generic;
using System.Threading;

namespace PaLoSi
{
	/// <summary>
	/// Description of Records.
	/// </summary>
public class Records{
	private string NameThreading;
	public string href;
	public int id;
	public int idcategory;
	public string title;
	public string txthref;
	public bool Get;
	public bool error;
	public string dateload;
	public bool document;
	public bool documentload;
	public bool export;
	public string xml;
	public string root_href;
	public int hierarchy;

	private DataTable RdQr;
	public Records(){	}
	
public void SetNameThreading(string nameThreading){
	NameThreading=nameThreading;
}
	
public  int CountRecords(){
	int ContRead=0;
	if(Save.EnabledBlockBD){
		RdQr=Save.SqlRead(NameThreading, "SELECT  count(*) FROM '"+NameThreading+"' WHERE error=false AND href LIKE '%"+ListSites.listSites[NameThreading].addresSite+"%'");
		return Convert.ToInt32(RdQr.Rows[0][0].ToString());
	} else {
		while((!Save.EnabledBlockBD)||(ContRead<10)){
			ContRead++;
			Thread.Sleep(5);
		}
		if(Save.EnabledBlockBD){
			RdQr=Save.SqlRead(NameThreading, "SELECT  count(*) FROM '"+NameThreading+"' WHERE error=false AND href LIKE '%"+ListSites.listSites[NameThreading].addresSite+"%'");
			return Convert.ToInt32(RdQr.Rows[0][0].ToString());
		}else {
			return 0;	
		}
	return 0;	
	}
}
public  int CountRecordsError(){
	RdQr=Save.SqlRead(NameThreading, "SELECT  count(*) FROM '"+NameThreading+"' WHERE error not like false");
	return Convert.ToInt32(RdQr.Rows[0][0].ToString());
}
public List<Records> GetListRecordsInfoBlock(int start,int stop){
	//	return GetListRecords( "SELECT  * FROM '"+NameThreading+"' order by id asc Limit "+start.ToString()+","+(stop-start).ToString());
	return GetListRecords("SELECT tb2.href as root_href,* FROM "+NameThreading+" as tb1, "+NameThreading+" as tb2 WHERE tb2.id=tb1.idcategory  AND tb1.href LIKE '%"+ListSites.listSites[NameThreading].addresSite+"%' order by id asc Limit "+start.ToString()+","+(stop-start).ToString());

}
public List<Records> GetListRecordsError(int start,int stop){
	return GetListRecords("SELECT tb2.href as root_href, * FROM "+NameThreading+" as tb1, "+NameThreading+" as tb2 WHERE tb1.error not  like false and tb2.id=tb1.idcategory  AND tb1.href LIKE '%"+ListSites.listSites[NameThreading].addresSite+"%' order by id asc Limit "+start.ToString()+","+(stop-start).ToString());
}

	
public List<Records> GetListRecords(string query){
	List<Records> Rcrds=new List<Records>();
	Records[] Rcrd=new Records[1];
	RdQr=Save.SqlRead(NameThreading, query);
	for(int i=0;i<RdQr.Rows.Count;i++){
		Rcrd[0]=new Records();
		Rcrd[0].root_href=RdQr.Rows[i]["root_href"].ToString();
		Rcrd[0].href=RdQr.Rows[i]["href"].ToString();
		Int32.TryParse(RdQr.Rows[i]["id"].ToString(),out Rcrd[0].id);
		Int32.TryParse(RdQr.Rows[i]["idcategory"].ToString(),out Rcrd[0].idcategory);
		Rcrd[0].title=RdQr.Rows[i]["title"].ToString();
		Rcrd[0].txthref=RdQr.Rows[i]["txthref"].ToString();
		Rcrd[0].Get=Convert.ToBoolean(RdQr.Rows[i]["get"].ToString());
		Rcrd[0].error=Convert.ToBoolean(RdQr.Rows[i]["error"].ToString());
		Rcrd[0].dateload=RdQr.Rows[i]["dateload"].ToString();
		Rcrd[0].document=Convert.ToBoolean(RdQr.Rows[i]["document"].ToString());
		Rcrd[0].documentload=Convert.ToBoolean(RdQr.Rows[i]["documentload"].ToString());
		Rcrd[0].export=Convert.ToBoolean(RdQr.Rows[i]["export"].ToString());
		Rcrd[0].xml=RdQr.Rows[i]["xml"].ToString();
		Int32.TryParse(RdQr.Rows[i]["hierarchy"].ToString(),out Rcrd[0].hierarchy);
		Rcrds.AddRange(Rcrd);
	}
	return 	Rcrds;
}
	
public void DeleteRecords(string id){
		Save.SqlQuery(NameThreading,"DELETE FROM "+NameThreading+" WHERE id="+id);
	
}

	
	}
}
