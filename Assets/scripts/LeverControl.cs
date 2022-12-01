using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverControl : MonoBehaviour
{
    public bool isOn = false;
    bool collision = false;
    public Image button;
    public GameObject door;

    private void Start()
    {
        //button.gameObject.SetActive(collision);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && collision)
        {
            if (!isOn)
            {
                isOn = true;
                //transform.GetComponent<Animator>().SetBool("isOpen", true);
                Destroy(door);
            }
        }
        button.gameObject.SetActive(collision);
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
