using UnityEngine;
using System.Collections;

public class spawnspike : MonoBehaviour
{

    [SerializeField]
    GameObject spikespawnpos;
    [SerializeField]
    string spawnobject;
    [SerializeField]
    int randmintime = 3;
    [SerializeField]
    int randmaxtime = 5;
    private float spiketimer;
    private int spikespawntimer = 1;
    // Use this for initialization
    void Start()
    {
        randmaxtime = 5;
        randmintime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        spiketimer += Time.deltaTime;

        if(spiketimer>=spikespawntimer)
        {
            spikespawntimer = randomtimer(spikespawntimer);
           spike();
            spiketimer=0;
            

            
        }



    }

    void spike()
    {
           Quaternion spawnRotation = Quaternion.Euler(0,0,90);

        Instantiate(Resources.Load(spawnobject), spikespawnpos.transform.position, Quaternion.identity);

    }
    int randomtimer(int x)
    {
        x = Random.Range(randmintime, randmaxtime);
        return x;
        //rockspawntimer1 = Random.Range(randommintime,randommaxtime);
        //rockspawntimer2 = Random.Range(randommintime, randommaxtime);
    }
}
