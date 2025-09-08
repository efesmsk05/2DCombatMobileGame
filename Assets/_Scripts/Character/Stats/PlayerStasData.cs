using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/StatsData")]

public class PlayerStasData : ScriptableObject
{
    public float maxHealth = 100f;
    public float attackPower = 10f;
    public float defense = 5f;
    public float moveSpeed = 5f;
}
