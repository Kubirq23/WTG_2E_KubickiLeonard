
using UnityEngine;

public class SoundMenager : MonoBehaviour
{
    public static SoundMenager instance;
    [SerializeField]
    private AudioSource soundsorce;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    public void SoundClip(AudioClip audioclip,Transform tr,float vol){
        if(Com.mc == false){
            return;
        }
        AudioSource source = Instantiate(soundsorce,tr.position,tr.rotation);
        source.clip = audioclip;
        source.volume = vol;
        source.Play();
        float len = source.clip.length;
        Destroy(source.gameObject,len);
    }

}
