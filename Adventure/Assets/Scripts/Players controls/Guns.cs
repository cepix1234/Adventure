using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour {

    public GameObject muzzle;
    public GameObject bullet;
    private float lastShot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lookatMouse();
        shoot();
	}

    void shoot()
    {
        lastShot += Time.deltaTime;
        if (Input.GetMouseButton(0) && lastShot >= 1)
        {
            lastShot = 0;
            bullet.transform.position = muzzle.transform.position;
            bullet.transform.rotation = muzzle.transform.rotation;
            bullet.GetComponent<Bullet>().set(3f,10,10,true);
            Instantiate(bullet);
        }
    }

    void lookatMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float AngleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        AngleDeg -= 90;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }


}
