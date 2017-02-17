using UnityEngine;
using System.Collections;

public class ShieldCollision : MonoBehaviour {



	// Use this for initialization
	void Start () {
        Physics.IgnoreLayerCollision(8,9,true);
        Physics.IgnoreLayerCollision(8,11,true);

    }

    // Update is called once per frame
    void Update () {
    
	}
}
