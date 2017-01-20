using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Player : NetworkBehaviour {

	public Deck deck;
	public Hand hand;
	public int startingHandSize = 7;
	public static Player LocalPlayer;
	public void Start(){
		if (isLocalPlayer) {
			LocalPlayer = this;
		}
	}
	public void StartGame(){
		
		StartCoroutine (SetUPPlayer());
	}

	public void DrawStartingHand(){
		for (int i = 0; i < startingHandSize; i++) {
			DrawACard ();
		}
	}

	public void DrawACard(){
		hand.AddCard(deck.drawACard ());
	}

	IEnumerator SetUPPlayer(){
		deck.LoadCards ();
		yield return new WaitUntil(() => deck.deckLoaded);
		deck.ShuffleCards ();
		DrawStartingHand ();
	}
}
