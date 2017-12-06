using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject ForwardThruster;
    public GameObject BackwerdsThruster;
    public GameObject UpThruster;
    public GameObject DownThruster;



    public Vector3 speed;
	// Use this for initialization
	void Start () {
        speed = new Vector2(0f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        getInputAndParticle();
        movePLayer();
	}

    void getInputAndParticle()
    {
        //Forward
        if (Input.GetKey(KeyCode.D))
        {
            speed += new Vector3(0.01f, 0, 0);
            ForwardThruster.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            ForwardThruster.GetComponent<ParticleSystem>().Stop();
        }


        //UP
        if (Input.GetKey(KeyCode.W))
        {
            speed += new Vector3(0, 0.01f, 0);
            UpThruster.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            UpThruster.GetComponent<ParticleSystem>().Stop();
        }

        //Down
        if (Input.GetKey(KeyCode.A))
        {
            speed += new Vector3(-0.01f, 0, 0);
            BackwerdsThruster.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            BackwerdsThruster.GetComponent<ParticleSystem>().Stop();
        }


        //Backwerds
        if (Input.GetKey(KeyCode.S))
        {
            speed += new Vector3(0, -0.01f, 0);
            DownThruster.GetComponent<ParticleSystem>().Play();
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            DownThruster.GetComponent<ParticleSystem>().Stop();
        }
    }

    void movePLayer ()
    {
        transform.position += speed * Time.deltaTime;
    }
}
