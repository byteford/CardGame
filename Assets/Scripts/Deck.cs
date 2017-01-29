using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
namespace CardGame
{
    public class Deck : MonoBehaviour
    {


        public string startOfURL = "https://api.magicthegathering.io/v1/cards";
        public List<Card> cards;
        public int CardsLoaded
        {
            get { return cards.Count; }
        }
        int CardsToLoad;
        public bool deckLoaded
        {
            get { return CardsLoaded == CardsToLoad; }

        }
        // Use this for initialization
        void Start()
        {
            cards = new List<Card>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        #region load Cards
        public void LoadCards()
        {
            Debug.Log("Loading please wait");
            addCard(401897, 2);
            addCard("Thraben Inspector", 4);
            addCard("Toolcraft Exemplar", 4);
            addCard("Inventor's Apprentice", 3);
            addCard("Veteran Motorist", 4);
            addCard("Thalia, Heretic Cathar", 3);
            addCard("Scrapheap Scrounger", 4);
            addCard("Harnessed Lightning", 3);
            addCard("Unlicensed Disintegration", 4);
            addCard("smuggler's copter", 4);
            addCard("Cultivator's Caravan", 3);
            addCard("Inspiring Vantage", 4);
            addCard("Aether Hub", 4);
            addCard("Concealed Courtyard", 4);
            addCard("Spirebluff Canal", 4);
            addCard("Mountain", 2);
            addCard("Plains", 4);
        }
        void addCard(int id)
        {
            //cards.Add(new Card(id));
            StartCoroutine(Load(startOfURL + "/" + id.ToString()));
        }
        void addCard(string name)
        {
            //cards.Add (new Card (name));
            StartCoroutine(Load(startOfURL + "?name=" + name.Replace(" ", "%20")));

        }
        void addCard(int id, int number)
        {
            for (int i = 0; i < number; i++)
            {
                addCard(id);
            }
        }
        void addCard(string name, int number)
        {
            for (int i = 0; i < number; i++)
            {
                addCard(name);
            }
        }


        IEnumerator Load(string URL)
        {
            CardsToLoad++;
            Debug.Log("loading " + URL);
            WWW temp = new WWW(URL);
            yield return temp;
            Card card = new Card(JSON.Parse(temp.text));
            if (card.GetStringFromJSON("name") == "")
            {
                Debug.Log("Failed to load: " + URL);
            }
            else
                cards.Add(card);
        }
        #endregion

        public void ShuffleCards()
        {
            if (!deckLoaded)
                return;
            for (int i = 0; i < CardsLoaded; i++)
            {
                Card temp = cards[i];
                int randomIndex = Random.Range(i, CardsLoaded);
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }

        }

        public Card drawACard()
        {
            Card temp = cards[0];
            cards.RemoveAt(0);
            return temp;
        }

    }
}