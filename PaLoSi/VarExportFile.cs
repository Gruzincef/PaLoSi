/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 08.03.2020
 * Время: 21:10
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace PaLoSi
{
	public enum EXPORT_TYPE {
	HTML,
	XML,
	CSV,
	XLS,
	TXT
};
	/// <summary>
	/// Description of VarExportFile.
	/// </summary>
public class VarExportFile{
	public string path ;
	public string nameThreading;
	public bool ExportDifferentFile;
	public EXPORT_TYPE Type;
	public string WhatLoad;
	public int WhatLoadId;
	public  VarExportFile(){}

	public void SetType(string tp){
		Type=(EXPORT_TYPE)Enum.Parse(typeof(EXPORT_TYPE),tp);
	}
	public string GetTypeString(){
		return Type.ToString();
	}
	
	
	}
}
