using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{   
    public int damage = 1;
    public float speed;
    public GameObject effect;

 
    void Update(){
        transform.Translate(Vector2.left*speed*Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            //Play Effect when Player hit obstacle !!!
            Instantiate(effect,transform.position,Quaternion.identity);
            //PLayer Crash Obstacle Take Damage
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
           //Decrease Health Player's
           
        }
        else if (other.CompareTag("Border")){
            Destroy(gameObject);

        }
        else if (other.CompareTag("Ball"))
        {
            Destroy(gameObject);
            
        }

    }
}
