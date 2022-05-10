using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health = 100;

    public void Damage(int amount)
    {
        health -= amount;
    }

    public void Heal(int amount)
    {
        health += amount;

        if(health + amount > 100)
        {
            health = 100;
        }
    }
}


