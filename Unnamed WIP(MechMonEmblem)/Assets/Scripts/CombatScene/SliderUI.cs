using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    CharDistance _cd;

    Slider leftKnob;
    Slider rightKnob;
    Slider slider;

    

    // Start is called before the first frame update
    void Start()
    {
        _cd = FindObjectOfType<CharDistance>();
        leftKnob = transform.Find("LeftKnob").GetComponent<Slider>();
        rightKnob = transform.Find("RightKnob").GetComponent<Slider>();
        slider = transform.Find("Slider").GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        leftKnob.value = .5f - _cd.distancePercent / 2;
        rightKnob.value = .5f + _cd.distancePercent / 2;

        

        if(_cd.distBetweenChars == Dist.CLOSE) {
            slider.GetComponentInChildren<Image>().color = Color.red;
        }
        if (_cd.distBetweenChars == Dist.MEDIUM) {
            slider.GetComponentInChildren<Image>().color = Color.yellow;
        }
        if (_cd.distBetweenChars == Dist.FAR) {
            slider.GetComponentInChildren<Image>().color = Color.green;
        }
    }
}
