using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderRope : MonoBehaviour
{
    private LineRenderer line;

    public Material mat;
    public Rigidbody2D origin;
    public float line_width = 0.1f;
    public float speed = 10;
    private Vector3 velocity;
    private GameObject body;
    private GameObject player;
    public float stamina = 1f;
    private GameObject collision;

    private IEnumerator timer;
    public float pull_force = 10;
    private bool pull = false;
    private bool update = false;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        if (!line)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }
        line.startWidth = line_width;
        line.endWidth = line_width;
        line.material = mat;
        //Debug.Log(origin.position);

        body = GameObject.Find("/Player1/Body");
        player = GameObject.Find("/Player1");
        //Debug.Log(body.transform.position);
    }

    public void setStart(Vector2 targetPos)
    {
        Vector2 pos = player.transform.position;
        Vector2 dir = targetPos - pos;
        dir = dir.normalized;
        velocity = dir * speed;
        transform.position = pos;// + dir;
        pull = false;
        update = true;

        if(timer != null)
        {
            StopCoroutine(timer);
            timer = null;
        }
        
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;
        Debug.Log(layerMask);

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        Debug.Log(layerMask);
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, 5, layerMask);

        //If something was hit.
        if (hit.collider != null)
        { 
            Debug.DrawRay(pos, dir * 5, Color.yellow);
            Debug.Log("Did Hit: " + hit.collider.name + ", " + hit.collider.GetComponent<Rigidbody2D>() + ", " + hit.distance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!update)
        {
            this.gameObject.GetComponent<Collider2D>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            return;
        }
        
        if (pull)
        {
            if(string.Equals(collision.transform.parent.name, "Traps"))
            {
                //Debug.Log("Succes");
                Vector2 dir2 = player.transform.position - collision.transform.position;
                collision.GetComponent<Rigidbody2D>().AddForce(dir2 * 10);
                line.SetPosition(0, collision.transform.position);
                line.SetPosition(1, player.transform.position);
            } else
            {
                Vector2 dir = (Vector2)(transform.position - player.transform.position);
                //dir = dir.normalized;
                origin.AddForce(dir * pull_force);
                line.SetPosition(0, transform.position);
                line.SetPosition(1, player.transform.position);
            }
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if(distance > 5)
            {
                update = false;
                line.SetPosition(0, Vector2.zero);
                line.SetPosition(1, Vector2.zero);
                return;
            }
            line.SetPosition(0, transform.position);
            line.SetPosition(1, player.transform.position);
        }
        //Debug.Log(origin.position);
        //line.SetPosition(0, transform.position);
        //line.SetPosition(1, body.transform.position);
    }

    IEnumerator reset(float delay)
    {
        yield return new WaitForSeconds(delay);
        update = false;
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        velocity = Vector2.zero;
        pull = true;
        timer = reset(stamina);
        StartCoroutine(timer);

        //GameObject trap =  GameObject.Find(collision.gameObject.name);
        this.collision = GameObject.Find(collision.gameObject.name);
        /*Debug.Log(collision.gameObject.name);
        Debug.Log(collision.transform.parent.name);*/
        //Vector2 dir = transform.position - trap.transform.position;
        //trap.GetComponent<Rigidbody2D>().AddForce(dir*100);
        if (string.Equals(collision.transform.parent.name, "Traps"))
        {
            //this.gameObject.GetComponent<Collider2D>().enabled = false;
        }

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
