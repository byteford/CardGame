﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

namespace CardGame
{


    [System.Serializable]
    public struct CardInfo
    {
        public string name;
        public int id;
    }
    [System.Serializable]
    public class Card
    {
        public CardInfo info = new CardInfo();
        //[SerializeField]
        //private string _name;
        //[SerializeField]
        //public int id;
        //public string name
        //{
        //    get { return _name; }
        //}
        [SerializeField]
        JSONNode json;
        public Card(int id)
        {
            info.id = id;

        }
        public Card(string name)
        {
            info.name = name;
        }
        public Card(CardInfo info)
        {
            this.info = info;
        }
        public Card(JSONNode json)
        {
            //Debug.Log ("Load Card " + json.ToString ());
            this.json = json;
            info.name = GetStringFromJSON("name");
            info.id = GetIntFromJSON("multiverseid");


        }
        public string GetStringFromJSON(string value)
        {
            if (json["card"].ToString() != "")
                return json["card"][value].Value;
            else
                return json["cards"][0][value].Value;
        }
        public int GetIntFromJSON(string value)
        {
            if (json["card"].ToString() != "")
                return json["card"][value].AsInt;
            else
                return json["cards"][0][value].AsInt;
        }


    }
}
