using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
    static public int health = 100;
    static public bool dead = false;
    static public void GetDamage(int damage)
    {
        health = health - damage;
        Debug.Log("Enemy lost Health" + damage);
    }
  
	// Use this for initialization
    bool increase = true;
    bool stay = false;
    float x;
    int i = 0;
    void Start()
    {
        x = 1109f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            
            Debug.Log("Enemy get a bullet");
            GetDamage(Bullet.damage);
            Debug.Log("Enemy damaged");
            
            
            Destroy(other.gameObject);
            if (health<=0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy is dead");
            }
            
        }
    }
	
	// Update is called once per frame
    void Update()
    {
        if (!stay)
        {
            if (increase)
            {
                this.transform.Translate(2f, 0f, 0f);
                x += 2f;
            }
            if (!increase)
            {
                this.transform.Translate(-2f, 0f, 0f);
                x -= 2f;
            }
        }

        if (x <= 1109)
        {
            increase = true;
            stay = true;
        }
        if (x >= 1344)
        {
            increase = false;
            stay = true;
        }
        if (stay)
        {
            i = i + 1;
            if (i >= 120)
            {
                i = 0;
                stay = false;

            }
        }
    }
}
