using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public GameObject theBullet;
    public Transform barrelEnd;
    public List<GameObject> guns;
    public GameObject skate;

    [SerializeField] int bulletSpeed;
    [SerializeField] float despawnTime = 3.0f;
    [SerializeField] float waitBeforeNextShot = 0.25f;

    NavMeshAgent agent;
    Transform player;

    bool shootAble = true;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        guns[Random.Range(0, guns.Count - 1)].SetActive(true);
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
        if (agent.remainingDistance < 30)
        {
            if (shootAble)
            {
                shootAble = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }

    public void Shoot()
    {
        var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, despawnTime);
    }
}
