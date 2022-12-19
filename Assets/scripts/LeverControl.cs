using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverControl : MonoBehaviour
{
    public bool isOff = false;
    public bool collision = false;
    //public Image button;
    public GameObject[] light;
    public GameObject[] item;
    public GameObject[] itemDark;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && collision)
        {
            isOff = !isOff;
        }
        SetItemActive(light, !isOff);
        SetItemActive(item, !isOff);
        SetItemActive(itemDark, isOff);
        //button.gameObject.SetActive(collision);
    }

    void SetItemActive(GameObject[] items, bool state)
    {
        foreach (GameObject item in items)
        {
            item.SetActive(state);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.collision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.collision = false;
        }
    }


}
