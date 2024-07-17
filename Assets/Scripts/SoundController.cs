using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    private bool _isEnabled = true;
    private float _minVolume = -80;
    private float _maxVolume = 0;
    private string _masterVolumeName = "MasterVolume";
    private string _musicVolumeName = "MusicVolume";
    private string _soundEffectsVolumeName = "SoundEffectsVolume";

    public void PlayButtonSound(AudioSource buttonSound) 
    {
        buttonSound.Play();            
    }

    public void ToggleSound() 
    {
        if (_isEnabled)
        {
            _isEnabled = false;
        }
        else 
        {
            _isEnabled = true;        
        }

        if (_isEnabled)
        {
            _audioMixer.audioMixer.SetFloat("MasterVolume", _maxVolume);
        }
        else 
        {
            _audioMixer.audioMixer.SetFloat("MasterVolume", _minVolume);        
        }
    }

    public void ChangeMasterVolume(Slider masterVolumeSlider) 
    {
        ChangeVolume(_masterVolumeName, masterVolumeSlider);    
    }

    public void ChangeMusicVolume(Slider musicVolumeSlider) 
    {
        ChangeVolume(_musicVolumeName, musicVolumeSlider);            
    }

    public void ChangeSoundEffectsVolume(Slider soundEffectsVolume) 
    {
        ChangeVolume(_soundEffectsVolumeName, soundEffectsVolume);    
    }

    private void ChangeVolume(string audioMixerName, Slider slider)
    {
        _audioMixer.audioMixer.SetFloat(audioMixerName, Mathf.Lerp(_minVolume, _maxVolume, 1 + Mathf.Log10(slider.value)));
    }    
}
