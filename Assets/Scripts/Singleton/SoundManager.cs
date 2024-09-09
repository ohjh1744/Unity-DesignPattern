using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    //SoundManager gameobject�Ʒ��� bgm, sfx object�� �ڽ����� ��.
    // ������� �Ÿ�������� 2d���������
    [SerializeField] AudioSource bgm;
    //������ ���� �Ҹ��� 2d��������� �Ÿ�������� �׳� �鸮�����ϱ����ؼ�
    [SerializeField] AudioSource sfx;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public void PlayeBGM(AudioClip clip)
    {
        bgm.clip = clip;
        bgm.Play();
    }

    public void StopBGM()
    {
        if(bgm.isPlaying == false)
        {
            return;
        }
        bgm.Stop();
    }

    public void PauseBGM()
    {
        if (bgm.isPlaying == false)
        {
            return;
        }
        bgm.Pause();
    }

    public void SetBGm(float volume, float pitch = 1f)
    {
        bgm.volume = volume;
        bgm.pitch = pitch;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
        sfx.clip = clip;
        sfx.Play();
    }

    public void SetSFX(float volume, float pitch = 1f)
    {
        sfx.volume = volume;
        sfx.pitch = pitch;
    }
}
