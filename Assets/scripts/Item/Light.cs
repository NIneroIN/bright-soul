using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            collision.GetComponent<Item>().ChangeLight(false);
            Debug.Log("OnTriggerExit2D");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            collision.GetComponent<Item>().ChangeLight(true);
            Debug.Log("OnTriggerStay2D");
        }
    }
}
