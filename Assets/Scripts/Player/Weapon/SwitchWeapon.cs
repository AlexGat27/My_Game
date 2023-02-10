using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public int indexWeapon;
    public GameObject[] weapons;
    public GameObject[] buttons;
    void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
            buttons[i].SetActive(false);
        }
        weapons[0].SetActive(true);
        buttons[0].SetActive(true);
        indexWeapon = 0;
    }

    public void Switch()
    {
        if (indexWeapon != weapons.Length - 1) indexWeapon++;
        else indexWeapon = 0;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
            buttons[i].SetActive(false);
        }
        weapons[indexWeapon].SetActive(true);
        buttons[indexWeapon].SetActive(true);
    }
}
