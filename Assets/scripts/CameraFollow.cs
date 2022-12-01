using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player; // тут объект игрока
    public Vector3 offset = new Vector3(0, 4, -10);
    public bool isBoss = false;
    public Vector3 bossCam;

    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float upLimit;
    [SerializeField]
    private float downLimit;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        if (!isBoss)
        {
            transform.position = player.transform.position + offset;
            transform.position = new Vector3
                (
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, downLimit, upLimit),
                transform.position.z
                );
        }
        else
        {
            Vector3 target = new Vector3
                (
                bossCam.x,
                bossCam.y,
                transform.position.z
                );
            transform.position = target;

        }
    }
}
