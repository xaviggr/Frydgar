using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public Slider slider_master_vol;
    public Slider slider_effect_vol;
    public Slider slider_ambient_vol;

    public AudioMixer am;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Master_Vol"))
        {
            slider_master_vol.value = PlayerPrefs.GetFloat("Master_Vol");
            
        } else
        {
            PlayerPrefs.SetFloat("Master_Vol", slider_master_vol.maxValue);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("Ambient_Vol"))
        {
            slider_master_vol.value = PlayerPrefs.GetFloat("Ambient_Vol");
        }
        else
        {
            PlayerPrefs.SetFloat("Ambient_Vol", slider_master_vol.maxValue);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("Effect_Vol"))
        {
            slider_master_vol.value = PlayerPrefs.GetFloat("Effect_Vol");

        }
        else
        {
            PlayerPrefs.SetFloat("Effect_Vol", slider_master_vol.maxValue);
            PlayerPrefs.Save();
        }

        saveOptions();
    }

    public void saveOptions()
    {
        PlayerPrefs.SetFloat("Master_Vol", slider_master_vol.value);
        PlayerPrefs.SetFloat("Ambient_Vol", slider_master_vol.value);
        PlayerPrefs.SetFloat("Effect_Vol", slider_master_vol.value);
        am.SetFloat("MasterVolume", Mathf.Log10(slider_master_vol.value) * 20);
        am.SetFloat("EffectsVolume", Mathf.Log10(slider_effect_vol.value) * 20);
        am.SetFloat("AmbientVolume", Mathf.Log10(slider_ambient_vol.value) * 20);

        PlayerPrefs.Save();
    }
}
