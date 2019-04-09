using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject player;

    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered");

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1 * Time.deltaTime);
    }

    

}
