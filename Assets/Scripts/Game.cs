using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    //Main state machine
    private Player _player;
    public GameObject Planet;
    public List<Enemy> Enemies; 

	void Start ()
	{
	    InitializePlayer();
	    InitializeEnemies();
	}

	void Update ()
    {
	    
    }

    private void InitializePlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void InitializeEnemies()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Enemies.Add(enemy.GetComponent<Enemy>());
        }
        Enemies.ForEach(e => e.SetState(Enemy.EnemyState.Moving));
    }
}
