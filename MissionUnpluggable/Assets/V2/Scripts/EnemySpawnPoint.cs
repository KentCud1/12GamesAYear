using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public Transform spawnParent;
    public Transform enemyPrefab;
    public float spawntime = 3f;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        spawnParent = transform;
        timer = spawntime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0) {
            Debug.Log("Spawn");
            SpawnEnemy();
            timer = spawntime;
        }
        if (GameStates.isGamePaused == false) {
            timer -= Time.deltaTime;
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnParent.transform.position,Quaternion.identity, spawnParent);
    }
}
