using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverControl : MonoBehaviour
{
    public bool isOn = false;
    public bool collision = false;
    //public Image button;
    public GameObject item;

    private void Start()
    {
        //button.gameObject.SetActive(collision);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && collision)
        {
            item.SetActive(!isOn);
            isOn = !isOn;
        }
        //button.gameObject.SetActive(collision);
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
