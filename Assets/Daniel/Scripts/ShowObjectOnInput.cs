using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
#endif

public class ShowObjectOnInput : MonoBehaviour
{
    public GameObject minimap;
    public GameObject map;

    void Awake()
    {
        CheckMap();
    }

    public void CheckMap()
    {
        bool state = StarterAssets.StarterAssetsInputs.Instance.useMap;
        Cursor.visible = state;
        StarterAssets.ThirdPersonController.Instance.LockCameraPosition = state;
        StarterAssets.StarterAssetsInputs.Instance.cursorInputForLook = !state;
        StarterAssets.StarterAssetsInputs.Instance.cursorLocked = !state;
        minimap.SetActive(!state);
        map.SetActive(state);
    }

    void OnEnable()
    {
        StarterAssets.StarterAssetsInputs.Instance.MapInteract += CheckMap;
    }
}
