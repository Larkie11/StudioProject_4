using UnityEngine;
using System.Collections;

public class firespin : MonoBehaviour {

    Vector2 aroundposition;
    [SerializeField]
    float spiningspeed = 70;

    private Vector3 zAxis = new Vector3(0, 0, 1);
    // Use this for initialization
    void Start()
    {
        aroundposition = GameObject.Find("box").transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(aroundposition, zAxis, spiningspeed * Time.deltaTime);


    }
}
