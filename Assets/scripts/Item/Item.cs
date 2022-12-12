using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool isLight;
    [SerializeField] private Collider2D _collider2D;

    // Update is called once per frame
    void Update()
    {
        if (!isLight)
        {
            gameObject.layer = 17;
        }
        else
        {
            gameObject.layer = 16;
        }

        transform.GetChild(0).gameObject.SetActive(isLight);
    }

    public void ChangeLight(bool state)
    {
        isLight = state;
    }
}
