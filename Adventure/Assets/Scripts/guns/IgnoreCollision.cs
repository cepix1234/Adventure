using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(8, 9,true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
