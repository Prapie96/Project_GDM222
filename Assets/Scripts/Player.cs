using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;

    public float speed;
    public float maxHeight;
    public float minHeight;
    public int health = 3; // Health Player start = 3;
    public GameObject effect;

    // Add Sound Move
    AudioSource movesound;

    // Decrease Health
    public Text healthText;

    // Scene Over
    public GameObject gameOverPanel;

    void Start()
    {
        targetPos = transform.position;
        movesound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (health <= 0)
        {

            gameOverPanel.SetActive(true);

        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
            {
                MoveUp();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
            {
                MoveDown();
            }


        }
        if(health >= 0 )
        {
            healthText.text = "Health: " + health;
        }

    }

    public void MoveUp()
    {
        if (transform.position.y < maxHeight)
    {
        movesound.Play();
        Instantiate(effect, transform.position, Quaternion.identity);
        targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
    }
    }

    public void MoveDown()
    {
        if(transform.position.y > minHeight){
        movesound.Play();
        Instantiate(effect, transform.position, Quaternion.identity);
        targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }

    }
}