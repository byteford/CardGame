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
        public bool GameSetUp;
        public int PlayersTurn
        {
            get{
                return TurnNumber % players.Count;
            }
        }
        public static GameController Inst;
        public void Start()
        {
            GameSetUp = false;
            Inst = this;
        }
        public void StartGame()
        {
            if (GameSetUp)
                return;
            GameSetUp = true;
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
        public void NextTurn()
        {
            TurnNumber++;
            CurrentPhase = Phases.Untap_Step;
            PlayerPriority = PlayersTurn;
        }
        public void NextPhase()
        {

            if (CurrentPhase == Phases.End_Step)
                NextTurn();
            else
                CurrentPhase++;
            
        }
        public void PassPriorety(int PlayerNumber)
        {
            if (PlayerNumber != PlayerPriority)
                return;
            //PlayerPriority++;
            if (PlayerPriority +1 >= players.Count)
                NextPhase();
            else
                PlayerPriority++;
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
