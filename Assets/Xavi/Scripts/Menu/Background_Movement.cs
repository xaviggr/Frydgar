using UnityEngine;

public class Background_Movement : MonoBehaviour
{
    public float multiplier = 20;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        this.GetComponent<RectTransform>().position = new Vector2(
            (StarterAssets.StarterAssetsInputs.Instance.look.x / Screen.width) * multiplier + (Screen.width / 2),
            (StarterAssets.StarterAssetsInputs.Instance.look.y / Screen.height) * multiplier + (Screen.height / 2));
    }
}
