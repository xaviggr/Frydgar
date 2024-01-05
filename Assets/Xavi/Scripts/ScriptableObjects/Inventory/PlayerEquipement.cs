using System.Collections.Generic;
using UnityEngine;

public class PlayerObject
{
    public ItemObject itemO;

    public GameObject objectEquiped;
    public GameObject objectUnequiped;
}

public class PlayerEquipement : MonoBehaviour
{
    public InventoryController inv;

    public List<PlayerObject> playerO;
    public Dictionary<ItemObject, PlayerObject> playerObjectDic = new Dictionary<ItemObject, PlayerObject>();

    /*
    void OnEnable(){
        for(int i=0;i<playerO.Count;i++){
            playerObjectDic.Add(playerO.itemO,playerO);
        }
        inv.EquipeObject += UpdateEquipement;//evento EquipeObject en Inventory
    }

    void OnDisable(){
        inv.EquipeObject -= UpdateEquipement;//evento EquipeObject en Inventory
    }

    public void UpdateEquipement(ItemObject itemO){
        if(itemO.equiped){
            playerObjectDic(itemO).objectEquiped.SetActive(true);
            playerObjectDic(itemO).objectUnequiped.SetActive(false);
        } else {
            playerObjectDic(itemO).objectEquiped.SetActive(false);
            playerObjectDic(itemO).objectUnequiped.SetActive(true);
        }
    }*/

}
