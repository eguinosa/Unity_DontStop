using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour
{

    private float playerScore = 0;
    private int lifes = 0;
    GUIStyle style;

    private void Awake()
    {
        style = new GUIStyle();
        GUIStyleState state = new GUIStyleState();
        state.textColor = new Color(14, 18, 163);
        style.active = state;
    }

    public bool AnotherLife { get { return lifes > 0; } }

    // Update is called once per frame
    void Update()
    {
        playerScore += Time.deltaTime;
    }

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }

    public void FindLive()
    {
        lifes++;
    }

    public void Revive()
    {
        lifes--;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", (int)(playerScore * 100));
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Score " + (int)(playerScore * 100));
        if (lifes > 0)
        {
            GUI.Label(new Rect(11, 25, 100, 30), "Lifes : " + lifes, style);
        }

    }
}
