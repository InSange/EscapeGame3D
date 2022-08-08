using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SM = null;
    private void Awake()
    {
        if (SM == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때 
        {
            SM = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지 
        }
        else
        {
            if (SM != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미 
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제 
        }

        AudioDic = new Dictionary<string, AudioClip>();
        foreach( AudioClip a in Audioclip)
        {
            AudioDic.Add(a.name, a);
        }
    }
    public AudioSource Audio;
    public AudioClip[] Audioclip;

    Dictionary<string, AudioClip> AudioDic;

    public void PlaySound(string audio_name)
    {
        Audio.PlayOneShot(AudioDic[audio_name], 1f);
    }
}