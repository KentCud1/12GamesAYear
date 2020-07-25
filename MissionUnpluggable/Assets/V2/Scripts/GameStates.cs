using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour
{
    public static bool isGamePaused = true;
    public static bool isGameOver = false;
    public static bool showScores = false;
    // Start is called before the first frame update
    private void Awake() {
        isGamePaused = true;
        isGameOver = false;
        showScores = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        isGamePaused = false;
    }
    public void ShowScores() {
        showScores = true;
    }
    public void ResetLevel() {
        SceneManager.LoadScene("V2");
    }
}
