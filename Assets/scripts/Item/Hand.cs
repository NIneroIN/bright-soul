using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Transform _hand;
    [SerializeField] private LayerMask things;
    [SerializeField] private Collider2D hit;
    [SerializeField] private bool inHand;
    [SerializeField] private GameObject thing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.OverlapCircle(_hand.position, 20f, things);

        if (hit != null && Input.GetKeyDown(KeyCode.E) && !inHand)
        {
            thing = hit.gameObject;
            inHand = true;
        }

        if (inHand)
        {
            thing.transform.localScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;
            thing.transform.position = _hand.position;
            if (Input.GetKeyDown(KeyCode.F))
            {
                thing.GetComponent<thing>().SwithLight();
            }
        }
    }
}
