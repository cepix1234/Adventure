using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenEndScreen : MonoBehaviour {
    
    [SerializeField]
    private PlayerHealth helth;
    // Use this for initialization
    void Start()
    {
        helth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        int numOfEnemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (helth.returnHelth() <= 0 || numOfEnemys == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
