using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockSpawn : MonoBehaviour {
    public List<GameObject> SpawnRocks = new List<GameObject>();
    bool spawned;
    int spawnPointIndex;
    [SerializeField]
    GameObject go;
    float timer;
    // Use this for initialization
    void Start () {
        spawned = false;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        spawnPointIndex = Random.Range(0, SpawnRocks.Count);
        if(!spawned && timer <= 0)
        {
            GameObject go2 = Instantiate(Resources.Load("Rock"), new Vector2(SpawnRocks[spawnPointIndex].transform.position.x, SpawnRocks[spawnPointIndex].transform.position.y), Quaternion.identity) as GameObject;
            timer = 3F;
        }
        if (timer > 0)
            timer -= Time.deltaTime;
    }
}
