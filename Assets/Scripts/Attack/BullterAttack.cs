using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullterAttack : MonoBehaviour
{
    public int bulletDamage = 10;
    bool fired = false;
    public float strength;
    Vector3 direction;
    float createdTime;
    float collidedTime;

    bool collidedStOtherThanEnemy = false;
    private void Start()
    {
        createdTime = Time.time;    
    }

    // Update is called once per frame
    void Update()
    {
        // Check if fired
        if(fired)
        {
            fired = false;
            GetComponent<Rigidbody>().AddForce(direction*strength);
        }

        if((collidedStOtherThanEnemy && Time.time - collidedTime > 2f) || Time.time - createdTime > 8f)
        {
            Destroy(gameObject);
        }
    }

    public void attack(Transform target)
    {
        fired = true;

        // Get the force direction
        direction = new Vector3(target.position.x, target.position.y,target.position.z) - this.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is an enemy, if true, destroy self
        if(collision.collider.gameObject.GetComponent<GameCharacter>() != null && 
           collision.collider.gameObject.GetComponent<GameCharacter>().characterType.ToLower().Equals("enemy"))
        {
            collision.collider.gameObject.GetComponent<GameCharacter>().takeDamage(bulletDamage);
            Destroy(gameObject);
        }

        else
        {
            collidedStOtherThanEnemy = true;
            collidedTime = Time.time;
        }
    }
}
