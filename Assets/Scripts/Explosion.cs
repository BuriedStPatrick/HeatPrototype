using System;
using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public float SecondsAlive = 1f;
    private DateTime _startTime;
    private TimeSpan _aliveTime;

	// Use this for initialization
	void Start ()
	{
        _startTime = DateTime.Now;
        _aliveTime = TimeSpan.FromSeconds(SecondsAlive);
	}
	
	// Update is called once per frame
	void Update ()
    {
        var measureTime = DateTime.Now;
        if ((measureTime - _startTime) > _aliveTime)
        {
            Destroy(gameObject);
        }
	}

    void OnDestroy()
    {

    }
}
