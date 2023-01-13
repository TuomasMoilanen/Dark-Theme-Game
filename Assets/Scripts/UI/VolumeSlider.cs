using TMPro;
using UnityEngine;
using UnityEngine.Audio;

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
    [Tooltip("Volume sliders value text.")]
    private TextMeshProUGUI valueText;

    #endregion

    #region Volume Code
    public void SetMasterLevel(float Value)
    {
        valueText.SetText($"{Value.ToString("N1")}");

        mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
    }
    #endregion
}