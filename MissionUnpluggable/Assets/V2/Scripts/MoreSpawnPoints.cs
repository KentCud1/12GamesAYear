using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreSpawnPoints : MonoBehaviour
{
    public bool openMoreSpawn;
    public Transform spawns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreKeeper.score > 5000) {
            openMoreSpawn = true;
        } else {
            openMoreSpawn = false;
        }
        spawns.gameObject.SetActive(openMoreSpawn);
    }
}
