using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepSound : MonoBehaviour
{
    private int sfxToPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void leftStepPlay()
    {
        sfxToPlay = 20;
        AudioManager.instance.SoundEffects(sfxToPlay);
    }

    public void rightStepPlay()
    {
        sfxToPlay = 19;
        AudioManager.instance.SoundEffects(sfxToPlay);
    }
}
