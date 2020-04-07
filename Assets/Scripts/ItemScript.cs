using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    //public int hitPoint;
    public int scorePoints;

    public Sprite[] images;
    public AudioClip foodSound;
    // public GameObject effectSound;
    private MainScript pointsControl;
    
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
