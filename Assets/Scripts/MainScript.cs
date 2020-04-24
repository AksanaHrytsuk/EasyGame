using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainScript : MonoBehaviour
{
    [Header("UI Elements")]
    public Text _lives;
    public Text _points;
    public Transform createPosition;
    
    [Header("Config Parameters")]
    public int maxLives ;
    public int addPoints;
    
    private LoaderScene _loaderScene;
    private ItemScript _itemScript;
    private AudioSource _audioSource;
    private int addSpeed;

    public List<GameObject> food;

    private void Awake()
    {
        MainScript[] mainScriptsList = FindObjectsOfType<MainScript>();
        // Debug.Log(pointsList.Length);
        if (mainScriptsList.Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        InvokeRepeating("CreateItem", 0.5f, 1);
    }

    private void CreateItem()
    {
        if (maxLives > 0)
        {
            Vector3 position = new Vector3(Random.Range(-6, 7), createPosition.position.y, createPosition.position.z);
            int rand = Random.Range(0, food.Count);
            GameObject newItem = Instantiate(food[rand], position, Quaternion.identity);
            addSpeed -= 20;
            Vector3 force = new Vector3(0, Random.Range(addSpeed - 400, addSpeed), 0);
            newItem.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
    public void ItemDown()
    {
        maxLives--;
        _lives.text = "Lives: " + maxLives;
 
        if (maxLives == 0)
        {
            _loaderScene = gameObject.AddComponent<LoaderScene>();
            //_loaderScene = FindObjectOfType<LoaderScene>();
            _loaderScene.LoadNextSceneByName("Game Over");
        }
    }
    public void CountPoints(int score)
    {
        addPoints += score;
        _points.text = "Points: " + addPoints;
    }

    public void PlaySound(AudioClip sound)
    {
        _audioSource.PlayOneShot(sound);
    }
}
