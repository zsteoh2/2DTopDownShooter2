using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    [SerializeField] Text enemiesLeftText;
    List<Enemy> enemies = new List<Enemy>();

    private void OnEnable()
    {
        Enemy.OnEnemyKilled += HandleEnemyDefected;
    }


    private void OnDisable()
    {
        Enemy.OnEnemyKilled -= HandleEnemyDefected;
    }


    private void Awake()
    {
        enemies = GameObject.FindObjectsOfType<Enemy>().ToList();
        UpdateEnemiesLeftText();
    }

    private void Update()
    {
        enemies = GameObject.FindObjectsOfType<Enemy>().ToList();
        UpdateEnemiesLeftText();
    }

    void UpdateEnemiesLeftText()
    {
        enemiesLeftText.text = $"Enemies left : {enemies.Count}";
    }


    void HandleEnemyDefected(Enemy enemy)
    {
       if( enemies.Remove(enemy))
            UpdateEnemiesLeftText();
    }


    //Œﬁ ”
    //private void Awake()
    //{
    //    enemies = new List<Enemy>();
    //    enemies.Add(GameObject.FindObjectOfType<Enemy>());
    //}


    //private void Update()
    //{
    //    enemies = new List<Enemy>();
    //    enemies.AddRange(GameObject.FindObjectsOfType<Enemy>());
    //}

    }
