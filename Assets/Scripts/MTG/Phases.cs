using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardGame.MTG {
    public class Phases : MonoBehaviour {

        GameController cont;
        CardGame.Phases currentPhase;
        void Start() {
            cont = GameController.Inst;
            cont.onStartPhase += new PhasesEvent(onStartPhase);
            cont.onChangePriority += new PriorityEvent(onPriorityChange);
            cont.onEndPhase += new PhasesEvent(onPhaseEnd);
        }


        public void onStartPhase(CardGame.Phases currentPhase)
        {
            this.currentPhase = currentPhase;
            switch (currentPhase)
            {
                case CardGame.Phases.Draw_Step:
                    DrawStep();
                    break;
            }
        }
        public void onPhaseEnd(CardGame.Phases currentPhase)
        {

        }
        void onPriorityChange(int PlayerWithPriority)
        {
            if (cont.PlayersTurn == PlayerWithPriority)
                cont.NextPhase();

        }
        void DrawStep()
        {
            if (cont.TurnNumber != 0)
                cont.drawACard(cont.PlayersTurn);
        }

    }
}