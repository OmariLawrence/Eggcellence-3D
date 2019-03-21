using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class optionsmenu : MonoBehaviour
{

    public AudioMixer am;
    public Dropdown resDropdown;
    Resolution[] resolutions;


    private void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currRes = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currRes = i;
            }

            options.Add(option);
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currRes;
        resDropdown.RefreshShownValue();
    }

    public void setResolution(int resIdx)
    {
        Screen.SetResolution(resolutions[resIdx].width, resolutions[resIdx].height, Screen.fullScreen);
    }

    public void setVolume(float volume)
    {
        am.SetFloat("Volume", volume);
    }

    public void setQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void setFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
}
