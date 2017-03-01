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
	void Update () 
    {
        if(id == 0)
        text.text = "Kill enemies: " + GlobalScript.howmanytokill.ToString() +" / 5";

        if(id == 16)
        {
            text.text = "Collect Box: " + GlobalScript.BoxCounter.ToString() +" / 3";
        }

        if (id == 25)
        {
            if(!GlobalScript.keypickup)
                text.text = "Collect Key: " + "0/1";
            if (GlobalScript.keypickup)
                text.text = "Collect Key: " + "1/1";
        }
    }
}
