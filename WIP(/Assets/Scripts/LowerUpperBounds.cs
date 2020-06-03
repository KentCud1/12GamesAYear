using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LowerUpperBounds
{
    public int lower;
    public int upper;

    public LowerUpperBounds(int lower, int upper) {
        this.lower = lower;
        this.upper = upper;
    }
}
