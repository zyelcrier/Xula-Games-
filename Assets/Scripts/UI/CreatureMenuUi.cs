using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureMenuUi : MonoBehaviour
{
    public GameObject childrenPanel;

    public Sprite redBox;

    public List<GameObject> slotList = new List<GameObject>();

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // get the reference to the player
        player = PlayerManager.instance.player;

        Transform[] slotArray = childrenPanel.GetComponentsInChildren<Transform>();

        if(slotArray != null)
        {
            foreach(Transform t in slotArray)
            {
                if(t != null && t.tag == "slot")
                {
                    slotList.Add(t.gameObject);
                }
            }
        }

        updateCreatureUI();

        Debug.Log(slotList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        updateCreatureUI();
    }

    public void updateCreatureUI()
    {
        for (int i = 0; i < 6; i++)
        {
            if(player.GetComponent<PlayerStat>().creatureList.Count > 0 
                && i < player.GetComponent<PlayerStat>().creatureList.Count)
            {
                if(player.GetComponent<PlayerStat>().creatureList[i].ToLower().Equals("redbox"))
                {
                    slotList[i].GetComponent<PickingCreatureButton>().creatureType = "redbox";

                    slotList[i].GetComponent<Image>().enabled = true;
                    slotList[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                    slotList[i].transform.GetChild(0).GetComponent<Image>().sprite = redBox;
                }
            }

            else
            {
                slotList[i].GetComponent<Image>().enabled = false;
                slotList[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }
}
