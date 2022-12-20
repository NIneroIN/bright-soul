using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSomething : MonoBehaviour
{
    public bool hold;
    public float distance = 5f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject = 5;


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!hold)
            {
                Physics2D.queriesStartInColliders = false;
                if (holdPoint.position.x > transform.position.x)
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                }
                else
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance);
                }


                if (hit.collider != null && hit.collider.tag == "Takeable")
                {
                    hold = true;
                }

            }
            else
            {
                hold = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    if (holdPoint.position.x > transform.position.x)
                    {
                        hit.collider.enabled = true;
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwObject;
                    }
                    else
                    {
                        hit.collider.enabled = true;
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * -1, 1) * throwObject;
                    }

                }
            }

        }
        if (hold)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;

            if (holdPoint.position.x > transform.position.x && hold == true)
            {
                hit.collider.enabled = false;
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * 20f, transform.localScale.y * 20f);
            }
            else if (holdPoint.position.x < transform.position.x && hold == true)
            {
                hit.collider.enabled = false;
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * 20f, transform.localScale.y * 20f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);

    }
    
}
