using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
namespace CardGame
{
    public class GameController : NetworkBehaviour {
        public List<Player> players;
        
    public void StartGame()
        {
            foreach( var temp in GameObject.FindGameObjectsWithTag("Player"))
            {
                players.Add(temp.GetComponent<Player>());
            }
            foreach(var player in players)
            {
                player.StartGame();
            }
        }


    }
}
