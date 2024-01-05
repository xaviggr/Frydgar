using UnityEngine;
using UnityEngine.UI;

public class DisplayOnImage : DisplayData
{
    private Image img;

    [SerializeField]
    private Sprite[] images;

    private void Start()
    {
        img = this.GetComponent<Image>();
    }

    public override void UpdateValue(float newvalue)
    {
        img.sprite = images[(int)newvalue];
    }

    public override void UpdateValue(string newvalue)
    {

    }

    public override void UpdateValue(int newvalue)
    {
        img.sprite = images[newvalue];
    }
}
