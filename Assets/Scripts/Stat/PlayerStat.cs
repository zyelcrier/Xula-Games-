using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : GameCharacter
{
    public List<string> creatureList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        this.characterType = "player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCreature(string creatureType)
    {
        if(!creatureList.Contains(creatureType))
        {
            creatureList.Add(creatureType);
        }
    }
}
