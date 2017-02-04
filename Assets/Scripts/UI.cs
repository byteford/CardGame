using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CardGame
{
    public class UI : MonoBehaviour
    {

        public Text locDeckSize;
        public Transform locHandRoot;
        public GameObject baseCard;
        public Player locPlayer;
        public List<GameObject> LocCardsIsHand;

        public Text othDeckSize;
        public Transform othHandRot;
        public Player othPlayer;
        public List<GameObject> othCardsInHand;

        public Text CurrentPhaseText;

        public void Update()
        {
            
            locPlayer = Player.LocalPlayer;

            if (locPlayer)
            {
                CurrentPhaseText.text = locPlayer.CurrentPhase.ToString();
                locDeckSize.text = locPlayer.CardsLoaded.ToString();
            }
            othPlayer = Player.OtherPlayer;
            if (othPlayer)
            {
                othDeckSize.text = othPlayer.CardsLoaded.ToString();
            }
            MakeHand();
        }
        public void SetUP()
        {
            //locPlayer.BroadcastMessage("StartGame");
            GameObject.FindGameObjectWithTag("GameController").BroadcastMessage("StartGame");

        }
        public void PassPrio()
        {
            locPlayer.PassPrio();
        }
        public void MakeHand()
        {
            if (locHandRoot.childCount != 0)
                return;
            if(locPlayer)
            foreach (Card card in locPlayer.hand.cards)
            {
                MakeLocCard(card);
            }
            if (othHandRot.childCount != 0)
                return;
            if(othPlayer)
            foreach (Card card in othPlayer.hand.cards)
            {
                MakeOthCard(card);
            }

        }
        public void MakeLocCard(Card card)
        {
            GameObject temp = Instantiate(baseCard);
            temp.transform.SetParent(locHandRoot);
            //temp.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
            //temp.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, 10);
            temp.GetComponentInChildren<Text>().text = card.info.name;
            StartCoroutine(LoadTexture(card.info, temp.GetComponent<RawImage>()));
            LocCardsIsHand.Add(temp);
        }
        public void MakeOthCard(Card card)
        {
            GameObject temp = Instantiate(baseCard);
            temp.transform.SetParent(locHandRoot);
            //temp.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
            //temp.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, 10);
            temp.GetComponentInChildren<Text>().text = card.info.name;
            othCardsInHand.Add(temp);
        }
        IEnumerator LoadTexture(CardInfo info, RawImage image)
        {

            Texture2D tex;
            tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            Debug.Log(info.ImageURL);
            WWW www = new WWW(info.ImageURL);
            yield return www;
            www.LoadImageIntoTexture(tex);
            image.texture = tex;
        }
    }
}