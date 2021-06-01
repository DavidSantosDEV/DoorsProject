using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GraphicSettingsSet : ScriptableObject
{
    const string VSYNC_KEY = "VSync";
    const string SCREENWIDTH_KEY = "ScreenResolution_width";
    const string SCREENHEIGHT_KEY = "ScreenResolution_height";
    const string REFRESHRATE_KEY = "ScreenRefreshRate";
    const string FULLSCREENMODE_KEY = "Fullscreen";

    Resolution[] resolutions;
    int IndexResolution;

    void Awake()
    {
        RestorePreviousSettings();

        resolutions = Screen.resolutions;
        IndexResolution = Screen.resolutions.ToList().IndexOf(Screen.currentResolution);
    }

    public List<string> ReturnResolutionsSTR()
    {
        List<string> ResString = new List<string>();
        Screen.resolutions.ToList().ForEach(res => ResString.Add(res.ToString()));

        return ResString;
    }

    public int ReturnCurrentResIndex()
    {
        return IndexResolution;
    }

    public void ChangeResolution(int index,bool fullscreen)
    {
        IndexResolution = index;
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, fullscreen, resolutions[index].refreshRate);
        SaveSettings();
    }

    private void SaveSettings()
    {
        
    }

    private void RestorePreviousSettings()
    {
        Resolution res= new Resolution();
        res.width = PlayerPrefs.GetInt(SCREENWIDTH_KEY);
        res.height = PlayerPrefs.GetInt(SCREENHEIGHT_KEY);
        res.refreshRate = PlayerPrefs.GetInt(REFRESHRATE_KEY);

    }

}
