using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    PlayerMotor motor;
    bool rotated = true;

    Vector3 rotateDirection;

    public LayerMask movementMask;
    public Transform bullterTransform;
    public GameObject bullet;
    public Transform enemy;

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

        if (Input.GetKeyDown("q") && enemy != null)
        {
            rotateDirection = Vector3.RotateTowards(transform.forward, new Vector3(enemy.position.x, transform.position.y, enemy.position.z) - this.transform.position, 360, 100);
            
            transform.rotation = Quaternion.LookRotation(rotateDirection);

            rotated = false;
        }

        if(rotated == false && Vector3.Angle(rotateDirection, transform.forward) < 1f)
        {
            GameObject bulletInstance = Object.Instantiate(bullet, bullterTransform.position, Quaternion.identity);
            bulletInstance.GetComponent<BullterAttack>().attack(enemy);
            rotated = true;
        }

        if (Input.GetKeyDown("z"))
        {
            GetComponent<PlayerStat>().takeDamage(10);
            Debug.Log("kk");
        }
    }
}
