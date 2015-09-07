using System;
using UnityEngine;
using System.Collections;
using Random = System.Random;

public class Enemy : MonoBehaviour {

    public enum EnemyState
    {
        Idle,
        Moving,
        Attacking,
        Dead
    }

    public float Health = 100;
    public float Velocity = 25;
    public AudioClip ImpactSound;
    private EnemyState _state;
    private GameObject _planet;
    private bool right = new Random().Next(1) == 1;

	void Start ()
	{
	    _state = EnemyState.Idle;
        _planet = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>().Planet;
        //Fix Enemy's orientation
        var norTar = (_planet.transform.position - transform.position).normalized;
        var angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        var rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 270);
        transform.rotation = rotation;
	}

	void Update ()
    {
        //Basic AI states
	    switch (_state)
	    {
	        case EnemyState.Idle:
	            break;
            case EnemyState.Moving:
                transform.RotateAround(_planet.transform.position, Vector3.back, Velocity * Time.deltaTime);
	            break;
            case EnemyState.Attacking:
	            break;
            case EnemyState.Dead:
	            break;
	    }
	}

    void OnTriggerEnter2D(Component other)
    {
        switch (other.gameObject.tag)
        {
            case "FriendlyProjectile":
                AudioSource.PlayClipAtPoint(ImpactSound, transform.position);
                var projectile = other.gameObject.GetComponent<Projectile>();
                projectile.Explode(gameObject);
                Health -= projectile.Damage;
                Destroy(other.gameObject);
                
                if (Health <= 0)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }

    public void SetState(EnemyState state)
    {
        _state = state;
    }
}
