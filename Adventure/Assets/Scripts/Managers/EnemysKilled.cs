using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysKilled : MonoBehaviour {

    [SerializeField]
    static int enemysKilled = 0;

    public void enemyKilled()
    {
        enemysKilled++;
    }


    public int returnEnemysKilled()
    {
        return enemysKilled;
    }
}
