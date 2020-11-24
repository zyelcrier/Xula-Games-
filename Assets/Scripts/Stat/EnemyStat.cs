using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : GameCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        this.characterType = "enemy";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override
    public void die()
    {
        Destroy(gameObject);
    }
}
