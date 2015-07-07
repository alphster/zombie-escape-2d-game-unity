using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {

    public float rotateSpeed = 1.5f;
    public GameObject UsableWeapon;

    SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        sprite.transform.Rotate(0, 0, rotateSpeed);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.Script.AddWeapon(UsableWeapon);            
        }
    }
}
