﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float lifetime;
    [SerializeField]
    private bool FiredByPlayer;

    // Use this for initialization
    void Start () {
        		
	}
	
	// Update is called once per frame
	void Update () {
        die();
        move();
	}

    public void  set(float _speed, float _damage, float _lifetime, bool _firedByPlayer)
    {
        speed = _speed;
        damage = _damage;
        lifetime = _lifetime;
        FiredByPlayer = _firedByPlayer;
    }

    void move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void die()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(this.transform.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool destroy = false;
        if(FiredByPlayer && other.tag.Equals("Enemy"))
        {
            other.transform.GetComponent<TakeDamage>().health -= damage;
            destroy = true;
        }
        else if(!FiredByPlayer && other.tag.Equals("Player"))
        {
            other.transform.GetComponent<PlayerHealth>().takeDamage(damage);
            destroy = true;
        }
        else if(other.tag.Equals("Map"))
        {
            destroy = true;
        }

        if(destroy)
        {
            Destroy(this.gameObject);
        }
    }

}
