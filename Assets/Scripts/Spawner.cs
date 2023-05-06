using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float timeDecrease;
    public float minTime;

    public GameObject[] obstacleTemplate;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

  private void Update()
{
    ScoreManager scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    float currentScore = scoreManager.GetScore();

    if (timeBtwSpawns <= 0)
    {
        int rand = Random.Range(0, obstacleTemplate.Length);
        Instantiate(obstacleTemplate[rand], transform.position, Quaternion.identity);
        timeBtwSpawns = Random.Range(minTime, startTimeBtwSpawns); //ลดเวลาระหว่างการสร้าง

        //เช็คว่าเป็นเลข Fibonacci หรือไม่ ถ้าใช่ก็ลดเวลาการสร้าง
        if (isFibonacci((int)currentScore)) { 
            timeBtwSpawns -= timeDecrease;
        }
    }
    else {
        timeBtwSpawns -= Time.deltaTime;
    }
}

private bool isFibonacci(int n) {
    int a = 0, b = 1, c = 1;
    while (c < n) {
        c = a + b;
        a = b;
        b = c;
    }
    return c == n;
}


}
