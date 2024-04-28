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
        shootAttack.Play(6, 1, 1, 40);
        yield return new WaitForSeconds(6);
        animator.Play("Respawn");
        yield return new WaitForSeconds(2);
        shootAttack.Play(6, 1, 1, 30);
        shootAttack.Play(8, 2, 2, 55);
        yield return new WaitForSeconds(6);
        animator.Play("Respawn");
        yield return new WaitForSeconds(2);
        shootAttack.Play(8, 3, 1, 50);
        yield return new WaitForSeconds(6);

    }
}
