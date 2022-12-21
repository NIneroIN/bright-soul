using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public GameObject Panel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Spikes"))
        {
            Debug.Log(Moving.PlayerMove._rb.velocity.y);
        }
        if (collision.gameObject.tag.Equals("Spikes") && Moving.PlayerMove._rb.velocity.y < -200)
        {
            Panel.SetActive(true);
        }
    }
}
