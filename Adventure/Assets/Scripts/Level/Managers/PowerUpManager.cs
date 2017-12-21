using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public List<GameObject> GunSpawPoints;
    public GameObject GunBullets;

	// Use this for initialization
	void Start () {
        replaceWapons(GunBullets);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void replaceWapons(GameObject weapon)
    {
        foreach (GameObject spawn in GunSpawPoints)
        {
            int froci = spawn.transform.childCount;
            for(int i = 0; i<froci;i++)
            {
                Destroy(spawn.transform.GetChild(i).gameObject);
            }
            weapon.transform.position = spawn.transform.position;
            weapon.transform.rotation = spawn.transform.rotation;
            GameObject gun = Instantiate(weapon);
            gun.transform.parent = spawn.transform;
        }
    }
}
