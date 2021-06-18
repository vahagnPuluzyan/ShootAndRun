using UnityEngine;

public class BulletScript : MonoBehaviour
{
    ParticleSystem hitFx;

    private void Start()
    {
        hitFx = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            hitFx.Play();
            Destroy(gameObject,0.3f);
            Destroy(other.gameObject, 1f);
            CharacterCollision._instance.enemy = false;
        }
        if (other.gameObject.tag == "StrongWall")
        {
            hitFx.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}