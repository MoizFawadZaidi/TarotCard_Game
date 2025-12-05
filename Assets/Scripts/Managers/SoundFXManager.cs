using global::UnityEngine;

public class SoundFXManager : UnityEngine.MonoBehaviour
{
    public static global::SoundFXManager instance;

    [UnityEngine.SerializeField] private UnityEngine.AudioSource soundFXObject;

    private void Awake()
    {
        if (SoundFXManager.instance == null )
        {
            SoundFXManager.instance = this;
        }
    }

    public void PlaySoundFXClip(UnityEngine.AudioClip audioClip, UnityEngine.Transform spawnTransform, float volume)
    {
        // spawn gameObject
        UnityEngine.AudioSource audioSource = UnityEngine.Object.Instantiate(soundFXObject, spawnTransform.position, UnityEngine.Quaternion.identity);

        // assign audioClip
        audioSource.clip = audioClip;

        // assign volume
        audioSource.volume = volume;

        // play sound
        audioSource.Play();

        // get length of SFX clip
        float clipLength = audioSource.clip.length;

        // destroy clip after it has played
        UnityEngine.Object.Destroy(audioSource.gameObject, clipLength);
    }
}
