using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public float speed = 2.0f;

    Rigidbody2D rb2d;
    Animator animator;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();        
	}
	
	// Update is called once per frame
	void Update () {        
        var playerDistance = Vector2.Distance(PlayerManager.Script.transform.position, transform.position);
	    animator.SetFloat("playerDistance", playerDistance);
        //Debug.Log(Vector2.Distance(PlayerManager.Script.GetRigidBody2D().position, rb2d.position));

        var dir = PlayerManager.Script.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb2d.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        rb2d.velocity = rb2d.transform.up * speed;

        //transform.LookAt(playerRb2d.transform);

        //rb2d.velocity = speed * 
        
        
	}
}
