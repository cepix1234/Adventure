using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public Text textKilledEnemys;


    private void Start()
    {
        if (transform.GetComponent<EnemysKilled>() != null)
        {
            int killedEnemys = transform.GetComponent<EnemysKilled>().returnEnemysKilled();
            textKilledEnemys.text = "You have killed " + killedEnemys + " enemys!";
        }
    }

    public void exit()
    {
        Application.Quit();
    }

    public void toMainScreen()
    {
        SceneManager.LoadScene(0);
    }
}
