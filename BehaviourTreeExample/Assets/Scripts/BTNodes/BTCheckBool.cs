using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCheckBool : BTBaseNode
{
    private BTBaseNode[] children;
    private int currentIndex = 0;
    

    private Blackboard bb;
    private string boolToCheck;
    private bool CheckBool;
    public BTCheckBool(Blackboard _bb, string _boolToCheck, params BTBaseNode[] _children)
    {
        bb = _bb;
        children = _children;
        boolToCheck = _boolToCheck;

    }
    public override BTResult Run()
    {
        CheckBool = bb.GetValue<bool>(boolToCheck);
        if (CheckBool == true)
        {
            return BTResult.Success;
        }
        else
        {

            for (; currentIndex < children.Length; currentIndex++)
            {
                BTResult result = children[currentIndex].Run();
                switch (result)
                {
                    case BTResult.Failed:
                        currentIndex = 0;
                        return BTResult.Failed;
                    case BTResult.Running:
                        return BTResult.Running;
                    case BTResult.Success: break;

                }
            }
            currentIndex = 0;
            return BTResult.Success;
        }
    }
}
