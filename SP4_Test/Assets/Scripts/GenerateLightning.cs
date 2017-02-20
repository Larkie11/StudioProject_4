using UnityEngine;
using System.Collections;

public class GenerateLightning : MonoBehaviour {
    [SerializeField]
    float CoolDown;
    bool Generated = false;
	// Use this for initialization
	void Start () {
        CoolDown = 3F;
	}
	
	// Update is called once per frame
	void Update () {
        CoolDown -= Time.deltaTime;

        if(CoolDown < 0 && !Generated)
        {
            Generated = true;
            Instantiate(Resources.Load("LightningAttack"), new Vector3(transform.position.x, Random.Range(9,12),transform.position.z), Quaternion.identity);
        }
    }
}
