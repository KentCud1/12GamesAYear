using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTurn
{
    private bool turnsOver = false;
    private static int turnsTaken = 0;
    public BattleTurn() {
        TakeTurn();
    }
    public BattleTurn(BattleTurn bt) {
        bt.TakeTurn();
    }

    private void TakeTurn() {
        if (turnsTaken > 100)
            turnsOver = true;
        if(turnsOver) {
            return;
        }
        turnsTaken++;
        Debug.Log("Turn taken");
        TakeTurn();
        //return new BattleTurn(this);
    }
}
