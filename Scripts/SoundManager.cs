using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource source, newSource, pitchSource;
    public AudioClip openList, doorBell, clockTicking, AnomalousHedges, RingHighPitch;
    bool playingMusic, playingOpenList, playingDoorbBell;
    AudioSource _currentMainAudio;
    bool changingMusic;
    //AudioSource newMainAudio;
    public float fadeInSec = 4f;
    float volume;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        source.PlayOneShot(AnomalousHedges);
        playingMusic = true;
        _currentMainAudio = source;
    }
    public void PlayOpenList()
    {
        source.PlayOneShot(openList);
        playingOpenList = true;
    }
    public void PlayDoorBell()
    {
        ;
        source.PlayOneShot(doorBell);
        playingDoorbBell = true;
    }
    public void changeMusicToTick()
    {
        Debug.Log("changeMusicToTick");
        changingMusic = true;
        StartCoroutine(TurnOnWhistle());
    }

    IEnumerator TurnOnWhistle()
    {
        yield return new WaitForSeconds(3f);
        pitchSource.volume = 1;
        //source.PlayOneShot(RingHighPitch);
    }
    private void Update()
    {
        if (changingMusic)
        {
            Debug.Log("change");
            volume = 1f / fadeInSec * Time.deltaTime;

            if (_currentMainAudio.volume > 0)
                _currentMainAudio.volume -= volume / 10;
            newSource.volume += volume;

            if (newSource.volume >= 1)
            {
                changingMusic = false;
            }
        }
    }
}