using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillExecute :ScriptableObject
{
    public abstract IEnumerator Execute(PlayerStateMachine player);  // Art�k coroutine!

}
