using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boss/SkillActions/chase")]

public class Chase : SkillActions
{

    public override IEnumerator Execute(Boss boss)
    {
        boss.SetAnimation(this.animationClip);

        // Boss'u oyuncuya doðru hareket ettir
        Vector3 direction = (boss.player.transform.position - boss.transform.position).normalized;
        float moveSpeed = 1.5f; // Boss'un hareket hýzý, ihtiyaca göre ayarlayabilirsiniz

        float chaseDuration = 5f;
        float elapsed = 0f;

        while (elapsed < chaseDuration)
        {
            Vector3 directionCurrnet = (boss.player.transform.position - boss.transform.position).normalized;


            directionCurrnet.y = 0; // Y eksenindeki hareketi sýfýrla
            directionCurrnet.Normalize(); // Yönü normalize et
            //if (directionCurrnet.x > 0)
            //{
            //    boss.spriteRenderer.flipX = false; // Sað tarafa bak
            //}
            //else
            //{
            //    boss.spriteRenderer.flipX = true; // Sol tarafa bak
            //}
            boss.transform.position += directionCurrnet * moveSpeed * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
