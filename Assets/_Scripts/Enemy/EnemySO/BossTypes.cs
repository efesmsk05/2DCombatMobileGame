using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss/BossType")]

public class BossTypes : ScriptableObject
{
    public string bossName; // Name of the boss
    public int bossMaxHealth; // Health of the boss
    public AnimationClip Idle;
    public AnimationClip Hit;
    // set move speed 
    // set skill data 
    // set pahes data 
}
