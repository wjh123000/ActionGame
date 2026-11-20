using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttonSound : MonoBehaviour
{
    public AudioClip buttonClickSound;
    public void PlayButtonClickSound()
    {
        AudioManager.Instance.PlaySound(buttonClickSound, 1f);
    }
}
