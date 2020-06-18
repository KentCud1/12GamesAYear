using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters/New Character")]
public class Character : ScriptableObject
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int speed;
    [SerializeField]
    private LowerUpperBounds attack;
    [SerializeField]
    private LowerUpperBounds defense;

    public int Health {
        get => health;
    }
    public int Speed {
        get => speed;
    }
    public LowerUpperBounds Attack {
        get => attack;
    }
    public LowerUpperBounds Defense {
        get => defense;
    }

    private int RollUpperLower(LowerUpperBounds lowerUpper) {
        return Random.Range(lowerUpper.lower, lowerUpper.upper + 1);
    }

    public int RollAttack() {
        return RollUpperLower(attack);
    }

    public int RollDefense() {
        return RollUpperLower(defense);
    }

}



