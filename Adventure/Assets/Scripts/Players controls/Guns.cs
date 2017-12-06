using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour {

    public GameObject muzzle;
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
        if (Input.GetMouseButton(0) && lastShot >= 2)
        {
            lastShot = 0;
            //shoot bullet or what ever
            Debug.Log("SHOOT");
        }
    }

    void lookatMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float AngleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }


}
