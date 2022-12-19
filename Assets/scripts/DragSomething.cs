using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSomething : MonoBehaviour
{
    public bool drag;
    public float distance = 5f;
    RaycastHit2D hit;
    public Transform dragPoint;
    public float throwObject = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!drag)
            {
                Physics2D.queriesStartInColliders = false;
                if (dragPoint.position.x > transform.position.x)
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                }
                else
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance);
                }


                if (hit.collider != null && hit.collider.tag == "Draggable")
                {
                    drag = true;
                }

            }
            else
            {
                drag = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    if (dragPoint.position.x > transform.position.x)
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
        if (drag)
        {
            hit.collider.gameObject.transform.position = dragPoint.position;

            if (dragPoint.position.x > transform.position.x && drag == true)
            {
                hit.collider.enabled = false;
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * 40f, transform.localScale.y * 40f);
            }
            else if (dragPoint.position.x < transform.position.x && drag == true)
            {
                hit.collider.enabled = false;
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * 40f, transform.localScale.y * 40f);
            }
            

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);

    }
}
