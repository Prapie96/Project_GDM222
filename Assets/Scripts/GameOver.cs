using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour
{   
    public void Restart()
    {   //LoadAd();
       // ShowAd();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          
    }


}
