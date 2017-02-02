using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
namespace CardGame
{
    public class GameController : NetworkBehaviour {
        public List<Player> players;
        public List<Deck> decks;
        public int startingHandSize = 7;
        public int PlayerPriority;
        public Phases CurrentPhase;
        public int TurnNumber;
        public void Start()
        {
        }
        public void StartGame()
        {
            foreach( var temp in GameObject.FindGameObjectsWithTag("Player"))
            {
                players.Add(temp.GetComponent<Player>());
            }
            for(int i = 0;i< players.Count;i++)
            {
                players[i].playerNumber = i;
                StartCoroutine(SetUpPlayer(i));
               // players[i].StartGame();
            }
        }
        private void Update()
        {
            for(int pNumber = 0; pNumber < players.Count;pNumber++)
                players[pNumber].CardsLoaded = decks[pNumber].CardsLoaded;
        }
        public void drawACard(int playerNumer)
        {
            players[playerNumer].DrawACard(decks[playerNumer].drawACard().info);
        }
        IEnumerator SetUpPlayer(int pNumber)
        {
            decks[pNumber].LoadCards();
            yield return new WaitUntil(() => decks[pNumber].deckLoaded);
            players[pNumber].CardsLoaded = decks[pNumber].CardsLoaded;
            decks[pNumber].ShuffleCards();
            for(int i = 0; i < startingHandSize; i++)
            {
                drawACard(pNumber);
            }
        }

    }
}
