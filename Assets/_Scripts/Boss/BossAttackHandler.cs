using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackHandler : MonoBehaviour
{
    public GameObject attackHitbox; // Sa� tarafa yerle�tirdi�in objeyi buraya ata
    Vector2 boxSize = new Vector2(2.65f, 3.54f); // Vuru� kutusu boyutu
    public LayerMask playerLayer; // Enemy'yi buraya set et
    public PlayerStatsManager player; // Player'� buraya set et
    public Boss boss; // Boss'u buraya set et


    public void BossActivateHitbox()
    {

        // Hitbox pozisyonuna g�re tarama yap
        Vector2 hitboxPos = attackHitbox.transform.position;
        Collider2D[] hits = Physics2D.OverlapBoxAll(hitboxPos, boxSize, 0f, playerLayer);

        foreach (Collider2D hit in hits)
        {

            if (player != null)
            {
                float damage = boss.bossData[0].phases[boss.bossData[0].currentPhaseIndex].skills[boss.currentSkill].damage; // Boss'un hasar�n� al

                player.TakeDamage(damage);
            }
        }
    }


    // Hitbox'� sahnede g�rmek i�in
}
