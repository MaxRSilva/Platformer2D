    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    public AudioMixer group;
    public string floatParam = "MyExposedParam";


    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ChangeValue(float f)
    {
        group.SetFloat(floatParam, f);
    }



}
