﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HishScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    private void Awake() {
        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 20f;
        for(int i = 0; i < 10; i++) {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch(rank) {
                default:
                    rankString = rank + "th"; break;

                case 1: rankString = "1st"; break;
                case 2: rankString = "2nd"; break;
                case 3: rankString = "3rd"; break;
            }
            entryTransform.Find("posText").GetComponent<Text>().text = rankString;
            entryTransform.Find("scoreText").GetComponent<Text>().text = "";
            entryTransform.Find("nameText").GetComponent<Text>().text = "";

        }
    }
}
