using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Animator m_animator;
    public void TakeDamage(int damage)
    {
        currentHealht -= damage;
        
        m_animator.SetTrigger("Hurt");

        if (currentHealht <= 0)
            die();
        
    }

    void die()
    {
        m_animator.SetTrigger("Death");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    
    public int maxHealth = 100;
    public int currentHealht;

    public int moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        
        currentHealht = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        m_animator.SetInteger("AnimState", 2);
        
    }
}
