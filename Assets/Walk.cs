using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;
    private bool isBouncing = false;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        movement  = new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0);
        movement.Normalize();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement.x = Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (!isBouncing) transform.position += movement * speed * Time.deltaTime;
        // rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // if( /*code here to make sure the collision is with the object in question */ )
        {
            float bounce = 1f; //amount of force to apply
            var bounceDirection = collision.contacts[0].normal * bounce;
            if (bounceDirection.x > 0 || bounceDirection.y > 0) bounceDirection *= new Vector3(-1,-1,0);
            if (bounceDirection.x == 0) bounceDirection.x = 1;
            if (bounceDirection.y == 0) bounceDirection.y = 1;
            movement *= bounceDirection;
            Debug.Log(bounceDirection);
            isBouncing = true;
            StopBounce();
        }
    }

    void StopBounce()
    {
        isBouncing = false;
    }
}
