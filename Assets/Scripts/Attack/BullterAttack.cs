using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullterAttack : MonoBehaviour
{
    bool fired = false;
    Vector3 target;
    public float strength;
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        if(fired)
        {
            fired = false;
            GetComponent<Rigidbody>().AddForce(direction*strength);
        }
    }

    public void attack(Vector3 target)
    {
        fired = true;
        this.target = target;
        direction = target - this.transform.position;
    }
}
