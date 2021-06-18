using UnityEngine;

public class Rotor : MonoBehaviour
{
    public Vector3 rotate;

    void Update()
    {
        transform.Rotate(rotate);
    }
}
