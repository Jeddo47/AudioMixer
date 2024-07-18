using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMuter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
        
    private float _minVolume = -80;
    private string _masterVolumeName = "MasterVolume";

    public event Action SoundStatusChanged;

    public bool IsSoundEnabled { get; private set; }

    private void Awake()
    {
        IsSoundEnabled = true;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleSound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleSound);
    }

    private void ToggleSound()
    {
        IsSoundEnabled = !IsSoundEnabled;

        if (IsSoundEnabled)
        {            
            SoundStatusChanged?.Invoke();
        }
        else 
        {            
            _audioMixerGroup.audioMixer.SetFloat(_masterVolumeName, _minVolume);

            SoundStatusChanged?.Invoke();
        }
    }
}
