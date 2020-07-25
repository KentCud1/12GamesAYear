using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStats : MonoBehaviour
{
    [SerializeField]
    private float maxBatteryLife = 1f;
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private bool isPluggedIn;
    [SerializeField]
    private bool isUnderControl;

    private float timer;
    [SerializeField]
    private float underControlTimer = 1f;

    private bool hasKeyCard;


    public float MaxBatteryLife => maxBatteryLife;
    public float Speed => speed;

    public bool IsPluggedIn => isPluggedIn;
    public bool IsUnderControl => isUnderControl;
    public bool HasKeyCard => hasKeyCard;

    // Start is called before the first frame update
    void Start()
    {
        timer = underControlTimer;
    }

    // Update is called once per frame
    void Update() {
        if (timer <= 0.0f) {
            isUnderControl = true;
            timer = underControlTimer;
        }
        if (!IsUnderControl) {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Plug") {
            isPluggedIn = true;
        }
        if(collision.tag == "KeyCard") {
            Destroy(collision.gameObject);
            hasKeyCard = true;
        }
        if(collision.tag == "Exit") {
            if(HasKeyCard) {
                Debug.Log("Level complete");
            }
        }
        if(collision.tag == "Enemy" && IsUnderControl) {
            isUnderControl = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
       if(isPluggedIn == true) {
            isPluggedIn = false;
        }
    }
}
