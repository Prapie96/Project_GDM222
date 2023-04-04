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
    public int health = 3; // HEath PLayer start = 3;
    public GameObject effect;
    
    // Decrease Health
    public Text healthText;
    // Scene Over
    public GameObject gameOverPanel;
    void Start()
    {
        //This code Make Player still Original Position;
        targetPos = transform.position;
     }

    // Update is called once per frame
    void Update()
    {   if(health <= 0)
        {
            //show the game over panel
            gameOverPanel.SetActive(true);
        }
          if (health >= 0)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }

        healthText.text = "Health : " + health;
    }
       
    }
}
