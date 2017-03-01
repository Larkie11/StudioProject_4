using UnityEngine;
using System.Collections;

public class UnlockPortal : MonoBehaviour {
    public Animator ar;
    [SerializeField]
    RectTransform panelRectTransform;
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    GameObject clearedcanvas;
    [SerializeField]
    int id = 0;
    [SerializeField]
    AudioClip cleared;
    AudioSource audioEff;
    GameObject player;
    float x, y = 0;
    bool disabled = false;
    bool playCleared;
	// Use this for initialization
	void Start () {
        ar = GetComponent<Animator>();
        ar.speed = 0;
        disabled = false;
        clearedcanvas.SetActive(false);
        canvas.SetActive(false);
        audioEff = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        panelRectTransform = panelRectTransform.GetComponent<RectTransform>();
        panelRectTransform.localScale = new Vector3(x, y, 1);
        playCleared = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public void DisableCanvas()
    {
        canvas.SetActive(false);
        disabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null && !GlobalScript.isDead)
            player = GameObject.FindGameObjectWithTag("Player");
        if(player!=null)
        if (!transform.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position))
        {
            canvas.SetActive(false);
            x = 0F;
            y = 0F;
        }
        if (!GlobalScript.isDead)
        {
            if (id == 0 || id == 2)
            {
                if (GlobalScript.howmanytokill < 5)
                {
                }
                else
                {
                    ar.speed = 1;
                    clearedcanvas.SetActive(true);
                }
                if (GlobalScript.howmanytokill >= 5 && transform.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position) && !disabled)
                {
                    canvas.SetActive(true);
                    if (x < 1.5 || y < 1.5)
                    {
                        x += Time.deltaTime * 3;
                        y += Time.deltaTime * 3;
                    }
                    panelRectTransform.localScale = new Vector3(x, y, 1);
                }
            }
            if (id == 10)
            {
                if (GlobalScript.howmanytokill < 1)
                {
                }
                else
                {
                    clearedcanvas.SetActive(true);
                    ar.speed = 1;
                }
                if (GlobalScript.howmanytokill >= 1 && transform.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position) && !disabled)
                {
                    canvas.SetActive(true);
                    if (x < 1.5 || y < 1.5)
                    {
                        x += Time.deltaTime * 3;
                        y += Time.deltaTime * 3;
                    }
                    panelRectTransform.localScale = new Vector3(x, y, 1);
                }
                
            }
            if (id == 1)
            {
                if (GlobalScript.GrifHealth <= 0)
                {
                    ar.speed = 1;
                    clearedcanvas.SetActive(true);
                    if (!playCleared)
                    {
                        audioEff.PlayOneShot(cleared);
                        playCleared = true;
                    }
                }
                if (GlobalScript.GrifHealth <= 0 && transform.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position) && !disabled)
                {
                    canvas.SetActive(true);

                    if (x < 1.5 || y < 1.5)
                    {
                        x += Time.deltaTime * 3;
                        y += Time.deltaTime * 3;
                    }
                    panelRectTransform.localScale = new Vector3(x, y, 1);
                }
            }
            if (id == 3)
            {
                if (GlobalScript.CrimsonHealth <= 0)
                {
                    ar.speed = 1;
                    clearedcanvas.SetActive(true);

                    if (!playCleared)
                    {
                        audioEff.PlayOneShot(cleared);
                        playCleared = true;
                    }
                }
                if (GlobalScript.CrimsonHealth <= 0 && transform.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position) && !disabled)
                {
                    canvas.SetActive(true);

                    if (x < 1.5 || y < 1.5)
                    {
                        x += Time.deltaTime * 3;
                        y += Time.deltaTime * 3;
                    }
                    panelRectTransform.localScale = new Vector3(x, y, 1);
                }
            }
            if (id == 6)
            {
                if (GlobalScript.Zakhp <= 0)
                {
                    ar.speed = 1;
                    clearedcanvas.SetActive(true);

                    if (!playCleared)
                    {
                        audioEff.PlayOneShot(cleared);
                        playCleared = true;
                    }
                }
                if (GlobalScript.Zakhp <= 0 && transform.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position) && !disabled)
                {
                    canvas.SetActive(true);

                    if (x < 1.5 || y < 1.5)
                    {
                        x += Time.deltaTime * 3;
                        y += Time.deltaTime * 3;
                    }
                    panelRectTransform.localScale = new Vector3(x, y, 1);
                }
            }
        }
    }
}
