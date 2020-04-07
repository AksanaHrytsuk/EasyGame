using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        MusicPlayer[] pointsList = FindObjectsOfType<MusicPlayer>();
        if (pointsList.Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
