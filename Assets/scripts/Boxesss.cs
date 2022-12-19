using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxesss : MonoBehaviour
{
    public static bool collision;
    
    // Start is called before the first frame update
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Boxesss.collision = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Boxesss.collision = false;
        }
    }
    
}
