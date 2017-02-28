using UnityEngine;
using System.Collections;

public class spikespin : MonoBehaviour {

    Vector2 aroundposition;


    private Vector3 zAxis = new Vector3(0, 0, 1);
    // Use this for initialization
    void Start()
    {
        aroundposition = GameObject.Find("spikebase").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
   
        transform.RotateAround(aroundposition, zAxis, 100f * Time.deltaTime);


    }
}
