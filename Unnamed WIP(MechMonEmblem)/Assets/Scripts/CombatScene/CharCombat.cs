using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCombat : MonoBehaviour
{

    public int health;

    public CloseAttack closeAttack;
    //close attack,
    public MediumAttack mediumAttack;
    //med attack.
    public FarAttack farAttack;
    //far attack.

    public bool turnIsFinished;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(Dist dist, CharCombat other) {
        if(dist == Dist.CLOSE) {
            other.health -= CalculateDamageFromAttack(closeAttack);
            Debug.Log(name + " has attacked with " + closeAttack.name + ". " + other.name + " has received "+ closeAttack.damage + " damage.");
        }
        else if(dist == Dist.MEDIUM) {
            other.health -= CalculateDamageFromAttack(mediumAttack);
            Debug.Log(name + " has attacked with " + mediumAttack.name + ". " + other.name + " has received " + mediumAttack.damage + " damage.");
        }
        else if(dist == Dist.FAR) {
            other.health -= CalculateDamageFromAttack(farAttack);
            Debug.Log(name + " has attacked with " + farAttack.name + ". " + other.name + " has received " + farAttack.damage + " damage.");
        }

        
        turnIsFinished = true;
    }

    int CalculateDamageFromAttack(Attack atk) {
        int damage = 0;
        damage = atk.damage;
        return damage;
    }
}
