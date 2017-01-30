using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace CardGame
{
    public class Player : NetworkBehaviour
    {
        //public Deck deck;
        public Hand hand;

        [SyncVar]
        public int playerNumber = 0;
        public static Player LocalPlayer;
        public static Player OtherPlayer;
        public GameObject GameController;
        [SyncVar]
        public int CardsLoaded = 0;
        public void Start()
        {
            if (isServer)
            {

                if (isLocalPlayer)
                {
                    Instantiate(GameController);
                }
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
            
           // StartCoroutine(SetUPPlayer());
        }
        public void Update()
        {
        }
        //public void DrawStartingHand()
        //{
        //    for (int i = 0; i < startingHandSize; i++)
        //    {
        //        DrawACard();
        //    }
        //}

        public void DrawACard(CardInfo info)
        {
            //hand.AddCard(deck.drawACard());
            if (!isServer)
                return;
            RpcDrawACard(info);
        }

        [ClientRpc]
        void RpcDrawACard(CardInfo info)
        {
            hand.AddCard(new Card(info));
        }
    }
}