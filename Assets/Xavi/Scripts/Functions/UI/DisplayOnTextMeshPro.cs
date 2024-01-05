using TMPro;

public class DisplayOnTextMeshPro : DisplayData
{
    private TMP_Text txt;

    private void Start()
    {
        txt = this.GetComponent<TMP_Text>();
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
