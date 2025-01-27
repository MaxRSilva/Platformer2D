using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour
{
    public List<AudioClip> audioClipList;
    public List<AudioSource> audioSourceList;
    private int _index = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandom()
    {
        if (_index >= audioSourceList.Count) _index = 0;
        
        var audioSource = audioSourceList[_index];

        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
        audioSource.Play();
        
        _index++;
    }


}