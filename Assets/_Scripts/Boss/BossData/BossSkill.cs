using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss/Skill")]
public class BossSkill : ScriptableObject
{
    public string skillName;
    public int cooldown;
    public int damage;
    public List<SkillActions> actions;
    private Coroutine activeCoroutine;

    public void Execute(Boss boss)
    {
        if (activeCoroutine != null)
            boss.StopCoroutine(activeCoroutine); // �nceki coroutine�i durdur

        activeCoroutine = boss.StartCoroutine(ExecuteRoutine(boss));
    }

    private IEnumerator ExecuteRoutine(Boss boss)
    {
        foreach (var action in actions)
        {
            yield return boss.StartCoroutine(action.Execute(boss));
        }
        // hepsi bittikten sonra idle state'e geri d�n
        boss.ChangeState(new BossIdleState(boss));

    }
}