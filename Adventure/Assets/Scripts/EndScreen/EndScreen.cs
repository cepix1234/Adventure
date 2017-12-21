using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public Text textKilledEnemys;
    public Text textHowEnded;


    private void Start()
    {
        if (transform.GetComponent<EnemysKilled>() != null)
        {
            int killedEnemys = transform.GetComponent<EnemysKilled>().returnEnemysKilled();
            string output = "You have killed " + killedEnemys + " enemys!";
            textKilledEnemys.text = output;
        }
        if(transform.GetComponent<HowLevelEnded>() != null)
        {
            string output = "";
            if (transform.GetComponent<HowLevelEnded>().getWon())
            {
                output = "You won \n Thanks for playing";
            }
            else
            {
                output = "You died \n GAME OVER \n Thanks for playing";
            }
            textHowEnded.text = output;
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
