using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelector : BTBaseNode
{
    private BTBaseNode[] children;
    private int currentIndex = 0;
    public BTSelector(params BTBaseNode[] _children)
    {
        children = _children;
    }

    public override BTResult Run()
    {
        for (; currentIndex < children.Length; currentIndex++)
        {
            BTResult result = children[currentIndex].Run();
            switch (result)
            {
                case BTResult.Failed: break;
                case BTResult.Running:
                    return BTResult.Running;
                case BTResult.Success:
                    currentIndex = 0;
                    return BTResult.Success;

            }
        }
        currentIndex = 0;
        return BTResult.Failed;
    }
}
