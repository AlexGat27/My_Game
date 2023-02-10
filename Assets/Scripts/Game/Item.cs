using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject enterbutton;
    public SwitchWeapon switchWeapon;

    private void OnTriggerStay2D(Collider2D collider)
    {
        switchWeapon.buttons[switchWeapon.indexWeapon].SetActive(false);
        enterbutton.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        switchWeapon.buttons[switchWeapon.indexWeapon].SetActive(true);
        enterbutton.SetActive(false);
    }
}
