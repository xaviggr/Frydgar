using UnityEngine.UI;

public class DisplayOnText : DisplayData
{
    private Text txt;

    private void Awake()
    {
        txt = this.GetComponent<Text>();
    }

    public override void UpdateValue(float newvalue)
    {
        txt.text = newvalue.ToString();
    }

    public override void UpdateValue(string newvalue)
    {
        txt.text = newvalue;
    }

    public override void UpdateValue(int newvalue)
    {
        txt.text = newvalue.ToString();
    }
}
