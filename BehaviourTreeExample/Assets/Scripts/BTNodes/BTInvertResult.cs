using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTInvertResult : BTBaseNode
{
    private BTBaseNode[] children;
    private int currentIndex = 0;
    public BTInvertResult(params BTBaseNode[] _children)
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
                case BTResult.Failed:
                    return BTResult.Success;
                case BTResult.Running:
                    return BTResult.Running;
                case BTResult.Success: 
                    return BTResult.Failed;

            }
        }
        return BTResult.Success;
    }
}
