using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{

    Rigidbody rb;
    CapsuleCollider caps;
    public float resistance = 10;
    public Animator anim;
    public float gojump = 5f;
    public float velocity = 10f;
    private bool colJmp = false;
    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > resistance)
        {
            caps.enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            anim.SetBool("Fight", true);
            colJmp = true;
        }
    }

    void jump()
    {
        if (!colJmp)
        {
            rb.AddForce(new Vector3(0, gojump * 100, 0), ForceMode.Impulse);
           // Invoke("jump", Random.Range(2, 10));
        }  
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        caps = GetComponent<CapsuleCollider>();
        //Invoke("jump", Random.Range(2, 10));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }   
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * velocity );
    }
}
