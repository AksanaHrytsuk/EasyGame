using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int scorePoints;
    public bool enemy;
    public bool rotate;
    
    public AudioClip foodSound;
    
    private MainScript pointsControl;
    private CameraRotationScript _cameraRotationScript;

    private void Start()
    {
        _cameraRotationScript = FindObjectOfType<CameraRotationScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            // AudioSource audio = FindObjectOfType<AudioSource>();
            // audio.PlayOneShot(foodSound); 
            MainScript script = FindObjectOfType<MainScript>();
            
            script.PlaySound(foodSound);
            
            if (enemy)
            {
                script.ItemDown();
            }
            if (rotate)
            {
                _cameraRotationScript.RotationMainCamera();
            }
            pointsControl = FindObjectOfType<MainScript>();
            pointsControl.CountPoints(scorePoints);
        }
        Destroy(gameObject);
    }
}
