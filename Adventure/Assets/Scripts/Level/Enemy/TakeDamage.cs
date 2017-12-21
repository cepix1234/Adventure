using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    [SerializeField]
    private float insideFlame;
    public float health = 20;

    public List<GameObject> powerUps;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health<=0)
        {
            destroyAndCheckPowerUp();
        }
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
            health -= 5;
        }
    }

    void destroyAndCheckPowerUp()
    {
        int drop = Random.Range(0, 100);
        if(drop > 50)
        {
            int powerUp = Random.Range(0, 3);
            powerUps[powerUp].transform.position = transform.position;
            Instantiate(powerUps[powerUp]);
        }
        Camera.main.GetComponent<EnemysKilled>().enemyKilled();
        Destroy(this.gameObject);
    }
}
