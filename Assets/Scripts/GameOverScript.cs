using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{

    int score, bestScore, bestScoreEver;
    GUIStyle style;
    GUIStyleState state;

    // Use this for initialization
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        bestScore = PlayerPrefs.GetInt("Best Score");
        bestScoreEver = PlayerPrefs.GetInt("Best Score Ever");

        //try
        //{
        //    bestScore = PlayerPrefs.GetInt("Best Score");
        //    bestScore = PlayerPrefs.GetInt("Best Score Ever");
        //}
        //catch
        //{
        //    PlayerPrefs.SetInt("Best Score", 0);
        //    PlayerPrefs.SetInt("Best Score Ever", 0);
        //    bestScore = 0;
        //    bestScoreEver = 0;
        //}

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("Best Score", score);
            bestScore = score;
        }
        if (bestScore > bestScoreEver)
        {
            PlayerPrefs.SetInt("Best Score Ever", bestScore);
            bestScoreEver = bestScore;
        }
    }

    void OnGUI()
    {
        style = new GUIStyle();
        state = new GUIStyleState();
        state.textColor = new Color(0, 0, 0);
        style.fontSize = 20;
        style.active = state;
        //GUI.Label(new Rect(Screen.width / 2 - 40, 50, 80, 30), "GAME OVER", style);
        GUI.Label(new Rect(50, 35, 160, 40), "Your Score: " + score, style);
        GUI.Label(new Rect(50, 65, 180, 40), "Your Best Score: " + bestScore, style);
        GUI.Label(new Rect(50, 95, 180, 40), "BEST SCORE EVER: " + bestScoreEver, style);

        if (GUI.Button(new Rect(Screen.width / 2 - 100, 200, 60, 30), "PLAY!!!"))//, style)) 
        {
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(Screen.width / 2 + 50, 200, 60, 30), "EXIT"))//, style))
        {
            PlayerPrefs.SetInt("Best Score", 0);
            PlayerPrefs.SetInt("Score", 0);
            Application.Quit();
        }
    }
}
