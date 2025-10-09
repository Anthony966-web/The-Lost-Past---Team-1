using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoblinHealth : MonoBehaviour
{
    public float Health
    {
        set
        {
            _health = value;

            if (_health <= 0) 
            {
                Destroy(gameObject);
            }
        }
        
        get 
        { 
            return _health; 
        }
    }

    public float _health = 3f;

    public void OnHit(float damage)
    {
       Debug.Log("Goblin hit for " + damage + " damage.");
        _health -= damage;
    }
}

