using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RenderTask : MonoBehaviour {
    [SerializeField]
    Text text;
    [SerializeField]
    int id;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if(id == 0)
        text.text = "Kill enemies " + GlobalScript.howmanytokill.ToString() +" / 5";

    }
}
