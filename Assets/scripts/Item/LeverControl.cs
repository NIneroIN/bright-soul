using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverControl : MonoBehaviour
{
    public bool isOff = false;
    public bool collision = false;
    public GameObject[] light;
    public GameObject[] item;
    public GameObject[] itemDark;
    public GameObject[] itemDelete;
    public Image but;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && collision)
        {
            isOff = !isOff;
            foreach (GameObject item in itemDelete)
            {
                Destroy(item);
            }
        }
        but.gameObject.SetActive(collision);
        SetItemActive(light, !isOff);
        SetItemActive(item, !isOff);
        SetItemActive(itemDark, isOff);
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
            but.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.collision = false;
            but.enabled = false;
        }
    }
}
