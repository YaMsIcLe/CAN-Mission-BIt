using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidRiser : MonoBehaviour
{
    private bool highLevel = false; // State of acid, true if high, false if low
    public float levelDelta = 5; // How much the acid will rise/lower by

    public void ChangeLevel()
    {
        Vector3 position = transform.position;

        if (highLevel)
        {
            highLevel = false;
            position.y += levelDelta;
            transform.SetPositionAndRotation(position, transform.rotation);
        }
        else
        {
            highLevel = true;
            position.y -= levelDelta;
            transform.SetPositionAndRotation(position, transform.rotation);
        }
    }

    public void OnDeath()
    {
        Debug.Log("lolhi");
    }
}