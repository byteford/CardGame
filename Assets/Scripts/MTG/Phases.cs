using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardGame.MTG {
    public class Phases : MonoBehaviour {

        GameController cont;
        CardGame.Phases currentPhase;
        void Start() {
            cont = GameController.Inst;
            cont.onStartPhase += onStartPhase;
            cont.onChangePriority += onPriorityChange;
        }


        public void onStartPhase(CardGame.Phases currentPhase)
        {
            this.currentPhase = currentPhase;
        }
        void onPriorityChange(int PlayerWithPriority)
        {
            
        }


    }
}