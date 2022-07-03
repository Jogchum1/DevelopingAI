using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAttack : BTBaseNode
{
    private GameObject attackedObject;
    private GameObject attacker;
    private int damage;
    private Blackboard bb;
    public BTAttack(GameObject _attackedObject, GameObject _attacker, int _damage, Blackboard _bb)
    {
        attackedObject = _attackedObject;
        attacker = _attacker;
        damage = _damage;
        bb = _bb;
    }
    public override BTResult Run()
    {
        Vector3 dirToTarget = (attackedObject.transform.position - attacker.transform.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(attacker.transform.position, dirToTarget, out hit, 20) && hit.transform.tag != "Smoke")
        {
            
            if (attackedObject.TryGetComponent(out Player player))
            {
                if(player.Health > 0)
                {
                    player.TakeDamage(attacker, damage);
                    return BTResult.Success;
                }
                else
                {
                    bb.SetValue<bool>("PlayerAlived", false);

                }
            }
            return BTResult.Running;
        }
        else
        {
            return BTResult.Failed;
        }
           
    }
}
