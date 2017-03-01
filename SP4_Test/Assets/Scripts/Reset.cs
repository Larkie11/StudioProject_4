using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GlobalScript.Score = 0;
        GlobalScript.BoxCounter = 0;
        GlobalScript.keypickup = false;
        GlobalScript.howmanytokill = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
