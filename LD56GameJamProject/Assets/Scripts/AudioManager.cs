using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource; // ���ڲ�����Ч����Դ
    public AudioClip[] soundEffects; // ���ڴ洢�����Ч

    // ������Ч���͵�ö��
    public enum SoundEffect
    {
        Jump,
        Walk,
        Sunburn,
        Water,
        Die,
        Mushroom,

    }

    private void Awake()
    {
        // ����һ������ģʽ��ȷ��ֻ��һ�� AudioManager ʵ��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �����ڳ����л�ʱ������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ���ڲ�����Ч�ķ���
    public void PlaySound(SoundEffect effect)
    {
        int soundIndex = (int)effect;
        if (soundIndex >= 0 && soundIndex < soundEffects.Length)
        {
            audioSource.PlayOneShot(soundEffects[soundIndex]);
        }
        else
        {
            Debug.LogWarning("Sound index out of range!");
        }
    }
}
