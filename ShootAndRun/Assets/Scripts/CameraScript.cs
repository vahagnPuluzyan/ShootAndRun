using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    [SerializeField] float _distance;
    public List<Color> colors;

    private void Start()
    {
        GetComponent<Camera>().backgroundColor = colors[Random.Range(0, colors.Count - 1)];
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,target.position.z - _distance); 
    }
}
