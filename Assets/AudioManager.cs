using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip fight;
    public AudioClip dust;
    public AudioClip wingame;
    public AudioClip losegame;
    public AudioClip footstep;
    public AudioClip mummywalk;


    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
