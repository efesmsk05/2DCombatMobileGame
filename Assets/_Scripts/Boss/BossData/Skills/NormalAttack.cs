using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss/SkillActions/normalAttack")]

public class NormalAttack : SkillActions
{
    public override IEnumerator Execute(Boss boss)
    {
        
        boss.SetAnimation(this.animationClip);

        yield return new WaitForSeconds(animationClip.length);

    }
}
