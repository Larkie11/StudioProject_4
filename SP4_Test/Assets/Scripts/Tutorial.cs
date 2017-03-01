using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Tutorial : MonoBehaviour {

    GameObject player;
    [SerializeField]
    GameObject text1;
    [SerializeField]
    GameObject text2;
    [SerializeField]
    Text text;
    [SerializeField]
    Canvas shieldBar;
    BoxCollider2D text12d;
    BoxCollider2D text22d;
    bool showShieldBar = false;
    [SerializeField]
    AudioClip soundEffect;
    AudioSource audioEff;
    [SerializeField]
    List<BoxCollider2D> triggers = new List<BoxCollider2D>();
    [SerializeField]
    Text tasktext;
    bool playSoundEffect = false;
    float timer;
    string[] android = new string[] 
    { "Use joystick to move", "Swipe up to jump",
        "Press anywhere on the screen to fire a bullet",
        "Release to fire", "Hold button to use shield, it is shown at the bottom and will decrease/increase",
        "Enemy will chase you when on same platform, they might also drop items",
         "This portal is the one that leads to another map, after clearing the task of each level"

        };
    string[] pc = new string[] 
    { "Use A and D to move", "Space to jump",
        "Use the cursor positioning to fire a bullet",
        "Left click to fire", "Right click to use shield, it is shown at the bottom and will decrease/increase",
         "Enemy will chase you when on same platform, they might also drop items",
         "This portal is the one that leads to another map, after clearing the task of each level"
        };
    string onplatform;
    // Use this for initialization
    void Start () {
        audioEff = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        tasktext = tasktext.GetComponent<Text>();
        tasktext.enabled = false;
        timer = 0;
        shieldBar.enabled = false;
        text12d = text1.GetComponent<BoxCollider2D>();
        text22d = text2.GetComponent<BoxCollider2D>();
        for(int i = 0; i < triggers.Count; i++)
        {
            triggers[i].GetComponent<BoxCollider2D>();
        }
#if UNITY_STANDALONE
        onplatform = "PC";
#endif
#if UNITY_ANDROID
        onplatform = "ANDROID";
#endif
    }

    // Update is called once per frame
    void Update () {
        shieldBar.enabled = showShieldBar;
        if(player == null && !GlobalScript.isDead)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(player.name);
        }
        if(!GlobalScript.isDead)
        for (int i = 0; i < triggers.Count; i++)
        {
            if (triggers[i].GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position))
            {
                    if(!playSoundEffect)
                    audioEff.PlayOneShot(soundEffect);
                    playSoundEffect = true;
                if (onplatform == "PC")
                    text.text = pc[i];
                if (onplatform == "ANDROID")
                    text.text = android[i];
                timer = 0.3F;
            }
        }
        if (onplatform == "PC")
        {
            if (text.text == pc[4])
                showShieldBar = true;
            if (text.text == pc[6])
            {
                tasktext.text = "TASK: Kill 1 enemy " + GlobalScript.howmanytokill + "/1";
                tasktext.enabled = true;
            }
        }
        if (onplatform == "ANDROID")
        {
            if (text.text == android[4])
                showShieldBar = true;
            if (text.text == android[6])
            {
                tasktext.text = "TASK: Kill 1 enemy " + GlobalScript.howmanytokill + "/1";
                tasktext.enabled = true;
            }
        }
        if (timer > 0)
            timer -= Time.deltaTime;
        else if (timer <= 0)
        {
            text.text = "";
            playSoundEffect = false;
        }
    }
}
