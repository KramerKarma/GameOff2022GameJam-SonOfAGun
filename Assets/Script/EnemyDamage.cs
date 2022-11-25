using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damageToDealt = 1f;
    // Start is called before the first frame update
    [SerializeField] float AttackAttribute = 1f;
    [SerializeField] float DefenceAttribute = 1f;
    public float DamageToDealt { get { return damageToDealt; } set { damageToDealt = value; } }
}
