using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkirmishTurn 
{
    CharacterGroup attacker, defender;
    public SkirmishTurn(CharacterGroup _attacker, CharacterGroup _defender) {
        attacker = _attacker;
        defender = _defender;
        if(attacker.CurrentHealthAmongCharacters <= 0) {
            Debug.Log(attacker.CharacterInGroup.name + " group is unable to continue.");
            return;
        }
        else if (defender.CurrentHealthAmongCharacters <= 0) {
            Debug.Log(defender.CharacterInGroup.name + " group is unable to continue.");
            return;
        }

        TakeTurn(attacker, defender);
    }

    private void TakeTurn(CharacterGroup attacker, CharacterGroup defender) {
        if (attacker.CurrentHealthAmongCharacters <= 0) {
            Debug.Log(attacker.CharacterInGroup.name + " group is unable to continue.");
            return;
        }
        else if (defender.CurrentHealthAmongCharacters <= 0) {
            Debug.Log(defender.CharacterInGroup.name + " group is unable to continue.");
            return;
        }
        Debug.Log(attacker.CharacterInGroup.name + " group is attacking " + defender.CharacterInGroup.name + " group.");
        int attacksLanded = 0;
        for (int i = 0; i < attacker.NumberOfCharactersInGroup; i++) {
            int attackRoll = attacker.CharacterInGroup.RollAttack();
            Debug.Log(attacker.CharacterInGroup.name + " attack roll: " + attackRoll.ToString());
            if (attackRoll > defender.CharacterInGroup.Defense.lower) {
                attacksLanded++;
            }
        }
        int tempAttacksLanded = attacksLanded;
        for (int i = 0; i < tempAttacksLanded; i++) {
            int defenseRoll = defender.CharacterInGroup.RollDefense();
            Debug.Log(defender.CharacterInGroup.name + " defense roll: " + defenseRoll.ToString());
            if (defenseRoll > attacker.CharacterInGroup.Attack.upper) {
                attacksLanded--;
            }
        }
        Debug.Log("Attacks landed: " + attacksLanded);
        defender.CurrentHealthAmongCharacters -= attacksLanded;
        if(attacksLanded <=0) {
            Debug.Log("No attacks Landed. Initiating fail safe.");
            defender.CurrentHealthAmongCharacters -= 1;
        }
        CharacterGroup.CheckCharactersAlive(defender);
        Debug.Log(defender.CharacterInGroup.name + " group is left with " + defender.CurrentHealthAmongCharacters.ToString());
        TakeTurn(defender, attacker);
    }
}
