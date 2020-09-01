using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy;
    private PlayerController Player;
    public GameObject EnemyPointer;
    public event Action enemyGenerated;
    public float rate = 1.0f;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        InvokeRepeating("CreateEnemy", 1,10f/ rate);
    }
    public void CreateEnemy()
    {
        enemyGenerated?.Invoke();
        var EnemyInstace = Instantiate(Enemy, Player.GetRandomPositionInsideCircle(50f),transform.rotation);
        EnemyInstace.GetComponent<HomingMissile>().rotationSpeed = UnityEngine.Random.Range(200f, 300f);
        //var EnPointer = Instantiate(EnemyPointer, Player.transform);
        //EnPointer.GetComponent<Pointer>().target = EnemyInstace.transform;
    }
}
