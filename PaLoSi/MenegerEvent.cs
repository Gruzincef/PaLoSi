/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 07.03.2020
 * Время: 18:57
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;

namespace PaLoSi
{
	/// <summary>
	/// Description of ManagerEvent.
	/// </summary>
	public class MenegerEvent{
		public static MenegerEvent instance=new MenegerEvent();
		//private static MenegerEvent instance;
		private MenegerEvent(){
		}
	public static MenegerEvent getInstance(){
		if(instance==null)
			instance=new MenegerEvent();
		return instance;
	}
	/***********************/
	public MessegTask Mess;
	public delegate void OperationDelegate(MessegTask mess);
	public event OperationDelegate Event_Messeg;

	
	public void SetEvent(EVENT_TYPE tp,string mess,string nameproject, string namethreading){
		
		Mess=new MessegTask(tp,mess,nameproject,namethreading);
		//Mess=new MessegTask(tp,mess,ListSites.listSites[nameproject].nameProject,namethreading);
		
		Event_Messeg.Invoke(Mess);	
	}
	
	
	
	/**********************/
	}
	
}
