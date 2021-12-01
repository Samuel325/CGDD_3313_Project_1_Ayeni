using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Samuel Ayeni

public class ProjectileScript : MonoBehaviour
{
    public float damage;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * 10f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) {
            other.GetComponent<EnemyScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
