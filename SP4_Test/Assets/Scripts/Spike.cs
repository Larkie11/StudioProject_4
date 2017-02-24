using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spike : MonoBehaviour {
    public List<GameObject> myPlatforms = new List<GameObject>();
    [SerializeField]
    GameObject spike;
    int spawnPointIndex;
    int spikecount;
    // Use this for initialization
    void Start () {
        myPlatforms.Clear();
        spawnPointIndex = 0;
        spikecount = 0;
        foreach (GameObject platforms in GameObject.FindGameObjectsWithTag("Platform"))
        {
            myPlatforms.Add(platforms);
        }
    }

    // Update is called once per frame
    void Update () {
        if (spikecount < 2)
            GenerateSpikes();
	}

    void GenerateSpikes()
    {
        spawnPointIndex = Random.Range(0, myPlatforms.Count);

        float width = myPlatforms[spawnPointIndex].GetComponent<Collider2D>().bounds.min.x + 2;
        float width2 = myPlatforms[spawnPointIndex].GetComponent<Collider2D>().bounds.max.x - 2;
        float spawnX = 0;

        spawnX = Random.Range(width, width2);
        GameObject go = Instantiate(spike, new Vector3(spawnX, myPlatforms[spawnPointIndex].transform.position.y - 2F, 0), Quaternion.identity) as GameObject;
        spikecount++;
    }
}
