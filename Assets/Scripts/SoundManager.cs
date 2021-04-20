using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    private AudioSource src;
    private AudioSource _source { get { if (src is null) src = GetComponent<AudioSource>(); return src; } }

    [SerializeField] private AudioClip[] clipDataBase;

    public void PlayOneShot(SoundEffect soundEffect) {
        _source.PlayOneShot(clipDataBase[(int)soundEffect]);
    }
}

public enum SoundEffect { CLICK, WIN_SOUND, WRONG }