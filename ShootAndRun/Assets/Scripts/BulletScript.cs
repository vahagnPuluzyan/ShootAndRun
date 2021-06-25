using UnityEngine;

public class BulletScript : MonoBehaviour
{
    ParticleSystem hitFx;
    Transform character;

    private void Start()
    {
        character = FindObjectOfType<PlayerMovement>().transform;
        hitFx = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            hitFx.Play();
            Destroy(gameObject);
            Destroy(other.gameObject);
            PlayerMovement._instance.shoot = false;
            PlayerMovement._instance.index++;
        }
        if (other.gameObject.tag == "Player")
        {
            //hitFx.Play();
            Destroy(gameObject, 0.5f);
        }
    }
}