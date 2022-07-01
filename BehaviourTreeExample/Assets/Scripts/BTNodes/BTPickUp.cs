using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPickUp : BTBaseNode
{
    private Blackboard bb;
    private bool CheckWeapon;

    public BTPickUp(Blackboard _bb)
    {
        bb = _bb;
    }

    public override BTResult Run()
    {
        Debug.Log(CheckWeapon);

        bb.SetValue<bool>("HasWeapon", true);
        CheckWeapon = bb.GetValue<bool>("HasWeapon");
        Debug.Log(CheckWeapon);

        return BTResult.Success;
    }
}
