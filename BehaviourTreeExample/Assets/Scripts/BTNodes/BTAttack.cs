using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAttack : BTBaseNode
{
    public override BTResult Run()
    {
        Debug.Log("ATTACKING");
        return BTResult.Running;
    }
}
