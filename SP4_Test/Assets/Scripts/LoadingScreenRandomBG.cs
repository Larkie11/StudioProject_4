using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoadingScreenRandomBG : MonoBehaviour {
    public List<Sprite> bgs = new List<Sprite>();
    [SerializeField]
    Image image;
	// Use this for initialization
	void Start () {
        int random = Random.Range(0, bgs.Count);
        image = image.GetComponent<Image>();
        image.sprite =  bgs[random];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
