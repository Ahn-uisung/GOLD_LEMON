using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Slider brightnessSlider;

    private void Start()
    {
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    private void SetResolution(int index)
    {
        Resolution[] resolutions = Screen.resolutions;
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);
    }

    private void SetBGMVolume(float value)
    {
        PlayerPrefs.SetFloat("BGMVolume", value);
        AudioListener.volume = value;
    }

    private void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    private void SetBrightness(float value)
    {
        PlayerPrefs.SetFloat("Brightness", value);
        RenderSettings.ambientLight = Color.white * value;
    }
}
