using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public GameObject checkpointlocation;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Check");
            checkpointlocation.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

}
