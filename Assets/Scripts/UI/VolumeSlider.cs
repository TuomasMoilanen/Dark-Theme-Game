using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    #region Variables
    [SerializeField]
    [Tooltip("Defines the audio mixer.")]
    private AudioMixer mixer;   // Defines Audio Mixer

    [SerializeField]
    [Tooltip("Define the audio source to use this mixer for.")]
    private AudioSource audioSource;

    [SerializeField]
    [Tooltip("Volume sliders.")]
    private Slider volumeSlider;

    [SerializeField]
    [Tooltip("Volume sliders value text.")]
    private TextMeshProUGUI valueText;

    #endregion

    private void Start()
    {
        LoadValues();
    }

    public void FixedUpdate()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    #region Volume Code
    public void SetMasterLevel(float Value)
    {
        valueText.SetText($"{Value.ToString("N1")}");  // Takes the slider value and shows it as number 

        mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);  // Makes logrythmic volume slider
    }
    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
    #endregion
}