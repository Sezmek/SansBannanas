using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneShot : MonoBehaviour
{
    private Transform player => GameObject.FindGameObjectWithTag("Player").transform;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    bool rotate = true;

    void Update()
    {
        if (rotate)
        {
            Vector2 directionToPlayer = player.position - transform.position;

            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
    public void Shoot(float ShootSpeed)
    {
        rotate = false;
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rb.velocity = directionToPlayer * ShootSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player playerScript = collision.gameObject.GetComponent<Player>();

        if (playerScript != null)
        {
            playerScript.GetDMG(transform.tag, this.gameObject);
        }
    }
}
