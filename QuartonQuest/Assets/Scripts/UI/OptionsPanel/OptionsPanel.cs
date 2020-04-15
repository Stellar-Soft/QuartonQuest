using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundEffectsSlider;
    public GameObject Panel;

    private void Start()
    {
        musicSlider.value = AudioManager.instance.MusicVolume;
        soundEffectsSlider.value = AudioManager.instance.SoundEffectsVolume;
    }

    public bool OptionsPanelShowing
    {
        get
        {
            return Panel.activeInHierarchy;
        }
        set
        {
            Panel.SetActive(value);
        }
    }

    public void OnMusicVolumeChanged(float volume)
    {
        AudioManager.instance.SetMusicVolumeLevel(volume / 1);
    }

    public void OnSoundEffectsVolumeChanged(float volume)
    {
        AudioManager.instance.SetSoundEffectsVolumeLevel(volume / 1);
    }

    public void ToggleOpen()
    {
        OptionsPanelShowing = !OptionsPanelShowing;
    }

    // For opening and closing the panels, we might want to 
    // pause game time as well. 
    public void OpenPanel()
    {
        Debug.Log("Opening options panel");
        OptionsPanelShowing = true;
        // Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        Debug.Log("Closing options panel");
        OptionsPanelShowing = false;
        // Time.timeScale = 1f;
    }

    public void ForfeitButtonClicked()
    {
        Debug.Log("Forfeiting match...");
        GameCoreController.Instance.Forfeit();
        ClosePanel();
        GUIController.Instance.GameOver();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
