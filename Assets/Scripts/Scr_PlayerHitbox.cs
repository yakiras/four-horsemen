using UnityEngine;
using System;

public class Hitbox : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy oww!");
            // Call the enemy’s damage function
            //other.GetComponent<EnemyHealth>()?.TakeDamage(damage);
        }
    }
}
