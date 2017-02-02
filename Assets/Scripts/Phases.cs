using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardGame
{
    public enum Phases
    {
        Untap_Step,
        UpKeep_Step,
        Draw_Step,
        Main_Phase,
        Beginning_of_Combat_Step,
        Declare_Attackers_Step,
        Declare_Blockers_Step,
        Combat_Damage_Step,
        End_Of_Combat_Step,
        Second_Main_Phase,
        End_Step,
        Cleanup_Step
    }
}