/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 01.03.2020
 * Время: 19:28
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Threading;

namespace PaLoSi
{
	/// <summary>
	/// Description of Threaders.
	/// </summary>
	public class Threaders{
	public Threaders(){	
		}
	private Thread WorkThreading;
	
	public delegate void FunctionThreadNonArg();
	public delegate void FunctionThreadArg(object ob);
	public WebQuery wbQrr=new WebQuery();
	public MessegTask mess=new MessegTask();
	
	public Thread StartThead(FunctionThreadArg functionthreadarg,object ob){
		WorkThreading=new Thread(new ParameterizedThreadStart(functionthreadarg));
		WorkThreading.Start(ob);
		WorkThreading.IsBackground=true;
		return WorkThreading;
	}
	
	public Thread StartThead(FunctionThreadNonArg functionthreadnonarg){
		WorkThreading=new Thread(new ThreadStart(functionthreadnonarg));
		WorkThreading.Start();
		WorkThreading.IsBackground=true;
		return WorkThreading;
	}
	
	public void AbortThead(int tm){
		if(WorkThreading.IsAlive) WorkThreading.Abort(tm);
	}
	
	public Thread GetTheard(){
		return WorkThreading;
	}

	
	}
}
