using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Script;

    public float speed = 3.0f;
    public float accuracy = 0.1f;
    public Animator legs;
    public SpriteRenderer torso;

    public GameObject heldWeapon;
    private WeaponBehavior heldWeaponScript;

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Script = GetComponent<PlayerManager>();

        if (heldWeapon) heldWeaponScript = heldWeapon.GetComponent<WeaponBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && heldWeapon != null) heldWeaponScript.PullTrigger();

        TalkToChildren();

        //Debug.Log(heldWeapon + " "  + heldWeaponScript);
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

    public void AddWeapon(GameObject prefabWeapon)
    {
        if (heldWeapon) Destroy(heldWeapon);
        GameObject weapon = (GameObject)Instantiate(prefabWeapon, transform.position, transform.rotation);
        heldWeapon = weapon;
        heldWeaponScript = heldWeapon.GetComponent<WeaponBehavior>();
        heldWeapon.transform.SetParent(this.transform);
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
