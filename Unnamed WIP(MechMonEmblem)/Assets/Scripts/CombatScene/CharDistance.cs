using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDistance : MonoBehaviour
{
    CombatMovement[] combats;
    float distance;
    public float distancePercent;

    GroundConstraints _gc;


    public Dist distBetweenChars;
    // Start is called before the first frame update
    void Start()
    {
        _gc = GetComponent<GroundConstraints>();

        combats = FindObjectsOfType<CombatMovement>();
        if (combats.Length > 1) {
            distance = Mathf.Abs(combats[0].transform.position.x - combats[1].transform.position.x);
            distancePercent = distance / (float)_gc.constrainedArea.x;
        }
        
        if(distancePercent < .3f) {
            distBetweenChars = Dist.CLOSE;
        }
        else if(distancePercent < .7f) {
            distBetweenChars = Dist.MEDIUM;
        }
        else {
            distBetweenChars = Dist.FAR;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (combats.Length > 1) {
            distance = Mathf.Abs(combats[0].transform.position.x - combats[1].transform.position.x);
            distancePercent = distance / (float)_gc.constrainedArea.x;
        }

        if (distancePercent < .3f) {
            distBetweenChars = Dist.CLOSE;
        }
        else if (distancePercent < .7f) {
            distBetweenChars = Dist.MEDIUM;
        }
        else {
            distBetweenChars = Dist.FAR;
        }

    }
}
public enum Dist {
    CLOSE,
    MEDIUM,
    FAR
}
