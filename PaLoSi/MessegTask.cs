/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 29.02.2020
 * Время: 19:07
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace PaLoSi
{
	/// <summary>
	/// Description of Messeges.
	/// </summary>
	public class MessegTask{
		public EVENT_TYPE TYPE;
		public string MESS;
		public string NAMEPROJECT;
		public string NAMETHREAING;
		public  MessegTask(){}
		public  MessegTask(EVENT_TYPE tp,string mess,string nameproject, string namethreading){
			this.TYPE=tp;
			this.MESS=mess;
			this.NAMEPROJECT=nameproject;
			this.NAMETHREAING=namethreading;
		}

	}
}
