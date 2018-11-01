using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger : MonoBehaviour
{
    public float power = 4000f;

    private Rigidbody rb;

    private bool catchRG=false;
	// Use this for initialization
	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	}

    void OnCollisionEnter(Collision col)
    {
        if (!catchRG&&col.transform.tag!="RagDoll")
        {
            SpringJoint sp = gameObject.AddComponent<SpringJoint>();
            sp.connectedBody = col.rigidbody;
            sp.spring = 12000f;
            sp.breakForce = power;
            catchRG = true;
        }
    }

    void OnJointBreak()
    {
        catchRG = false;
    }

    // Update is called once per frame
	void Update () {
		
	}
}
