using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSequence : BTBaseNode
{
    private BTBaseNode[] children;
    private int currentIndex = 0;
    public BTSequence(params BTBaseNode[] _children)
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
