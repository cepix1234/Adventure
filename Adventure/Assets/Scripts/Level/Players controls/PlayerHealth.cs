using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {


    [SerializeField]
    private float health = 50;
    
    public void takeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, 50);
    }

    public void getHealth (float _healht)
    {
        health += _healht;
        health = Mathf.Clamp(health, 0, 50);
    }

    public float returnHelth()
    {
        return health;
    }
}
