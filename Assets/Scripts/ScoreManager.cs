using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private float score;
    public Player player;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null && player.health > 0)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = "Score: " + ((int)score).ToString();

           
        }
    }
    public float GetScore() {
    return score;
}

}
