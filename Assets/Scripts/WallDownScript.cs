using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDownScript : MonoBehaviour
{
    private MainScript _mainScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _mainScript = FindObjectOfType<MainScript>();
        if (collision.gameObject.CompareTag("Food"))
        {
            Debug.Log("Destroy items");
            _mainScript.ItemDown();
        }
    }
}
