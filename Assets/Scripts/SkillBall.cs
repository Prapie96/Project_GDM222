using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SkillBall : MonoBehaviour
{
    public GameObject bulletPrefab;
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
    public void ActivateSkill()
{
    if (isReady)
    {
        StartCoroutine(ShootBurst());
    }
}


    private IEnumerator ShootBurst()
    {
        isReady = false;
        float goldenRatio = (1 + Mathf.Sqrt(5)) / 2;
        float angle = 0f;
        float radius = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            angle += Mathf.PI * 2 * goldenRatio;
            radius += bulletVelocity * timeBetweenBullets;

            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            Vector2 direction = new Vector2(x, y);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            rb.velocity = direction.normalized * bulletVelocity;

            Destroy(bullet, 3f);

            yield return new WaitForSeconds(timeBetweenBullets);
        }

        yield return new WaitForSeconds(cooldown);
        isReady = true;
    }
}