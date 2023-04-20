using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entering : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            HouseAlarm._houseAlarm.ToggleAlarm(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            HouseAlarm._houseAlarm.ToggleAlarm(false);
        }
    }
}