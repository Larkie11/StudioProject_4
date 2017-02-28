using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RenderTask : MonoBehaviour {
    [SerializeField]
    Text text;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Kill enemies " + GlobalScript.howmanytokill.ToString() +" / 5";

    }
}
