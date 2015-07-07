using UnityEngine;
using System.Collections;

public class WeaponBehavior : MonoBehaviour {

    public GameObject projectile;
    public Transform projectileSpawn;
    public float fireRate;

    Animator muzzleFlash;
    float nextFire = 0.0f;
    float nextFirePolarity = 1;

    //float test;

    void Start() {
        muzzleFlash = GetComponentInChildren<Animator>();
        //test = Random.value;
    }

    public void Update()
    {
        //Debug.Log(test);
    }

    public void PullTrigger()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            muzzleFlash.SetTrigger("Trigger");

            // Use player accuracy to improve precision.
            nextFirePolarity *= -1;
            var angleFlaw = Mathf.Abs(PlayerManager.Script.accuracy - 1.0f) * Random.Range(0, 10) * nextFirePolarity;
            var finalRotation = Quaternion.Euler(projectileSpawn.rotation.eulerAngles + new Vector3(0, 0, angleFlaw));//new Quaternion(projectileSpawn.rotation.x, projectileSpawn.rotation.y, projectileSpawn.rotation.z + 0.1f, projectileSpawn.rotation.w);
            Instantiate(projectile, projectileSpawn.position, finalRotation);
            
            
        }
    }
}
