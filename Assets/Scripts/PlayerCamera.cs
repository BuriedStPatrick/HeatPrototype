using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public Transform Target;
    public float DampTime = 0.15f;

    private Vector3 _velocity = Vector3.zero;

    void Update()
    {
        if (!Target) return;
        var point = GetComponent<Camera>().WorldToViewportPoint(Target.position);
        var delta = Target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        var destination = transform.position + delta;
        transform.rotation = Target.transform.rotation;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, DampTime);
    }
}
