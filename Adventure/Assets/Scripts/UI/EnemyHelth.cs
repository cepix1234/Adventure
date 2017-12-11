using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelth : MonoBehaviour {

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private GameObject helthBar;
	// Use this for initialization
	void Start () {
        enemy = transform.parent.gameObject;
        helthBar = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, -enemy.transform.rotation.z);
        helthBar.transform.localScale =  new Vector3((enemy.GetComponent<TakeDamage>().health * 2) / 20,helthBar.transform.localScale.y,0);
	}
}
