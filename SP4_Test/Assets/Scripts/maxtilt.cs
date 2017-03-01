using UnityEngine;
using System.Collections;

public class maxtilt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(transform.rotation.z>20)
        {
            transform.eulerAngles =new  Vector3(0, 0, 20);
        }
      
	}
}
