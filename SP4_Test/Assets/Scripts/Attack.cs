using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    GameObject player;
    bool left;
    bool right;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x < transform.position.x)
        {
            left = true;
        }
        else
            right = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        Debug.Log(collision.gameObject.name);

    }
    // Update is called once per frame
    void Update () {
        // distance moved since last frame:
        float amtToMove = 5 * Time.deltaTime;
        // translate projectile in its forward direction:
        if(left)
            transform.Translate(Vector3.left * amtToMove);
        else
            transform.Translate(Vector3.right * amtToMove);
    }
}
