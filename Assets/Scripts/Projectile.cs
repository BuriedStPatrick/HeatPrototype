using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using System;

public class Projectile : MonoBehaviour {

    public float Velocity;
    public float SecondsAlive;
    public float Damage = 25;

    private Rigidbody2D _body;
    private DateTime _startTime;
    private TimeSpan _aliveTime;
    public Transform ExplosionPrefab;

	// Use this for initialization
	void Start ()
    {
        _startTime = DateTime.Now;
        _body = GetComponent<Rigidbody2D>();
        _aliveTime = TimeSpan.FromSeconds(SecondsAlive);
	}
	
	// Update is called once per frame
	void Update ()
    {
        var measureTime = DateTime.Now;
        if ((measureTime - _startTime) > _aliveTime)
        {
            Destroy(this.gameObject);
        }

        _body.velocity = _body.transform.TransformDirection(Vector2.up * (Velocity));
	}

    public void Explode(GameObject other)
    {
        switch (other.tag)
        {
            case "Enemy":
                Instantiate(ExplosionPrefab, transform.position, transform.rotation);
                break;
        }
    }
}
