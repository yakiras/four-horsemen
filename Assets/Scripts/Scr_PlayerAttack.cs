using UnityEngine;
using System;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject hitbox;
    public float windupTime = 0.2f;   // delay before strike
    public float activeTime = 0.15f;  // how long hitbox stays active
    public float cooldown = 0.3f;     // time before another attack
    private bool canAttack = true;

    private Animator anim;

    void Start() => anim = GetComponent<Animator>();

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canAttack)
            StartCoroutine(DoAttack());
    }

    IEnumerator DoAttack()
    {
        Console.WriteLine("Attacking");
        canAttack = false;
        //anim.SetTrigger("Attack");  // Trigger attack animation

        yield return new WaitForSeconds(windupTime);
        hitbox.SetActive(true);     // Hitbox becomes active with the swing

        yield return new WaitForSeconds(activeTime);
        hitbox.SetActive(false);
        Console.WriteLine("CD");

        yield return new WaitForSeconds(cooldown);
        canAttack = true;
        Console.WriteLine("Finished");
    }
}
