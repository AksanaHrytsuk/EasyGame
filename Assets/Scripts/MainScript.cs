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
    private int addSpeed = 0;
    
    
    [Header("Config Parameters")]
    
    public int maxLives ;
    public int addPoints;

    public List<GameObject> food;

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
            GameObject newItem = Instantiate(food[rand], position, Quaternion.identity);
            addSpeed -= 50;
            Vector3 force = new Vector3(0, Random.Range(-400+addSpeed, addSpeed), 0);
            newItem.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
    public void ItemDown()
    {
        
        _itemScript = FindObjectOfType<ItemScript>();
        
        maxLives--;
        _lives.text = "Lives: " + maxLives;
        Debug.Log("CollisionEnterWall");
        if (maxLives == 0)
        {
            _loaderScene = new LoaderScene();
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