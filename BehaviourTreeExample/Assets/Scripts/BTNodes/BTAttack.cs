using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAttack : BTBaseNode
{
    private GameObject attackedObject;
    private GameObject attacker;
    private int damage;
    public BTAttack(GameObject _attackedObject, GameObject _attacker, int _damage)
    {
        attackedObject = _attackedObject;
        attacker = _attacker;
        damage = _damage;
    }
    public override BTResult Run()
    {
        Debug.Log("ATTACKING");
        if(attackedObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(attacker, damage);
            return BTResult.Success;
        }
        return BTResult.Running;
    }
}
