using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {
    BattleTurn battleTurn;
    /*
     * /////// Turn loop ////////
     * Team1 starts turn
     * Team1 can select units to hire
     * Team1 finishes selection
     * Team1 can move units from tile to tile
     * Team1 can end movement
     * Team1 can hire last units
     * Team1 ends turn
     * play moves to team 2
     * Team 2 can make all moves team 1 has made
     * once team 2 ends turn, play returns to team1
     * /
     * Team1 attacks
     * Team2 defends
     * damage is calculated
     * turn ends
     * attacker and defender roles switch
     * */
    private void Start() {
        battleTurn = new BattleTurn();
    }


}
