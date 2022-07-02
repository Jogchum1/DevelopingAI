using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCheckPlayer : BTBaseNode
{
    private GameObject player;
    public BTCheckPlayer(GameObject _player)
    {
        player = _player;
    }

    public override BTResult Run()
    {
        if(player.GetComponent<Player>().isAttacked == true)
        {
            return BTResult.Success;
        }
        else
        {
            return BTResult.Failed;
        }
    }

    
}
