using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personMove : MonoBehaviour
{
    public HingeJoint hj;

    public Transform objet;

    public bool invert;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    JointSpring js = hj.spring;
	    js.targetPosition = objet.localEulerAngles.x;
	    if (js.targetPosition>180)
	    {
	        js.targetPosition = js.targetPosition - 360;
	    }
	    js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);
	    if (invert)
	    {
	        js.targetPosition = js.targetPosition * -1;
	    }

	    hj.spring = js;
	}
}
