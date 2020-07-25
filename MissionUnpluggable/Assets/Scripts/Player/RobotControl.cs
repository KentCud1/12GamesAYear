using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    PlayerControl _pc;
    RobotStats _stats;
    float batteryLife;
    Rigidbody2D _rb;

    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        _pc = GetComponent<PlayerControl>();
        _stats = GetComponent<RobotStats>();
        _rb = GetComponent<Rigidbody2D>();
        if(_stats != null) {
            batteryLife = _stats.MaxBatteryLife;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if(_pc != null) {
            velocity = _pc.Axes;
        }

        

        if(batteryLife <= 0f) {
            Debug.Log("Out of Battery!!!");
        }

        if(_stats != null) {
            velocity *= _stats.Speed;
            if(_stats.IsPluggedIn) {
                batteryLife += Time.deltaTime;
            }
            else {
                batteryLife -= Time.deltaTime;
            }
            Debug.Log("Switching control " + (_stats.IsUnderControl ? "On": "Off"));
            batteryLife = Mathf.Clamp(batteryLife, 0f, _stats.MaxBatteryLife);

            if(!_stats.IsUnderControl) {
                velocity *= -1;
            }
        }

        //transform.position = pos + velocity * Time.deltaTime;
        _rb.velocity = velocity;
    }
}
