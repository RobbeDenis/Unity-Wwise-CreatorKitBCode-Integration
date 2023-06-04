using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRTPC : MonoBehaviour
{
    public void SetRTPC(float rtpc)
    {
        AkSoundEngine.SetRTPCValue("Health", rtpc, gameObject);
    }
}
