using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _volumeChangeSpeed = 0.5f;
    [SerializeField] private AudioSource _alarmAudioSource;
    [SerializeField] private bool _isAlarm;

    private Coroutine _changeVolumeCoroutine;
    private float _minVolume = 0f;

    private void Start()
    {
        _alarmAudioSource = GetComponent<AudioSource>();
    }

    public void ToggleAlarm(bool isEnable)
    {
        if (_changeVolumeCoroutine != null) 
            StopCoroutine(_changeVolumeCoroutine);

        if (_alarmAudioSource == null) 
            return;

        _isAlarm = isEnable;

        if (_isAlarm)
        {
            if (_changeVolumeCoroutine != null)
            {
                StopCoroutine(_changeVolumeCoroutine);
            }

            _changeVolumeCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
        }
        else
        {
            if (_changeVolumeCoroutine != null)
            {
                StopCoroutine(_changeVolumeCoroutine);
            }

            _changeVolumeCoroutine = StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        if (_alarmAudioSource == null) 
            yield break;

        while (_alarmAudioSource.volume != targetVolume)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        if (targetVolume == _minVolume)
        {
            _alarmAudioSource.Stop();
        }

        _changeVolumeCoroutine = null;
    }
}