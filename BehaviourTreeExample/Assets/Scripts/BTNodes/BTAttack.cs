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
        Vector3 dirToTarget = (attackedObject.transform.position - attacker.transform.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(attacker.transform.position, dirToTarget, out hit, 20) && hit.transform.tag != "Smoke")
        {
            
            if (attackedObject.TryGetComponent(out Player player))
            {
                player.TakeDamage(attacker, damage);
                return BTResult.Success;
            }
            return BTResult.Running;
        }
        else
        {
            return BTResult.Failed;
        }
           
    }
}
