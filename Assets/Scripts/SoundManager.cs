using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SM = null;
    private void Awake()
    {
        if (SM == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������ 
        {
            SM = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ���� 
        }
        else
        {
            if (SM != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ� 
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ���� 
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