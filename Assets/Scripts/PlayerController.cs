using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Sprite playerRight;
    public Sprite playerLeft;
    public GameObject projectile;
    public GameObject camera;
    public ParticleSystem poof;

    private Rigidbody2D rb2d;
    private Vector3 pz;
    private Vector3 testV;
    private SpriteRenderer spriteRenderer;
    private bool facingRight;

    void Start()
    {
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        camera = GetComponent<GameObject>();
    }

    void FixedUpdate()
    {

        /* ----------------- Movement -------------------*/
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        rb2d.velocity = new Vector2(moveX * speed, moveY * speed);
        /*----------------------------------------------*/

        /* ----------------- Mouse Location ------------*/
        pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        pz.x += .5f;
        /*----------------------------------------------*/

        /* -------------------Flip-----------------------*/
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (pz.x > rb2d.transform.position.x)
            spriteRenderer.flipX = false;
        else if (pz.x < rb2d.transform.position.x)
            spriteRenderer.flipX = true;
        /*----------------------------------------------*/

        /* ------------- Teleportation ---------- */

        if(Input.GetKeyDown("space"))
        {
            rb2d.transform.position = pz;
            poof.transform.position = pz;
            
            poof.Play();
        }

        /*----------------------------------------------*/

        /* ------------- Projectiles ---------- */

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newGO = new GameObject();
            newGO = projectile;

            newGO.transform.position = Vector2.MoveTowards(newGO.transform.position, new Vector2(rb2d.position.x + 20, rb2d.position.y), Time.deltaTime);

        }

        /*----------------------------------------------*/

        //poof.Play();

    }

}
