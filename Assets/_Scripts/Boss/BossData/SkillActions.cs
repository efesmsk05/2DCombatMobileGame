using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillActions : ScriptableObject
{

    public float skillDelay;
    public int damage;
    public AnimationClip animationClip; // Animation to play when the skill is executed
    public abstract IEnumerator Execute(Boss boss);  // Artýk coroutine!

}
