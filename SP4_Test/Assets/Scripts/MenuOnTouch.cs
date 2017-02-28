using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuOnTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    GameObject onTouch;
	// Use this for initialization
	void Start () {


    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.position.x + " " + eventData.position.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
#if UNITY_ANDROID
        transform.position = Input.mousePosition;
        Vector3 screenPos = new Vector3(eventData.position.x, eventData.position.y, 10);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        GameObject go = Instantiate(onTouch, worldPos, Quaternion.identity) as GameObject; 
#endif
    }
}
