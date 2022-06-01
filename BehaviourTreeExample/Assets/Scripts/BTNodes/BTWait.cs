using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTWait : BTBaseNode
{
    private float waitTime;
    private float currentTime;
    public BTWait(float _waitTime)
    {
        waitTime = _waitTime;
    }
    public override BTResult Run()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= waitTime)
        {
            currentTime = 0;
            return BTResult.Success;
        }
        return BTResult.Running;
    }

}
