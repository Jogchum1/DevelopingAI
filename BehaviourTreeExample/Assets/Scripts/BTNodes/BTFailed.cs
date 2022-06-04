using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTFailed : BTBaseNode
{
    public override BTResult Run()
    {
        return BTResult.Failed;
    }
}
