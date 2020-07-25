using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static int score;
    public static int robotsControlled;
    public static int robotsDestroyed;
    // Start is called before the first frame update
    void Awake()
    {
        score = robotsControlled = robotsDestroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
