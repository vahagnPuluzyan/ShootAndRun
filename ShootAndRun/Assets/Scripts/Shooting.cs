using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting _instance;

    public GameObject theBullet;
    public Transform barrelEnd;

    public int cartidges = 100;

    [SerializeField] int bulletSpeed;
    [SerializeField] float despawnTime = 3.0f;
    [SerializeField] float waitBeforeNextShot = 0.25f;

    bool shootAble = true;

    void Start()
    {
        _instance = this;
    }

    private void Update()
    {
        if (PlayerMovement._instance.shoot)
        {
            if (cartidges > 0 && shootAble)
            {
                shootAble = false;
                cartidges--;
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
        Vibration.Vibrate(20);
        Destroy(bullet, despawnTime);
    }
}
