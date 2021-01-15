using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : GameCharacter
{
    public string enemyType;
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
        PlayerManager.instance.player.GetComponent<PlayerStat>().addCreature(this.enemyType);
        Destroy(gameObject);
    }
}
