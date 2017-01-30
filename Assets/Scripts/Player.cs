using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace CardGame
{
    public class Player : NetworkBehaviour
    {
        public Deck deck;
        public Hand hand;
        public int startingHandSize = 7;
        [SyncVar]
        public int playerNumber = 0;
        public static Player LocalPlayer;
        public static Player OtherPlayer;
        public GameObject GameController;
        public void Start()
        {
            if (isServer)
            {

                if (isLocalPlayer)
                {
                    Instantiate(GameController);
                    playerNumber = 1;
                }
                else
                    playerNumber = 2;
            }
            if (isLocalPlayer)
            {
                LocalPlayer = this;
            }
            else
            {
                OtherPlayer = this;
            }
            
        }
        public void StartGame()
        {
            
            StartCoroutine(SetUPPlayer());
        }
        public void Update()
        {
        }
        public void DrawStartingHand()
        {
            for (int i = 0; i < startingHandSize; i++)
            {
                DrawACard();
            }
        }

        public void DrawACard()
        {
            hand.AddCard(deck.drawACard());
        }

        IEnumerator SetUPPlayer()
        {
            deck.LoadCards();
            yield return new WaitUntil(() => deck.deckLoaded);
            deck.ShuffleCards();
            DrawStartingHand();
        }
    }
}