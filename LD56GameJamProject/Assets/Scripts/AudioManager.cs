using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource; // 用于播放音效的音源
    public AudioClip[] soundEffects; // 用于存储多个音效

    // 定义音效类型的枚举
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
        // 创建一个单例模式，确保只有一个 AudioManager 实例
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 保持在场景切换时不销毁
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 用于播放音效的方法
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
