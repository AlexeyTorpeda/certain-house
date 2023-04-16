using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _fadeDuration = 2f;

    private bool _enemyInside;
    private float _targetVolume = 0f;
    private float _currentVolume = 0f;
    private float _fadeStartTime = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _enemyInside = true;
            _targetVolume = _maxVolume;
            _fadeStartTime = Time.time;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _enemyInside = false;
            _targetVolume = 0f;
            _fadeStartTime = Time.time;
        }
    }

    private void Update()
    {
        if (_currentVolume != _targetVolume)
        {
            float fadeProgress = (Time.time - _fadeStartTime) / _fadeDuration;
            _currentVolume = Mathf.Lerp(_currentVolume, _targetVolume, fadeProgress);
            _alarmSound.volume = _currentVolume;
        }
    }
}
