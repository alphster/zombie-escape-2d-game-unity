using UnityEngine;
using System.Collections;

public class WeaponBehavior : MonoBehaviour {

    public GameObject projectile;
    public Transform projectileSpawn;
    public float fireRate;

    Animator muzzleFlash;
    float nextFire = 0.0f;
    float nextFirePolarity = 1;
    AudioSource audioSource;


    //float test;

    void Start() {
        muzzleFlash = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

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
            audioSource.Play();

            // Use player accuracy to improve precision.
            nextFirePolarity *= -1;
            var angleFlaw = Mathf.Abs(PlayerManager.Script.accuracy - 1.0f) * Random.Range(0, 10) * nextFirePolarity;
            var finalRotation = Quaternion.Euler(projectileSpawn.rotation.eulerAngles + new Vector3(0, 0, angleFlaw));//new Quaternion(projectileSpawn.rotation.x, projectileSpawn.rotation.y, projectileSpawn.rotation.z + 0.1f, projectileSpawn.rotation.w);
            
            // push damage value to projectile
            var obj = (GameObject)Instantiate(projectile, projectileSpawn.position, finalRotation);            
            obj.GetComponent<ProjectileMover>().damage = 10.0f;
        }
    }
}
