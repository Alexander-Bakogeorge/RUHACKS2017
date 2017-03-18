using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAnimation : MonoBehaviour {

    Animator anim;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        anim.SetFloat("Speed", rb.velocity.magnitude);
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", rb.velocity.magnitude);
        print(rb.velocity.magnitude);

    }
}
