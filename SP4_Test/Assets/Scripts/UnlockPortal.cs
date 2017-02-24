using UnityEngine;
using System.Collections;

public class UnlockPortal : MonoBehaviour {
    public Animator ar;
    [SerializeField]
    RectTransform panelRectTransform;
    [SerializeField]
    GameObject canvas;
    GameObject player;
    float x, y = 0;
	// Use this for initialization
	void Start () {
        ar = GetComponent<Animator>();
        ar.speed = 0;
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
    }
    // Update is called once per frame
    void Update () {
        if(player == null && !GlobalScript.isDead)
            player = GameObject.FindGameObjectWithTag("Player");
        if (GlobalScript.howmanytokill < 5)
        {
        }
        else
        {
            ar.speed = 1;
        }
        if (GlobalScript.howmanytokill >= 5 && transform.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position))
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
