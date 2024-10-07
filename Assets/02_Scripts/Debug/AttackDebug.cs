using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDebug : MonoBehaviour, IAttackable
{
    public void Attack(float damage)
    {

        Debug.Log(damage);

    }


}
