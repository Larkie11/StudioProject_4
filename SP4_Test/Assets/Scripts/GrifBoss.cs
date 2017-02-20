using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrifBoss : MonoBehaviour
{
    float spikeCD;
    int lightningtospawn;
    public List<GameObject> myPlatforms;
    bool playAttack;
    bool playNormal;
    [SerializeField]
    float LightningCD;

    Animator ar;
    Vector3 target;
    private string lastClipName;
    int hi;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        myPlatforms = new List<GameObject>();
        myPlatforms.Clear();
        playAttack = false;
        playNormal = true;
        foreach (GameObject platforms in GameObject.FindGameObjectsWithTag("Platform"))
        {
            myPlatforms.Add(platforms);
        }
        spikeCD = 8F;
        ar = GetComponent<Animator>();

        Debug.Log(myPlatforms.Count);
        hi = Random.Range(0, myPlatforms.Count);
        lightningtospawn = 1;

        GlobalScript.GrifLightningCD = LightningCD;

    }
    // Update is called once per frame
    void Update()
    {
        if(!player)
            player = GameObject.FindGameObjectWithTag("Player");

        Debug.Log(player.transform.position);
        if(!playAttack)
        transform.position += (player.transform.position - transform.position).normalized * 0.5F * Time.deltaTime;

        if (GlobalScript.GrifLightningCD <= 0.5)
        {
            if(!playAttack)
            for (int i = 0; i < lightningtospawn; i++)
            {
                target = new Vector3(Random.Range(myPlatforms[hi].GetComponent<Collider2D>().bounds.min.x + 4, myPlatforms[hi].GetComponent<Collider2D>().bounds.max.x - 2), -10.2F, transform.position.z);
                Instantiate(Resources.Load("LightningTrigger"), target, Quaternion.identity);
            }
            playAttack = true;
        }
        if (GlobalScript.GrifLightningCD <= 0.1)
        {
            playAttack = false;
            GlobalScript.GrifLightningCD = LightningCD;
        }

        if (playAttack)
            ar.SetInteger("State", 1);
        if (!playAttack)
        {
            ar.SetInteger("State", 0);
        }
        GlobalScript.GrifLightningCD -= Time.deltaTime * 0.3F;

        Debug.Log(GlobalScript.GrifLightningCD);
    }
}
