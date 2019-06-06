using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BonusController : MonoBehaviour
{
    public GameObject Hacker;


// Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }


}
