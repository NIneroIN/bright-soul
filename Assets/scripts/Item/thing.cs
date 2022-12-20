using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thing : MonoBehaviour
{
    [SerializeField] public GameObject _light;
    [SerializeField] public bool isOn;

    private void Start()
    {
        _light.SetActive(isOn);
    }

    public void SwithLight()
    {
        _light.SetActive(isOn);
        isOn = !isOn;
    }
}
