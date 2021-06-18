using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager _instance;

    public List<GameObject> weapons;
    public int currentWeapon;

    void Start()
    {
        _instance = this;
        currentWeapon = PlayerPrefs.GetInt("Weapon");
        weapons[currentWeapon].SetActive(true);
    }

    public void NextWeapon()
    {

    }
}
