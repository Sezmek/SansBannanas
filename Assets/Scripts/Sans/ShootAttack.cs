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
    private int basicAttackFrequency;
    private int blueAttackFrequency;
    private int redAttackFrequency;
    private int basicAttackSpeed;
    private int blueAttackSpeed;
    private int redAttackSpeed;

    public void Play(int sec, int attack, int frequency, int speed)
    {
        duration = sec;
        switch (attack)
        {
            case 1:
                basicAttackFrequency = frequency;
                basicAttackSpeed = speed;
                StartCoroutine("BasicAttack");
                break;
            case 2:
                blueAttackFrequency = frequency;
                blueAttackSpeed = speed;
                StartCoroutine("BlueAttack");
                break;
            case 3:
                redAttackFrequency = frequency;
                redAttackSpeed = speed;
                StartCoroutine("RedAttack");
                break;
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
                yield return new WaitForSeconds(basicAttackFrequency);
                tmpObject.GetComponent<BoneShot>().Shoot(basicAttackSpeed);
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
                yield return new WaitForSeconds(blueAttackFrequency);
                tmpObject.GetComponent<BoneShot>().Shoot(blueAttackSpeed);
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
                yield return new WaitForSeconds(redAttackFrequency);
                tmpObject.GetComponent<BoneShot>().Shoot(redAttackSpeed);
                IsShooting[RespawnPoint] = false;

            }
        }
    }
}
