using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour {

	public Button 	LoadBtn;
	public Text		DeckSize;
	public Transform HandRoot;
	public GameObject baseCard;
	public Player player;
	public List<GameObject> cardsIsHand;
	[SerializeField]
	Deck deck;
	[SerializeField]
	Hand hand;
	public void Update(){
		deck = player.deck;
		hand = player.hand;
			DeckSize.text = deck.CardsLoaded.ToString ();
			MakeHand ();
	}
	public void SetUP(){
		player.BroadcastMessage ("StartGame");

	}
	public void MakeHand(){
		if (HandRoot.childCount != 0)
			return;

		foreach(Card card in hand.cards){
			MakeCard (card);
		}

	}
	public void MakeCard(Card card){
		GameObject temp = Instantiate (baseCard);
		temp.transform.SetParent(HandRoot);
		//temp.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
		//temp.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, 10);
		temp.GetComponentInChildren<Text> ().text = card.name;
		cardsIsHand.Add (temp);
	}
}
