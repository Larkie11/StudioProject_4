using UnityEngine;
using System.Collections;

public class GenerateEnemy : MonoBehaviour {
    [SerializeField]
    GameObject enemyType;
    int enemyCount = 0;
    Camera cam;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < 3)
            CreateEnemy();
    }
    void CreateEnemy()
    {
        enemyCount++;
        GameObject go = Instantiate(enemyType, new Vector3(Random.Range(-5F, 5.0F), -3.7F, 0.0F), Quaternion.identity) as GameObject;
    }
}
