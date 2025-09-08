using UnityEngine;
using System.Collections;

public class AttackHandler : MonoBehaviour
{
    public GameObject attackHitbox; // Sað tarafa yerleþtirdiðin objeyi buraya ata
    public Vector2 boxSize = new Vector2(1f, 1f); // Vuruþ kutusu boyutu
    public LayerMask enemyLayer; // Enemy'yi buraya set et
    public PlayerStatsManager playerStatsManager; // Player Stats Manager referansý
    public ComboInputHandler currentSkill;


    
    private Enemy enemy;
    private Boss boss; 

    public void ActivateHitbox()
    {

        // Hitbox pozisyonuna göre tarama yap
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
        // Ýstersen burada görsel efekt kapatabilirsin
    }


    IEnumerator HitStop(float duration)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
    // Hitbox'ý sahnede görmek için

}
