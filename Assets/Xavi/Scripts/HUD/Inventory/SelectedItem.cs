using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItem : MonoBehaviour
{
    public List<GameObject> Cells = new List<GameObject>();
    public GameObject item_data;
    InventoryObject inv;

    private void Awake()
    {
        inv = InventoryController.Instance.player_inventory;
        foreach (Transform item in gameObject.transform)
        {
            Cells.Add(item.gameObject);
        }
    }

    private void OnEnable()
    {
        UpdateCanvasInventory();
    }

    public void OnPointerOn(GameObject model)
    {
        UpdateItemInfoCanvas(model);
    }

    public void OnPointerOff()
    {
        item_data.SetActive(false);
    }

    public void OnPointerDown(GameObject model)
    {
        if (model.GetComponent<CellItem>().item.item.type == ItemType.Consumable)
        {
            model.GetComponent<CellItem>().item.item.Use();
            bool eliminado = inv.RemoveItem(model.GetComponent<CellItem>().item.item, 1);

            if (eliminado)
            {
                UpdateItemInfoCanvas(model);
            }

            UpdateCanvasInventory();
        }
    }

    private void UpdateItemInfoCanvas(GameObject model)
    {
        item_data.SetActive(true);
        item_data.transform.GetChild(0).GetComponent<Image>().sprite = model.GetComponent<CellItem>().item.item.spr;
        item_data.transform.GetChild(1).GetComponent<Text>().text = model.GetComponent<CellItem>().item.item.name;
        item_data.transform.GetChild(2).GetComponent<Text>().text = model.GetComponent<CellItem>().item.item.description;
        item_data.transform.GetChild(3).GetComponent<Text>().text = "x" + model.GetComponent<CellItem>().item.amount.ToString();
    }

    private void UpdateCanvasInventory()
    {
        for (int i = 0; i < Cells.Count; i++)
        {
            Cells[i].SetActive(false);
        }

        for (int i = 0; i < inv.Container.Count; i++)
        {
            if (inv.Container[i].item != null)
            {
                Cells[i].SetActive(true);
                Cells[i].GetComponent<CellItem>().item = inv.Container[i];
                Cells[i].GetComponent<CellItem>().UpdateCanvas();
            }
        }
    }
}
