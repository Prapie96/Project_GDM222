using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBall : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spiralRotationRate;
    public int bulletCount;
    public float bulletVelocity;
    public float timeBetweenBullets;
    public float cooldown;
   

    private bool isReady = true;

    private void Update()
    {
        if (isReady && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShootBurst());
        }
    }

    private IEnumerator ShootBurst()
    {
        isReady = false;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            angle += spiralRotationRate * Time.deltaTime;
            float x = -Mathf.Cos(angle);
            float y = -Mathf.Sin(angle);
            Vector2 direction = new Vector2(x, y);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            rb.velocity = direction * bulletVelocity;

            Destroy(bullet, 3f);

            yield return new WaitForSeconds(timeBetweenBullets);
        }

        yield return new WaitForSeconds(cooldown);
        isReady = true;
    }
}
