using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Player : MonoBehaviourPunCallbacks
{

    public float speed = 5f;
    public float jumpValue = 8;
    private Rigidbody2D rigidbody;

    public Transform jumpCheckTransform;
    public float jumpCheckRadius = 0.3f; //will be proportional with the size of the object
    public LayerMask layerMask;

    public GameObject vulture;

    public GameObject heart1, heart2, heart3, gameOver;
    public static int health = 0;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {


        float horizontalValue = Input.GetAxis("Horizontal");
        // with rigidbody.velocity.y we take current gravity of the y-axis
        Vector2 velocity = new Vector2(horizontalValue * speed, rigidbody.velocity.y);
        rigidbody.velocity = velocity;

        bool jumpIsDown = Input.GetButtonDown("Jump");
        bool isGrounded = Physics2D.OverlapCircle(jumpCheckTransform.position, jumpCheckRadius, layerMask);
        if (jumpIsDown && isGrounded)
        {
            rigidbody.AddForce(new Vector2(0, jumpValue), ForceMode2D.Impulse);
        }

        Vector2 scale = transform.localScale;

        if (velocity.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (velocity.x < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


    }





    public void OnTriggerEnter2D(Collider2D collision)
    {

        /*

        if (collision.gameObject.tag == "Cactus" || collision.gameObject.tag == "FlyingObjects")
        {
            vulture.gameObject.SetActive(false);
            GameControlScript.health -= 1;

            if (GameControlScript.health == 3)
            {
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
            }
            else if (GameControlScript.health == 2)
            {
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
            }
            else if (GameControlScript.health == 1)
            {
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
            }
            else
            {
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                rigidbody.gameObject.SetActive(false);
                Time.timeScale = 0;
            }
        }
        vulture.transform.position = new Vector3(-15, -3, 0);
        vulture.gameObject.SetActive(true);
        */
        //Debug.Log(collision.gameObject.name);

    }
}