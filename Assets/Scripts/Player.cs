using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Player : MonoBehaviour {

	public Deck deck;
	public Hand hand;
	public int startingHandSize = 7;
	public void Start(){
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
