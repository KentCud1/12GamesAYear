using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTimer : MonoBehaviour
{
    [HideInInspector]
    public float time, timer;

    Text text;

    Color textColor;

    // Start is called before the first frame update
    void Start()
    {
        textColor = Color.green;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text =  ((float)Mathf.Round((timer - time) * 100.0f) / 100.0f).ToString();

        if (time < timer/2) {
            textColor = Color.Lerp(Color.green, Color.yellow, time / (timer/2));
        }
        else {
            textColor = Color.Lerp(Color.yellow, Color.red, (time-timer/2) / (timer/2));
        }
        text.color = textColor;
    }
}
