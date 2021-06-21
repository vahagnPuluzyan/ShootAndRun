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
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Enemy")
        {
            hitFx.Play();
            other.gameObject.GetComponent<MeshExploder>().Explode();
            Destroy(gameObject,0.3f);
            Destroy(other.gameObject);
            CharacterCollision._instance.enemy = false;
        }
        if (other.gameObject.tag == "Obstacle")
        {
            hitFx.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}