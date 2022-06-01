using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTDebug : BTBaseNode
{
    private string debugMessage;

    public BTDebug(string _debugMessage)
    {
        debugMessage = _debugMessage;
    }
    public override BTResult Run()
    {
        Debug.Log(debugMessage);
        return BTResult.Success;
    }
}

