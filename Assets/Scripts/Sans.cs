using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sans : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();
    private ShootAttack shootAttack => GetComponentInChildren<ShootAttack>();
    private void Start()
    {
        StartCoroutine("Attack");
    }
    IEnumerator Attack()
    {
        animator.SetTrigger("Spawn");
        yield return new WaitForSeconds(2);
        shootAttack.Play(6, 1);
        yield return new WaitForSeconds(6);
        animator.Play("Respawn");
        yield return new WaitForSeconds(2);
        shootAttack.Play(6, 2);
        yield return new WaitForSeconds(6);
        animator.Play("Respawn");
        yield return new WaitForSeconds(2);
        shootAttack.Play(6, 3);
        yield return new WaitForSeconds(6);

    }
}
