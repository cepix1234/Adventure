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
    [SerializeField]
    int startPoint = 0;
    [SerializeField]
    private List<GameObject> spottingPoints;
    public GameObject bullet;

   private  Vector3 offset = new Vector3(0, 0, 0);

    private float randAngleTime;

    private float lastShot;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < player.transform.GetChild(5).childCount; i++)
        {
            gunSpawns.Add(player.transform.GetChild(5).GetChild(i).gameObject);
        }
        movePoints = determinMovePoints();
        spawnMovePoints();
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).tag.Equals("SpotPoint"))
            {
                spottingPoints.Add(transform.GetChild(i).gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        see = checkIfCanSeePlayer();
        if(see)
        {
            attackPlayer();
            shoot();
        }else
        {
            PassiveMoving();
        }
	}

    bool checkIfCanSeePlayer ()
    {
        foreach (GameObject spotPoint in spottingPoints)
        {
            foreach (GameObject point in gunSpawns)
            {
                Vector3 direction = point.transform.position - spotPoint.transform.position;
                RaycastHit2D[] hits = Physics2D.RaycastAll(spotPoint.transform.position, direction, 20);
                if (hits.Length > 1)
                {
                    if (hits[1].transform.tag.Equals("Player"))
                    {
                        return true;
                    }
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
        int i = 1;
        foreach(Vector2 point in movePoints)
        {
            GameObject Mpoint = movePoint; 
            Mpoint.transform.position = point;
            Instantiate(movePoint);
            string tag = "MovePoint" + i;
            Mpoint.tag = tag;
            i++;
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
        if(collision.transform.tag.Equals("MovePoint1"))
        {
            startPoint = 0;
        }else if (collision.transform.tag.Equals("MovePoint2"))
        {
            startPoint = 1;
        }
    }

    void attackPlayer ()
    {
        if (randAngleTime >= 4)
        {
            randAngleTime = 0;
            Vector3 twoardsEnemy = transform.position - player.transform.position;
            twoardsEnemy = twoardsEnemy / Vector3.Distance(transform.position, player.transform.position);
            int LorR = Random.Range(0, 3);
            if(LorR == 0)
            {
                offset = Quaternion.Euler(0, 0, 90) * twoardsEnemy;
            }
            else if(LorR == 1)
            {
                offset = -(Quaternion.Euler(0, 0, 90) * twoardsEnemy);
            }else
            {
                offset = new Vector3(0, 0, 0);
            }
        }
        randAngleTime += Time.deltaTime;
        Vector3 targetPos = player.transform.position + offset*5;
        float AngleRad = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        AngleDeg -= 90;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        transform.position += transform.up * Time.deltaTime;
    }

    void shoot()
    {
        lastShot += Time.deltaTime;
        if(lastShot >= 4)
        {
            bullet.transform.position = muzzle.transform.position;
            bullet.transform.rotation = muzzle.transform.rotation;
            bullet.GetComponent<Bullet>().set(5f, 10, 10, false);
            Instantiate(bullet);
            lastShot = 0;
        }
    }
}
