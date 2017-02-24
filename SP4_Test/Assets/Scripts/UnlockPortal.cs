using UnityEngine;
using System.Collections;

public class UnlockPortal : MonoBehaviour {
    public Animator ar;
    [SerializeField]
    RectTransform panelRectTransform;
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    int id = 0;
    GameObject player;
    float x, y = 0;
    bool disabled = false;
	// Use this for initialization
	void Start () {
        ar = GetComponent<Animator>();
        ar.speed = 0;
        disabled = false;

        canvas.SetActive(false);
        panelRectTransform = panelRectTransform.GetComponent<RectTransform>();
        panelRectTransform.localScale = new Vector3(x, y, 1);
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
    void Update () {
        if(player == null && !GlobalScript.isDead)
            player = GameObject.FindGameObjectWithTag("Player");
        if (id == 0)
        {
            if (GlobalScript.howmanytokill < 5)
            {
            }
            else
            {
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
            if(GlobalScript.GrifHealth <= 0)
            {
                ar.speed = 1;
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
    }
}
