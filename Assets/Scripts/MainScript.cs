using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    [Header("UI Elements")]
    
    public Text _lives;
    public Text _points;
    private LoaderScene _loaderScene;
    private ItemScript _itemScript;
    
    
    [Header("Config Parameters")]
    
    public int maxLives = 10;
    public int addPoints;

    public List<GameObject> food;
    
    // private void Awake()
    // {
    //     MainScript [] pointsList = FindObjectsOfType<MainScript>();
    //     if (pointsList.Length > 1)
    //     {
    //         gameObject.SetActive(false);
    //         Destroy(gameObject);
    //     }
    //     DontDestroyOnLoad(this.gameObject);
    // }
    private void Start()
    {
        InvokeRepeating("CreateItem", 0, 1);
    }

    private void CreateItem()
    {
        if (maxLives > 0)
        {
            Vector3 position = new Vector3(Random.Range(-6, 7), 3, 2);
            int rand = Random.Range(0, food.Count);
            Instantiate(food[rand], position, Quaternion.identity);
        }
    }
    public void ItemDown()
    {
        _loaderScene = FindObjectOfType<LoaderScene>();
        _itemScript = FindObjectOfType<ItemScript>();
        
        maxLives--;
        _lives.text = "Lives: " + maxLives;
        Debug.Log("CollisionEnterWall");
        if (maxLives == 0)
        {
            _loaderScene.LoadNextSceneByName("Game Over");
        }
    }

    public void CountPoints(int score)
    {
        _lives.text = "Lives: " + maxLives;
        addPoints += score;
        _points.text = "Points: " + addPoints;
    }
}