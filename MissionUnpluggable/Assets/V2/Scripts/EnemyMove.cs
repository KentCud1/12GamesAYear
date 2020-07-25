using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int health = 2;

    public Transform playerTarget;
    public Transform target;

    public float speed = 1f;
    public float attackTime = 1f;
    public float range = 1f;

    float timer;

    public bool isControlledByPlayer;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = FindObjectOfType<BaseHealth>().transform;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStates.isGamePaused == false) {
            if (health <= 0) {
                ScoreKeeper.robotsDestroyed++;
                ScoreKeeper.score += 50;
                Destroy(gameObject);
            }
            if (!isControlledByPlayer) {
                EnemyMove controlledEnemy = CheckForAttackingRobots();
                if (controlledEnemy != null) {
                    target = controlledEnemy.transform;
                    if (sprite != null) {
                        sprite.color = Color.yellow;
                    }
                }
                else {
                    target = playerTarget;
                    if (sprite != null) {
                        sprite.color = Color.white;
                    }
                }

            }
            if (isControlledByPlayer) {
                if(sprite != null) {
                    sprite.color = Color.green;
                }
                EnemyMove currentTarget = null;
                if (target != null) {
                    currentTarget = target.GetComponent<EnemyMove>();
                }
                if (currentTarget != null) {
                    if (currentTarget.isControlledByPlayer) {
                        FindTarget();
                    }
                }
                if (target == null || target == playerTarget) {
                    FindTarget();
                }
            }
            if (target != null) {
                transform.up = target.position - transform.position;
            }

            Vector2 velocity = Vector2.zero;
            if (target != null) {
                velocity = transform.up * speed;
                if (Mathf.Abs(Vector2.Distance(target.transform.position, transform.position)) < range) {
                    velocity = Vector2.zero;
                }
                transform.position += (Vector3)velocity * Time.deltaTime;
            }
            if (target != null) {
                if (Mathf.Abs(Vector2.Distance(target.transform.position, transform.position)) < range) {
                    if (timer <= 0f) {
                        Attack();
                        timer = attackTime;
                    }
                    timer -= Time.deltaTime;
                }
            }
        }

    }

    void FindTarget() {
        EnemyMove[] targets = FindObjectsOfType<EnemyMove>();
        target = null;
        foreach( EnemyMove em in targets) {

            if (em.transform == transform) continue;
            if (!em.isControlledByPlayer) {
                if (target == playerTarget) target = em.transform;
                if (target == null) {
                    target = em.transform;
                }
                else {
                    if (Vector2.Distance(target.transform.position, transform.position) > Vector2.Distance(em.transform.position, transform.position)) {
                        target = em.transform;
                    }
                }
            }

        }
    }

    EnemyMove CheckForAttackingRobots() {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, playerTarget.position);
        EnemyMove newTarget = null;
        if(hits.Length > 0) {
            foreach(RaycastHit2D hit in hits) {
                if (hit.transform == transform) continue;
                EnemyMove em = hit.transform.GetComponent<EnemyMove>();
                if (em == null) continue;
                if (!em.isControlledByPlayer) continue;
                newTarget = em;
            }
        }
        return newTarget;
    }

    void Attack() {
        EnemyMove currentTarget = target.GetComponent<EnemyMove>();
        if(currentTarget != null) {
            Debug.Log("Hit " + currentTarget.name);
            currentTarget.health -= 1;
        }

        BaseHealth baseHealth = target.GetComponent<BaseHealth>();
        if(baseHealth != null) {
            Debug.Log("Player hit.");
            baseHealth.health -= 1;
        }
    }
}
