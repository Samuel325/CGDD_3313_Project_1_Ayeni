using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Samuel Ayeni

public class EnemyScript : MonoBehaviour
{
    private float health, healthBarScale;
    private bool alive;
    public Transform healthBar;
    public TextMesh healthText;
    private Vector3 temp;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;

            if (health <= 0.0f)
            {
                Alive = false;
            }
        }
    }

    private bool Alive
    {
        get { return alive; }
        set {
            alive = value;

            if (!alive)
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Alive = true;
        health = 100.0f;
        temp = healthBar.transform.localScale; //Stores the initial value of the health bar
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        healthBar.transform.localScale = Vector3.Lerp(temp, new Vector3(Health / 100.0f, healthBar.transform.localScale.y, healthBar.transform.localScale.z), Time.fixedTime);

        healthText.text = ((Health / 100.0f) * 100.0f).ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Contains("Player"))
        {
            other.GetComponent<PlayerScript>().TakeDamage(5.0f);
        }
    }
}
