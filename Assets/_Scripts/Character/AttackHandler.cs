using UnityEngine;
using System.Collections;

public class AttackHandler : MonoBehaviour
{
    public GameObject attackHitbox; // Sa� tarafa yerle�tirdi�in objeyi buraya ata
    public Vector2 boxSize = new Vector2(1f, 1f); // Vuru� kutusu boyutu
    public LayerMask enemyLayer; // Enemy'yi buraya set et
    public PlayerStatsManager playerStatsManager; // Player Stats Manager referans�
    public ComboInputHandler currentSkill;


    
    private Enemy enemy;
    private Boss boss; 

    public void ActivateHitbox()
    {

        // Hitbox pozisyonuna g�re tarama yap
        Vector2 hitboxPos = new Vector2(attackHitbox.transform.position.x + currentSkill.currentSkill.hitboxOffsetX , attackHitbox.transform.position.y); 
        Vector2 hitBoxSize = currentSkill.currentSkill.hitboxSize;
        Collider2D[] hits = Physics2D.OverlapBoxAll(hitboxPos, hitBoxSize, 0f, enemyLayer);

        foreach (Collider2D hit in hits)
        {
            StartCoroutine(HitStop(.065f)); // Hit stop efekti

            // Kamera shake ekle
            if (CameraShake.Instance != null)
                StartCoroutine(CameraShake.Instance.Shake(0.08f, 0.01f));

            boss = hit.GetComponentInParent<Boss>();
            float damage = playerStatsManager.attackPower + currentSkill.currentSkill.damage;
            boss.ChangeState(new BossTakeDamageState(boss , damage));
        }
        
    }

    public void DeactivateHitbox()
    {
        // �stersen burada g�rsel efekt kapatabilirsin
    }


    IEnumerator HitStop(float duration)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
    // Hitbox'� sahnede g�rmek i�in

}
