using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace CardGame
{
    public static class CardCashe {
        static SqliteDatabase sqlDB;
        static string dbName = "Card.db";
        static string tableName = "MTGCards";
        public static SqliteDatabase getDB()
        {
            if (sqlDB == null)
                sqlDB = new SqliteDatabase(dbName);
            return sqlDB;
        }
        public static void RemakeDB()
        {
            getDB().ExecuteNonQuery("DROP TABLE " + tableName);
            getDB().ExecuteNonQuery("CREATE TABLE `"+tableName+"` (`Id`	INTEGER NOT NULL UNIQUE,`CardName`	TEXT,`ImageURL` TEXT,PRIMARY KEY(`Id`))");
        }
        public static void Save(CardInfo card)
        {
            //getDB().ExecuteNonQuery("INSERT INTO " + tableName + "(Id,CardName)" + "VALUES ('409784','Thraben Inspector');");



                // sqlDB = new SqliteDatabase(dbName);
                //string quiry = "INSERT INTO MTGCards(Id) VALUES('2')";
                string quiry = "INSERT INTO " + tableName + "(Id,CardName,ImageURL)" + "VALUES ('" + card.id + "','"+card.name.Replace("'","''")+"','"+card.ImageURL.Replace("'","''")+"');";
                if (!isInTable(card.id))
                {
                    getDB().ExecuteNonQuery(quiry);
                    Debug.Log("Added " + card.name + " to cashe");
                }
                

        }
        public static bool Load(int id, out CardInfo card)
        {
            if (!isInTable(id))
            {
                card = new CardInfo();
                return false;
            }

            DataRow data = getDB().ExecuteQuery("SELECT * FROM MTGCards WHERE Id=" + id + ";").Rows[0];
            card = LoadInfo(data);
            return true;
        }
        public static bool Load(string name, out CardInfo card)
        {

            if (!isInTable(name))
            {
                card = new CardInfo();
                return false;
            }

            DataRow data = getDB().ExecuteQuery("SELECT * FROM MTGCards WHERE CardName='" + name.Replace("'", "''") + "';").Rows[0];
            card = LoadInfo(data);
            return true;
        }
        private static CardInfo LoadInfo(DataRow data)
        {
            CardInfo card = new CardInfo();

            card.id = int.Parse(data["Id"].ToString());
            if(data["CardName"] != null)
            card.name = data["CardName"].ToString();
            card.ImageURL = data["ImageURL"].ToString();
            return card;
        }
        public static bool isInTable(int id)
        {
            //var temp = getDB().ExecuteQuery("SELECT * FROM MTGCards");

            //foreach(var temp1 in temp.Rows)
            //{
            //    foreach(var temp2 in temp1.Values)
            //    {
            //        Debug.Log(temp2);
            //    }
            //}

            string quiry = "SELECT * FROM MTGCards WHERE Id=" + id + ";";
            Debug.Log(quiry);
            var data = getDB().ExecuteQuery(quiry).Rows;

            if(data.Count > 0)
                return true;

            return false;
        }
        public static bool isInTable(string name)
        {
            

            string quiry = "SELECT * FROM MTGCards WHERE CardName='" + name.Replace("'", "''") + "';";
            Debug.Log(quiry);
            var data = getDB().ExecuteQuery(quiry).Rows;

            if (data.Count > 0)
                return true;

            return false;
        }
    }
}