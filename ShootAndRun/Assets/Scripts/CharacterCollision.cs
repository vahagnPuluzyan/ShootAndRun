using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    public static CharacterCollision _instance;

    public Animator hitAnimator;
    [HideInInspector] public bool started, enemy;

    private void Start()
    {
        _instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Start")
        {
            started = true;
        }

        if (other.gameObject.tag == "Cartridge")
        {
            Destroy(other.gameObject);
            Vibration.Vibrate(70);
            Shooting._instance.cartidges += 3;
        }
        if (other.tag == "Wall" || other.tag == "Enemy")
        {
            enemy = true;
        }

        if (other.gameObject.tag == "Finish")
        {
            GameManager._instance.FinishGame();
            SkinManager._instance.NextWeapon();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall" || other.tag == "Enemy")
        {
            enemy = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "StrongWall")
        {
            Vibration.Vibrate(100);
            Destroy(other.gameObject, 0.5f);
            if (Shooting._instance.cartidges < 5)
            {
                hitAnimator.SetBool("Hit", true);
                Shooting._instance.cartidges = 0;
            }
            else
            {
                Shooting._instance.cartidges -= 5;
                hitAnimator.SetBool("Hit", true);
            }
        }

        if (other.gameObject.tag == "Wall")
        {
            Vibration.Vibrate(100);
            Destroy(other.gameObject,0.5f);
            if (Shooting._instance.cartidges < 10)
            {
                hitAnimator.SetBool("Hit", true);
                Shooting._instance.cartidges = 0;
            }
            else
            {
                Shooting._instance.cartidges -= 10;
                hitAnimator.SetBool("Hit",true);
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        { 
            hitAnimator.SetBool("Hit", false);
        }
    }
}
