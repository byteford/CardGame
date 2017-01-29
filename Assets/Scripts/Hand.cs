using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardGame
{
    public class Hand : MonoBehaviour
    {

        public List<Card> cards;

        public void AddCard(Card card)
        {
            cards.Add(card);
        }
    }
}