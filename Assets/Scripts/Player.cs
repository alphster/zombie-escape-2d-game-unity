using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 3.0f;
    public Animator legs;
    public SpriteRenderer torso;
    public WeaponBehavior weapon;

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && weapon != null) weapon.PullTrigger();

        TalkToChildren();
	}

    void FixedUpdate()
    {
        ReadInputAndMove();
    }

    void ReadInputAndMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(moveHorizontal, moveVertical) * speed;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

    void TalkToChildren()
    {
        legs.SetFloat("speed", rb2d.velocity.magnitude);
    }

    public void SetCharacter(string name)
    {
        switch(name)
        {
            case ("Business"):
                legs.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Player/BusinessOverride", typeof(RuntimeAnimatorController));
                torso.sprite = Resources.Load<Sprite>("Sprites/Humanoids/Businessman/business_torso_2h");
                break;
            case ("Nurse"):
                legs.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Player/NurseOverride", typeof(RuntimeAnimatorController));
                torso.sprite = Resources.Load<Sprite>("Sprites/Humanoids/Nurse/nurse_torso_2h");
                break;
            default:
                legs.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Player/Player", typeof(RuntimeAnimatorController));
                torso.sprite = Resources.Load<Sprite>("Sprites/Humanoids/Soldier/soldier_torso_2h");
                break;
        }

    }
}
