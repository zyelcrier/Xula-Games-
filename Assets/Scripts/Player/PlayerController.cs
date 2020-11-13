using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    public LayerMask movementMask;
    PlayerMotor motor;
    public Transform bullterTransform;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, movementMask) && !motor.isOnAir())
            {
                motor.MoveToPoint(hit.point);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            motor.jump();
        }

        if (Input.GetKeyDown("q"))
        {
            GameObject bulletInstance = Object.Instantiate(bullet, bullterTransform.position, Quaternion.identity);

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, new Vector3(10, transform.position.y, 10) - this.transform.position, 360, 100);
            
            transform.rotation = Quaternion.LookRotation(newDirection);

            bulletInstance.GetComponent<BullterAttack>().attack(new Vector3(10, 10, 10));
        }
    }
}
