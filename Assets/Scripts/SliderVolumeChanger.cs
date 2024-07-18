using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderVolumeChanger : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private string _audioMixerGroupName;
    [SerializeField] private SoundMuter _SoundMuter;

    private float _minVolume = -80;
    private float _maxVolume = 0;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        _SoundMuter.SoundStatusChanged += AttuneVolume;
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(delegate { ChangeVolume(); });
        _SoundMuter.SoundStatusChanged -= AttuneVolume;
    }

    private void ChangeVolume()
    {
        if (_SoundMuter.IsSoundEnabled)
        {
            _audioMixerGroup.audioMixer.SetFloat(_audioMixerGroupName, Mathf.Lerp(_minVolume, _maxVolume, 1 + Mathf.Log10(_volumeSlider.value)));
        }
    }

    private void AttuneVolume()
    {
        if (_SoundMuter.IsSoundEnabled)
        {
            ChangeVolume();
        }
    }
}
