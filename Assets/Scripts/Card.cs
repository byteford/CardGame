using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;


[System.Serializable]
public class Card  {
	[SerializeField]
	private string _name;
	[SerializeField]
	private int id;
	public string name{
		get{ return _name;}
	}
	public string url;
	[SerializeField]
	JSONNode json;
	public Card(int id){
		this.id = id;

	}
	public Card(string name){
		_name = name;

	}
	public Card(JSONNode json){
		//Debug.Log ("Load Card " + json.ToString ());
		this.json = json;
		_name = GetStringFromJSON ("name");
		id = GetIntFromJSON ("multiverseid");
        

	}
	public string GetStringFromJSON( string value){
		if (json ["card"].ToString() != "")
			return json ["card"] [value].Value;
		else 
			return json ["cards"][0] [value].Value;
	}
	public int GetIntFromJSON( string value){
		if (json ["card"].ToString() != "")
			return json ["card"] [value].AsInt;
		else 
			return json ["cards"][0] [value].AsInt;
	}


}
