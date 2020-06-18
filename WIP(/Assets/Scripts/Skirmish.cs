using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skirmish : MonoBehaviour
{
    public CharacterGroup atk, def;
    SkirmishTurn skirmishTurn;
    /*
     * /////// Turn loop ////////
     * Team1 attacks
     * Team2 defends
     * damage is calculated
     * turn ends
     * attacker and defender roles switch
     * */
    private void Start() {
        atk.Initialize();
        def.Initialize(); 
        skirmishTurn = new SkirmishTurn(atk, def);
    }


}
