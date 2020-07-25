using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    public int maxControls;
    public LayerMask _lm;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStates.isGamePaused == false) {
            if (Input.GetMouseButtonDown(0)) {
                EnemyMove enemy = ClickControl.GetTransformOnClick(_lm).GetComponent<EnemyMove>();
                if (enemy != null) {
                    if (Vector2.Distance(enemy.transform.position, transform.position) <= transform.Find("RangeCircle").localScale.x / 2) {
                        if(!enemy.isControlledByPlayer) {
                            ScoreKeeper.robotsControlled++;
                            ScoreKeeper.score += 20;
                        }
                        enemy.isControlledByPlayer = true;
                    }
                }
            }
        }
    }
}
