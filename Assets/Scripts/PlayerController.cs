using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerVelocity = 10;
    private Rigidbody2D rigidBody2D;
    public Transform jumpRaycastPosition;
    public float jumpRaycastRadius;
    public LayerMask jumpLayerMask;
    public float jumpForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //read input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //define h orizontal speed
        Vector2 velocity = new Vector2(horizontalInput * playerVelocity, 0);
        velocity.y = rigidBody2D.velocity.y; //keep value given by physics
        rigidBody2D.velocity = velocity;
        //flip the sprite horizontally, depending on the move direction
        Vector3 scale = transform.localScale;
        if (velocity.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        } else if (velocity.x < 0) {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        bool isGrounded = Physics2D.OverlapCircle(jumpRaycastPosition.position, jumpRaycastRadius, jumpLayerMask);
        if (Input.GetButtonDown("Jump") && isGrounded) { 
            rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
