using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    private float speed;
    private int damage;
    private Vector2 direction;
    private PlayerStatsManager playerStatsManager;
    public void Initialize(Vector2 dir, float spd, int dmg)
    {
        direction = dir.normalized;
        speed = spd;
        damage = dmg;
    }


    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(direction * speed * Time.deltaTime);
        Destroy(this.gameObject , 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStatsManager = collision.GetComponentInParent<PlayerStatsManager>();
            if (playerStatsManager != null)
            {
                print("Player hit by fireball");
                playerStatsManager.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }

            

    }
}
