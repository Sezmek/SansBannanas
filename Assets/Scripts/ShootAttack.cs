using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class ShootAttack : MonoBehaviour
{
    [SerializeField] private Transform[] Respawns;
    private bool[] IsShooting = new bool[4];
    [SerializeField] private Object BonePrefab;
    [SerializeField] private Object BlueBonePrefab;
    [SerializeField] private Object RedBonePrefab;
    private int duration;

    public void Play(int sec, int attack)
    {
        duration = sec;
        if(attack==1)
            StartCoroutine("BasicAttack");
        if(attack==2)
        {
            StartCoroutine("BasicAttack");
            StartCoroutine("BlueAttack");
        }
        if (attack == 3)
        {
            StartCoroutine("BasicAttack");
            StartCoroutine("RedAttack");
        }

    }
    private IEnumerator BasicAttack()
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            int RespawnPoint = Random.Range(0, Respawns.Length);
            if (!IsShooting[RespawnPoint])
            {
                IsShooting[RespawnPoint] = true;
                Object tmpObject = Instantiate(BonePrefab, Respawns[RespawnPoint].transform);
                yield return new WaitForSeconds(1.5f);
                tmpObject.GetComponent<BoneShot>().Shoot(15);
                IsShooting[RespawnPoint] = false;

            }
        }
    }
    private IEnumerator BlueAttack()
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            int RespawnPoint = Random.Range(0, Respawns.Length);
            if (!IsShooting[RespawnPoint])
            {
                IsShooting[RespawnPoint] = true;
                Object tmpObject = Instantiate(BlueBonePrefab, Respawns[RespawnPoint].transform);
                yield return new WaitForSeconds(2);
                tmpObject.GetComponent<BoneShot>().Shoot(30);
                IsShooting[RespawnPoint] = false;

            }
        }
    }
    private IEnumerator RedAttack()
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            int RespawnPoint = Random.Range(0, Respawns.Length);
            if (!IsShooting[RespawnPoint])
            {
                IsShooting[RespawnPoint] = true;
                Object tmpObject = Instantiate(RedBonePrefab, Respawns[RespawnPoint].transform);
                yield return new WaitForSeconds(2);
                tmpObject.GetComponent<BoneShot>().Shoot(30);
                IsShooting[RespawnPoint] = false;

            }
        }
    }
}
