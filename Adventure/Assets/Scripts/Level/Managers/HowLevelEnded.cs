using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowLevelEnded : MonoBehaviour {

    static bool won = false;
	
    public void win()
    {
        won = true;
    }

    public void loose()
    {
        won = false;
    }

    public bool getWon ()
    {
        return won;
    }
}
