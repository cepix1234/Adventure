using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenEndScreen : MonoBehaviour {
    
    [SerializeField]
    private PlayerHealth helth;

    private HowLevelEnded howEnded;
    // Use this for initialization
    void Start()
    {
        helth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        howEnded = transform.GetComponent<HowLevelEnded>();
    }

    // Update is called once per frame
    void Update()
    {
        int numOfEnemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (helth.returnHelth() <= 0 )
        {
            SceneManager.LoadScene(2);
            howEnded.loose();
        }else if(numOfEnemys <= 0)
        {
            SceneManager.LoadScene(2);
            howEnded.win();
        }
    }
}
