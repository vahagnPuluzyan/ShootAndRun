using System.Collections.Generic;
using UnityEngine;

public class SetRandomFruit : MonoBehaviour
{
    public List<GameObject> fruits;

    void Start()
    {
        fruits[Random.Range(0,fruits.Count - 1)].SetActive(true);
    }
}
