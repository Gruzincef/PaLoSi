/*
 * Создано в SharpDevelop.
 * Пользователь: Админ
 * Дата: 06.01.2020
 * Время: 20:42
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System.Collections;
using System.Collections.Generic;

namespace PaLoSi
{

public enum EVENT_TYPE {
	STOP,
	PAUSE,
	QYERYINFORM
};
	/// <summary>
	/// Description of EventManager.
	/// </summary>
public class EventManager{
public static EventManager Instance{
	get{return instance;}
	set{}
}
public static EventManager _eventManager = new EventManager ();

private static EventManager instance = null;
public delegate void OnEvent(EVENT_TYPE Event_Type, object messeg);
private Dictionary<EVENT_TYPE, List<OnEvent>> Listeners =new Dictionary<EVENT_TYPE, List<OnEvent>>();
	
	
public void AddListener( EVENT_TYPE Event_Type,OnEvent Listener){
	List<OnEvent> ListenList = null;
	if (Listeners.TryGetValue (Event_Type, out ListenList)) {
		ListenList.Add (Listener);
		return;
	}  
	ListenList = new List<OnEvent> ();
	ListenList.Add (Listener);
	Listeners.Add (Event_Type, ListenList);
}

public void PostNotification(EVENT_TYPE Event_Type,object messeg){
	List<OnEvent> ListenList = null;
	if(!Listeners.TryGetValue(Event_Type, out ListenList)) return;
	for (int i=0; i<ListenList.Count; i++){
		if(!ListenList[i].Equals(null))
			ListenList[i](Event_Type, messeg) ;
	}
}
public void RemoveEvent(EVENT_TYPE Event_Type){
	Listeners.Remove(Event_Type);
}
	
// Удаляет все избыточные записи из словаря 
public void RemoveRedundancies(){
	Dictionary<EVENT_TYPE, List<OnEvent>> TmpListeners = new Dictionary<EVENT_TYPE, List<OnEvent>> () ;
	foreach(KeyValuePair<EVENT_TYPE, List<OnEvent>> Item in Listeners) {
		for(int i = Item.Value.Count-1; i>=0; i--){
			if(Item.Value[i].Equals(null))
			Item.Value.RemoveAt(i);
		}
		if(Item.Value.Count > 0)
		TmpListeners.Add (Item.Key, Item.Value);
	}
	Listeners = TmpListeners;
}

}
}