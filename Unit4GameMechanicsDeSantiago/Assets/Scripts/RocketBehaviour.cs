using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{

    private float speed = 1000f;
    private bool homing;

    private float rocketStrength = 15.0f;
    private float aliveTimer = 5.0f;

    private float projectileSpeed = 5;
    private GameObject target;
    // Start is called before the first frame update
   public void Fire(Transform newTarget)
    {
       
        homing = true;
        Destroy(gameObject, aliveTimer );
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Enemy");

        transform.LookAt(target.transform.position);
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        if(target != null)
        {
            if (col.gameObject.CompareTag(target.tag))
            {
                Rigidbody targetRigidBody = col.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -col.contacts[0].normal;
                targetRigidBody.AddForce(away * rocketStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
        
    }
}
