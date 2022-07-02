using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTDoAnimation : BTBaseNode
{
    private Animator anim;
    private string animParam;
    private bool setState = false;
    public BTDoAnimation(Animator _anim, string _animParam)
    {
        anim = _anim;
        animParam = _animParam;
        //setState = _setState;
    }
    public override BTResult Run()
    {

        anim.Play(animParam, -1, 0.5f);
        return BTResult.Success;



    }
}
