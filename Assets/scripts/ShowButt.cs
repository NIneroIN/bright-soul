using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButt : MonoBehaviour
{
    bool collision = false;
    public Image button;
   
    

    // Update is called once per frame
    void Update()
    {
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
