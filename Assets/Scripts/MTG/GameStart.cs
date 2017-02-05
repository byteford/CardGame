using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardGame.MTG
{
    public class GameStart : MonoBehaviour
    {
        GameController cont;
        public int startingHandSize = 7;
        public void Start()
        {
            cont = GameController.Inst;
            cont.GameStart += new CardGameEvent(OnStart);
        }
        public void OnStart()
        {
            Debug.Log("GameStart");
            foreach (var temp in GameObject.FindGameObjectsWithTag("Player"))
            {
                cont.players.Add(temp.GetComponent<Player>());
            }
            for (int i = 0; i < cont.players.Count; i++)
            {
                cont.players[i].playerNumber = i;
                StartCoroutine(SetUpPlayer(i));
            }

        }
        public void Update()
        {
            for (int pNumber = 0; pNumber < cont.players.Count; pNumber++)
                cont.players[pNumber].CardsLoaded = cont.decks[pNumber].CardsLoaded;
        }
        IEnumerator SetUpPlayer(int pNumber)
        {
            cont.decks[pNumber].LoadCards();
            yield return new WaitUntil(() => cont.decks[pNumber].deckLoaded);
            cont.players[pNumber].CardsLoaded = cont.decks[pNumber].CardsLoaded;
            cont.decks[pNumber].ShuffleCards();
            for (int i = 0; i < startingHandSize; i++)
            {
                cont.drawACard(pNumber);
            }
        }
    }
}