using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
namespace CardGame
{
    public delegate void PlayerEvent();
    public delegate void CardGameEvent();
    public delegate void PhasesEvent(Phases currentPhase);
    public delegate void PriorityEvent(int PlayerWithPriority);
    public delegate void TurnEvent(int TurnNumber);
    public delegate void HandEvent();
        public class GameController : NetworkBehaviour {
        public GameObject GameRules;
        public List<Player> players;
        public List<Deck> decks;
        public int PlayerPriority;
        public Phases CurrentPhase;
        public int TurnNumber;
        public bool GameSetUp;
        public int PlayersTurn
        {
            get{
                if (players.Count == 0)
                    return 0;
                return TurnNumber % (players.Count );
            }
        }
        public static GameController Inst;

        public event CardGameEvent onGameStart;
        public event PhasesEvent onEndPhase;
        public event PhasesEvent onStartPhase;
        public event PriorityEvent onChangePriority;
        public event TurnEvent onTurnChange;
        public event HandEvent onHandChange;
        public void Start()
        {
            GameSetUp = false;
            Inst = this;
            Instantiate(GameRules);
        }
        public void StartGame()
        {
            if (GameSetUp)
                return;
            if(onGameStart != null)
            onGameStart();
            GameSetUp = true;
        }
        private void Update()
        {
            
        }
        public void drawACard(int playerNumer)
        {
            players[playerNumer].DrawACard(decks[playerNumer].drawACard().info);
            if (onHandChange != null)
                onHandChange();
        }
        public void NextTurn()
        {
            TurnNumber++;
            CurrentPhase = Phases.Untap_Step;
            PlayerPriority = PlayersTurn;
            if(onTurnChange != null)
            onTurnChange(TurnNumber);
        }
        public void NextPhase()
        {
            if (onEndPhase != null)
            onEndPhase(CurrentPhase);
            if (CurrentPhase == Phases.End_Step)
                NextTurn();
            else
            {
                CurrentPhase++;
                if(onStartPhase != null)
                onStartPhase(CurrentPhase);
            }
            
        }
        public void PassPriorety(int PlayerNumber)
        {
            if (PlayerNumber != PlayerPriority)
                return;
            PlayerPriority++;
            if (PlayerPriority >= players.Count)  
                PlayerPriority = 0;
            if (PlayerPriority == PlayersTurn)
                NextPhase();
            else
                if(onChangePriority != null)
                    onChangePriority(PlayerPriority);
           
        }


    }
}
