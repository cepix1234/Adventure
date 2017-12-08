using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject ForwardThruster;
    public GameObject BackwerdsThruster;
    public GameObject UpThruster;
    public GameObject DownThruster;



    public Vector3 speed;

    private PowerUpManager managePowerUp;
	// Use this for initialization
	void Start () {
        speed = new Vector2(0f, 0f);
        managePowerUp = Camera.main.GetComponent<PowerUpManager>();
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
            speed += new Vector3(0.1f, 0, 0);
            ForwardThruster.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            ForwardThruster.GetComponent<ParticleSystem>().Stop();
        }


        //UP
        if (Input.GetKey(KeyCode.W))
        {
            speed += new Vector3(0, 0.1f, 0);
            UpThruster.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            UpThruster.GetComponent<ParticleSystem>().Stop();
        }

        //Down
        if (Input.GetKey(KeyCode.A))
        {
            speed += new Vector3(-0.1f, 0, 0);
            BackwerdsThruster.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            BackwerdsThruster.GetComponent<ParticleSystem>().Stop();
        }


        //Backwerds
        if (Input.GetKey(KeyCode.S))
        {
            speed += new Vector3(0, -0.1f, 0);
            DownThruster.GetComponent<ParticleSystem>().Play();
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            DownThruster.GetComponent<ParticleSystem>().Stop();
        }
    }

    void movePLayer ()
    {
        speed = new Vector3(Mathf.Clamp(speed.x,-3,3), Mathf.Clamp(speed.y, -3, 3), 0);
        transform.position += speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("PowerUp"))
        {
            PowerUp powerup = other.GetComponent<PowerUp>();
            if (powerup.type.Equals("Gun"))
            {
                managePowerUp.replaceWapons(powerup.gun);
            }
            Destroy(other.gameObject);
        }
    }
}
