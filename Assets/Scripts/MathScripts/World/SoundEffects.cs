using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour
{

    public static SoundEffects Instance;
    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;
    public AudioClip healthSound;

    void Awake()
    {
        
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of soundEffects!");
        }
        Instance = this;
        
    }
    // following methods each play a sound when triggered from other scripts
    public void MakeExplosionSound()
    {
        try
        {
            MakeSound(explosionSound);
        }
        catch { }
    }
    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }
    public void MakeEnemyShotSound()
    {
        try
        {
            MakeSound(enemyShotSound);
        }catch (MissingReferenceException) { }
        
    }
        
    public void MakeHealthSound()
    {
        MakeSound(healthSound);
    }
    // Plays the given sound
    private void MakeSound(AudioClip originalClip)
    {
        
            GetComponent<AudioSource>().volume = 1;
        
        AudioSource.PlayClipAtPoint(originalClip,
        transform.position);
    }
    
}