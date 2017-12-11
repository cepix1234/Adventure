using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject helthBar;
    public  Text numOfEnemysUI;

    [SerializeField]
    private PlayerHealth helth;

    [SerializeField]
    private int numOfEnemys;
	// Use this for initialization
	void Start () {
        helth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        helthBar.transform.localScale = new Vector3(helth.returnHelth() / 50, 1);
        numOfEnemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
        numOfEnemysUI.text = "Enemys remain :" + numOfEnemys;
	}
}
