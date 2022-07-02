using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPickUp : BTBaseNode
{
    private Blackboard bb;
    private bool CheckWeapon;
    private GameObject weapon;
    private GameObject Guard;

    public BTPickUp(Blackboard _bb, GameObject _weapon, GameObject _guard)
    {
        bb = _bb;
        weapon = _weapon;
        Guard = _guard;
    }

    public override BTResult Run()
    {
        weapon.transform.SetParent(Guard.transform);
        weapon.GetComponent<BoxCollider>().isTrigger = true;
        Debug.Log(CheckWeapon);

        bb.SetValue<bool>("HasWeapon", true);
        CheckWeapon = bb.GetValue<bool>("HasWeapon");
        Debug.Log(CheckWeapon);

        return BTResult.Success;
    }
}
