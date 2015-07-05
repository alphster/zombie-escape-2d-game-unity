using UnityEngine;
using System.Collections;

public class WeaponBehavior : MonoBehaviour {

    public GameObject projectile;
    public Transform projectileSpawn;
    public float fireRate;

    Animator muzzleFlash;
    float nextFire = 0.0f;    

    void Start() {
        muzzleFlash = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        muzzleFlash.ResetTrigger("Trigger");
    }

    public void PullTrigger()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            muzzleFlash.SetTrigger("Trigger");            
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        }
    }
}
