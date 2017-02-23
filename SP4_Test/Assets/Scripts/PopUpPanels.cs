using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpPanels : MonoBehaviour {

    RectTransform panelRectTransform;
    float x, y = 0;
    // Use this for initialization
    void Start () {
        panelRectTransform = GetComponent<RectTransform>();
        panelRectTransform.localScale = new Vector3(x, y, 1);
    }
	
	// Update is called once per frame
	void Update () {
        if (x < 1.5 || y < 1.5)
        {
            x += Time.deltaTime * 3;
            y += Time.deltaTime * 3;
        }
        panelRectTransform.localScale = new Vector3(x, y, 1);
    }
}
