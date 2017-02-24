using UnityEngine;
using System.Collections;

public class WaypointController : MonoBehaviour {

    public GameObject[] waypoints;
    public int num;

    public float minDist;
    public float speed;

    public bool rand = false;
    public bool go = true;
    
        float lockPos = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);
        if(go)
        {
            if(dist > minDist)
            {
               Move();
            }
            else
            {
                if (!rand)
                {
                    if (num + 1 == waypoints.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    num = Random.Range(0, waypoints.Length);
                }
            }
        }
	}

    public void Move()
    {
        //gameObject.transform.LookAt(waypoints[num].transform.position);
        //gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[num].transform.position, speed * Time.deltaTime);
    }

}
