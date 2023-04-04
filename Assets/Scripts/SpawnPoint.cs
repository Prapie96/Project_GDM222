using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{   
    public GameObject Obstacle;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Obstacle,transform.position,Quaternion.identity);
        
    }

  
}
