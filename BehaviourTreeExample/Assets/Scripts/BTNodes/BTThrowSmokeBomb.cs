using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTThrowSmokeBomb : BTBaseNode
{
    private Blackboard bb;
    private GameObject bomb;
    private Transform enemy;
    private Transform player;

    public BTThrowSmokeBomb(Blackboard _bb, GameObject _bomb, Transform _enemy, Transform _player)
    {
        bb = _bb;
        bomb = _bomb;
        enemy = _enemy;
        player = _player;
    }
    public override BTResult Run()
    {
        Vector3 pointA = enemy.transform.position;
        Vector3 pointB = player.transform.position;
        float a = 0.5f; 
        Vector3 pointC = Vector3.Lerp(pointA, pointB, a);
        GameObject.Instantiate(bomb, pointC, Quaternion.identity);
        return BTResult.Success;



    }


}
