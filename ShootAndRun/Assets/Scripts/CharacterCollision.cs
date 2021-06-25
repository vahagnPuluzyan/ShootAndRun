using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    public static CharacterCollision _instance;

    public ParticleSystem levelUpFx;
    public ParticleSystem boostFx;
    public GameObject skate;

    Animator anim;

    private void Start()
    {
        _instance = this;
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cartridge")
        {
            Destroy(other.gameObject);
            Vibration.Vibrate(70);
            Shooting._instance.cartidges += 3;
        }

        if (other.gameObject.tag == "Boost")
        {
            PlayerMovement._instance._speed += 13;
            boostFx.Play();
            anim.speed *= 2;
        }

        if (other.gameObject.tag == "Finish")
        {
            GameManager._instance.FinishGame();
        }
        if (other.gameObject.tag == "Water")
        {
            levelUpFx.Play();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Water")
        {
            anim.SetBool("Skate", true);
            skate.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Boost")
        {
            PlayerMovement._instance._speed -= 13;
            boostFx.Stop();
            anim.speed /= 2;
        }
        if (other.gameObject.tag == "Water")
        {
            anim.SetBool("Skate", false);
            skate.SetActive(false);
            levelUpFx.Play();
        }
    }
}
