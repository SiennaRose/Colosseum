using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerState : MonoBehaviour
{
    [System.Serializable]
    public class Items
    {
        public string name;
        public GameObject item; 
    }

    public GameObject hptxt; 
    public int currHP = 100;
    public int maxHP = 100;
    public List<Items> items = new List<Items>(); 

    public void addItem(string myName, GameObject myItem)
    {
        Items it = new Items();
        it.name = myName;
        it.item = myItem;
        items.Add(it); 
    }

    public void damage(int dmg)
    {
        currHP -= dmg;
        hptxt = GameObject.Find("HPText");
        hptxt.GetComponent<Text>().text = "HP = " + currHP.ToString();
        if (currHP == 0)
            UIController.Instance.Died();
    }

    public void heal(int hp)
    {
        if (currHP != maxHP)
            currHP += hp; 
    }
}
