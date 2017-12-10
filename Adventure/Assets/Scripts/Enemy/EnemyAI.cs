using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    
    public GameObject muzzle;
    public GameObject movePoint;

    public GameObject player;
    [SerializeField]
    private List<GameObject> gunSpawns;

    [SerializeField]
    private bool see;

    [SerializeField]
    private List<Vector2> movePoints;
    int startPoint = 0;



    private float randAngleTime;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < player.transform.GetChild(5).childCount; i++)
        {
            gunSpawns.Add(player.transform.GetChild(5).GetChild(i).gameObject);
        }
        movePoints = determinMovePoints();
        spawnMovePoints();
	}
	
	// Update is called once per frame
	void Update () {
        see = checkIfCanSeePlayer();
        if(see)
        {
            attackPlayer();
        }else
        {
            PassiveMoving();
        }
	}

    bool checkIfCanSeePlayer ()
    {
        foreach(GameObject point in gunSpawns)
        {
            Vector3 direction = point.transform.position - muzzle.transform.position;
            RaycastHit2D[] hits = Physics2D.RaycastAll(muzzle.transform.position, direction, 20);
            if (hits.Length > 1)
            {
                if (hits[1].transform.tag.Equals("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    List<Vector2> determinMovePoints ()
    {
        float minRazdalja = float.MaxValue;
        List<Vector2> points = new List<Vector2>();
        Vector2 direction = transform.up;
        for(int i = 0; i<180;i++)
        {
            direction = Quaternion.Euler(0, 0, 1 * i) * transform.up;
            Vector2 pointOne = Physics2D.Raycast(transform.position, direction,1000, LayerMask.GetMask("Map")).point;
            Vector2 pointtwo = Physics2D.Raycast(transform.position, -direction, 1000, LayerMask.GetMask("Map")).point;
            float distance = Vector2.Distance(pointOne, pointtwo);
            if(distance < minRazdalja)
            {
                points = new List<Vector2>();
                points.Add(pointOne);
                points.Add(pointtwo);
            }
        }
        return points;
    }

    void spawnMovePoints()
    {
        foreach(Vector2 point in movePoints)
        {
            movePoint.transform.position = point;
            Instantiate(movePoint);
        }
    }


    void PassiveMoving()
    {
        float AngleRad = Mathf.Atan2(movePoints[startPoint].y - transform.position.y, movePoints[startPoint].x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        AngleDeg -= 90;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        transform.position += transform.up * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Equals("MovePoint"))
        {
            startPoint += 1;
            startPoint = startPoint % 2;
        }
    }

    void attackPlayer ()
    {

        if (randAngleTime >= 4)
        {
            randAngleTime = 0;

        }
        randAngleTime += Time.deltaTime;
        float AngleRad = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        AngleDeg -= 90;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        transform.position += transform.up * Time.deltaTime;
    }
}
