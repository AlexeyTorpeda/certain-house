using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _volumeChangeSpeed = 0.5f;
    [SerializeField] private AudioSource _alarmAudioSource;
    [SerializeField] private bool _isAlarm;

    public static HouseAlarm _houseAlarm;

    private void Start()
    {
        _houseAlarm = this;
        _alarmAudioSource = GetComponent<AudioSource>();
    }   
    
    public void ToggleAlarm(bool isEnable)
    {
        _isAlarm = isEnable;        
    }

    private void FixedUpdate()
    {
        if (_isAlarm)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, _maxVolume, _volumeChangeSpeed * Time.deltaTime);
            _alarmAudioSource.Play();
        }
        else
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, 0f, _volumeChangeSpeed * Time.deltaTime);
        }
    }
}