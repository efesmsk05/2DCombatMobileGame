using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Boss/SkillActions/ThrowObject")]

public class ThrowObject : SkillActions
{
    public float speed;
    public GameObject objectPrefab;

    public override IEnumerator Execute(Boss boss)
    {
        yield return new WaitForSeconds(1.5f);

        boss.SetAnimation(this.animationClip);


        GameObject thrownObject = Instantiate(objectPrefab, boss.rb.transform.position, Quaternion.identity);

        Vector2 playerDirection = (boss.player.transform.position - boss.rb.transform.position).normalized;

        var fireball = thrownObject.GetComponent<FireBall>();
        if (fireball != null)
        {
            fireball.Initialize(playerDirection, speed, damage);
        }
        else
        {
            Debug.LogWarning("FireBall component not found on the thrown object.");
        }

        yield return new WaitForSeconds(.2f);

    }
}
