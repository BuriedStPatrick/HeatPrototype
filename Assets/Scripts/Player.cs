using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public enum PlayerState
    {
        Idle,
        Moving,
        Boosting,
        Damaged,
        Dead
    }

    public Rigidbody2D Projectile;
    public GameObject Planet;
    public float Velocity = 100;

    private Rigidbody2D _body;
    private float _distanceFromCore;
    private PlayerState _state;

	// Use this for initialization
	void Start () {
        _body = GetComponent<Rigidbody2D>();
        _distanceFromCore = (transform.position - Planet.transform.position).magnitude;
	    _state = PlayerState.Idle;
	}
	
	// Update is called once per frame
	void Update () {
        var centerVector = transform.position - Planet.transform.position;
        _body.transform.RotateAround(Planet.transform.position, Vector3.back, Input.GetAxis("Horizontal") * Velocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
	}


    void Fire()
    {
        Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z+1), transform.rotation);
    }
 
    public void SetState(PlayerState state)
    {
        _state = state;
    }
}
