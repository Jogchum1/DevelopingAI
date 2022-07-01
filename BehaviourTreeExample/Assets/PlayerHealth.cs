using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public Player player;

    public void HealthCount()
    {
        Health--;
    }
}
