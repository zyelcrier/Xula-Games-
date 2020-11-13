using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    private float zoom = 10f;

    public float pitch = 2f;

    public float yawSpeed = 100f;

    private float currentYaw = 180f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        currentYaw += Input.GetAxis("Horizontal")*yawSpeed*Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position -  offset*zoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
