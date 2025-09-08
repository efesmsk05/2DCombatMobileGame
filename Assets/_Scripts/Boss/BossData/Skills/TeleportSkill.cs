using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss/SkillActions/Teleport")]
public class TeleportSkill : SkillActions
{
    public override IEnumerator Execute(Boss boss)
    {
        //Debug.Log("Teleporting Boss to a random position");

        // Animasyonu baþlat ve animasyon bitiþi beklenene kadar bekle
        boss.bossAnimatonManager.isAnimationFinished = false;
        boss.SetAnimation(animationClip);


        yield return new WaitUntil(() => boss.bossAnimatonManager.isAnimationFinished);


        boss.rb.velocity = Vector2.zero; // Boss’un hareketi dursun
        boss.rb.MovePosition(new Vector2(
            Random.Range(-8f, 8f),
            boss.rb.position.y
        ));

        yield return new WaitForSeconds(0.5f);



    }

}
