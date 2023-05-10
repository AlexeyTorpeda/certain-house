using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HouseAlarm))]
public class Entering : MonoBehaviour
{
    private HouseAlarm _houseAlarm;

    private void Start()
    {
        _houseAlarm = GetComponent<HouseAlarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _houseAlarm.ToggleAlarm(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _houseAlarm.ToggleAlarm(false);
        }
    }
}