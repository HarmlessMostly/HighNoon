using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplinghook : MonoBehaviour
{

    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);
            Debug.Log(mask.value);
            //Debug.Log(mask.LayerToName());
            Debug.Log(hit);
            Debug.Log(hit.collider);
            Debug.Log(hit.collider.gameObject);
            Debug.Log(hit.collider.gameObject.GetComponent<Rigidbody2D>());
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Debug.Log("Hit");
                joint.enabled = true;
                Debug.Log(hit.collider.gameObject.GetComponent<Rigidbody2D>());
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.point);
                Debug.Log(joint.distance);
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            joint.enabled = false;
        }
    }
}
