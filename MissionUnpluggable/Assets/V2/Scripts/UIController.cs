using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Transform childPanel;
    public Transform gameOver;
    public Transform startGame;
    public Transform scores;
    public Text score;
    public Text gameOverScore;
    public Text health;

    // Start is called before the first frame update
    void Start()
    {
        childPanel = transform.Find("Panel");
        score = transform.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        childPanel.gameObject.SetActive(GameStates.isGamePaused);
        gameOver.gameObject.SetActive(GameStates.isGameOver && !GameStates.showScores);
        startGame.gameObject.SetActive(!GameStates.isGameOver);
        scores.gameObject.SetActive(GameStates.showScores);

        score.text = "Score: " + ScoreKeeper.score;
        gameOverScore.text = "Score: " + ScoreKeeper.score +
                           "\nRobots Controlled: " + ScoreKeeper.robotsControlled +
                           "\nRobots Destroyed: " + ScoreKeeper.robotsDestroyed;
        health.text = "Health: " + FindObjectOfType<BaseHealth>().health;
    }
}
