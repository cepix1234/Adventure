using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public List<GameObject> GunSpawPoints;
    public GameObject GunBullets;
    public GameObject FlameTrower;

	// Use this for initialization
	void Start () {
		foreach(GameObject spawn in GunSpawPoints)
        {
            GunBullets.transform.position = spawn.transform.position;
            GunBullets.transform.rotation = spawn.transform.rotation;
            GameObject gun = Instantiate(GunBullets);
            gun.transform.parent = spawn.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
