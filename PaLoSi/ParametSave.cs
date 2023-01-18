/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 08.03.2020
 * Время: 20:45
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;

namespace PaLoSi
{
	/// <summary>
	/// Description of ParametSave.
	/// </summary>
	public class ParametSave{
		public List<int> Lst;
	public string Path;
	public ParametSave(){Lst=new List<int>();	}
	public ParametSave(List<int> lst,string path){
		Lst=new List<int>();
		Lst=lst;
		Path=path;
	}
	}
}
