using UnityEngine;
using UnityEngine.UI;

public class CellItem : MonoBehaviour
{
    public InventorySlot item;

    public void UpdateCanvas()
    {
        if (item != null)
        {

            Image img = this.gameObject.GetComponent<Image>();
            img.enabled = true;
            img.sprite = item.item.spr;

        }
        else
        {
            this.gameObject.GetComponent<RawImage>().enabled = false;
        }
    }
}
