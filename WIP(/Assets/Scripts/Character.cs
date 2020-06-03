using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
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
        get;set;
    }
    public int Speed {
        get; set;
    }
    public LowerUpperBounds Attack {
        get;set;
    }
    public LowerUpperBounds Defense
    {
        get; set;
    }

    public void Start() {
    }



}



