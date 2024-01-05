using UnityEngine.UI;

public class DisplayOnSlider : DisplayData
{
    private Slider slider;

    private void Start()
    {
        slider = this.GetComponent<Slider>();
    }

    public override void UpdateValue(float newvalue)
    {
        slider.value = newvalue;
    }

    public override void UpdateValue(string newvalue)
    {

    }

    public override void UpdateValue(int newvalue)
    {
        slider.value = newvalue;
    }
}
