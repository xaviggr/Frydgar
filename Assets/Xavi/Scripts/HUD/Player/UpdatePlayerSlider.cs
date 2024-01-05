using UnityEngine;

public class UpdatePlayerSlider : MonoBehaviour
{
    private void UpdateValue(float value)
    {
        GetComponent<DisplayData>().UpdateValue(value);
    }

    private void OnEnable()
    {
        StarterAssets.UpdatePlayerCanvas.PlayerUpdateHealth += UpdateValue;
    }

    private void OnDisable()
    {
        StarterAssets.UpdatePlayerCanvas.PlayerUpdateHealth -= UpdateValue;
    }
}
