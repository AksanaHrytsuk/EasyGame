using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
   
    public int scorePoints;
    private MainScript pointsControl;
    
    public AudioClip foodSound;
    // public GameObject effectSound;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            AudioSource audio = FindObjectOfType<AudioSource>();
            audio.PlayOneShot(foodSound);

            pointsControl = FindObjectOfType<MainScript>();
            pointsControl.CountPoints(scorePoints);
        }
        Destroy(gameObject);
    }
}
