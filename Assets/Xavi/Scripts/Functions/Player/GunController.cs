using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Gun = null;
    private GameObject Shield = null;

    public GameObject Gun_Prefab;
    public GameObject Shield_Prefab;

    public GameObject Gun_Holster_Armed;
    public GameObject Gun_Holster_Unarmed;

    public GameObject Shield_Holster_Armed;
    public GameObject Shield_Holster_Unarmed;

    public bool isarmed = false;

    private static GunController _instance;
    public static GunController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GunController>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        UpdateGameObjectOnPlayer(isarmed);
    }

    public void UpdateGameObjectOnPlayer(bool isarmed)
    {
        Destroy(Gun);
        Destroy(Shield);

        Transform gun_pos = null;
        Transform shield_pos = null;

        if (isarmed)
        {
            gun_pos = Gun_Holster_Armed.transform;
            shield_pos = Shield_Holster_Armed.transform;
        }
        else
        {
            gun_pos = Gun_Holster_Unarmed.transform;
            shield_pos = Shield_Holster_Unarmed.transform;
        }

        Gun = Instantiate(Gun_Prefab, gun_pos);
        Gun.transform.localScale = Vector3.one;
        Gun.transform.localRotation = Quaternion.identity;

        Shield = Instantiate(Shield_Prefab, shield_pos);
        Shield.transform.localScale = Vector3.one;
    }
}
