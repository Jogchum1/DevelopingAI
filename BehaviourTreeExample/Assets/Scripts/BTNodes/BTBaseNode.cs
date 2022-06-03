using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTResult { Success, Failed, Running }
public abstract class BTBaseNode
{
    public abstract BTResult Run();
    public virtual void OnEnter() {

    }
}
