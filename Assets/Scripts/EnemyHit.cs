using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    EnemyBehavior parentScript;
    GameObject bloodSpurt1;
    GameObject bloodSpurt2;
    bool flip = false;

    void Start()
    {
        parentScript = GetComponentInParent<EnemyBehavior>();
        bloodSpurt1 = Resources.Load<GameObject>("Prefabs/BloodSpurt/BloodSpurt1");
        bloodSpurt2 = Resources.Load<GameObject>("Prefabs/BloodSpurt/BloodSpurt2");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Projectile")
        {
            parentScript.TakeDamage(other.GetComponent<ProjectileMover>().damage);

            var bloodSpurt = flip ? bloodSpurt1 : bloodSpurt2;
            flip = !flip;

            var rot = other.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y, rot.z + 180);
            Instantiate(bloodSpurt, transform.position, Quaternion.Euler(rot));
        }
    }
}
