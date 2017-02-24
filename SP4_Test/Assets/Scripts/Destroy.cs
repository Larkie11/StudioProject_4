using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    
    public float timetokillmyself ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(timetokillmyself);
        Destroy(gameObject, timetokillmyself);
	}
}
