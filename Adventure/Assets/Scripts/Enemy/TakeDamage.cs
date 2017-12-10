using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    [SerializeField]
    private float insideFlame;
    public float health = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Equals("Fire"))
        {
            insideFlame = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag.Equals("Fire"))
        {
            insideFlame += Time.deltaTime;
        }

        if(insideFlame >= 1)
        {
            insideFlame = 0;
            health--;
        }
    }
}
