using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// link too tutorial: https://www.youtube.com/watch?v=wkKsl1Mfp5M
public class Bullet : MonoBehaviour {
    // Start is called before the first frame update

    public float speed = 10f;
    public Rigidbody2D rb;
    public GameObject p1;
    public Rigidbody2D player_rb;
    
    void Start () {

        player_rb = GameObject.Find("MrCowboy1").GetComponent<Rigidbody2D>();

        ;

        if(player_rb.transform.localScale.x  >0 )
        {
            Debug.Log("Player is going right");
            rb.velocity = transform.right * speed;
        } else if (player_rb.transform.localScale.x < 0)
        {
            Debug.Log("Player is going left");
            rb.transform.localScale = new Vector3(-rb.transform.localScale.x, rb.transform.localScale.y, rb.transform.localScale.z);
            rb.velocity = -transform.right * speed;
        }
        

        
    }

    // Update is called once per frame

    private void Update()
    {


        
    }

}