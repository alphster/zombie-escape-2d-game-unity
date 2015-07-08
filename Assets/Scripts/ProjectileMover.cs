using UnityEngine;
using System.Collections;

public class ProjectileMover : MonoBehaviour {

    public float speed = 20.0f;
    public float damage = 0;

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = rb2d.transform.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
