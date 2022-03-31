using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioClip _die;
    [SerializeField] private AudioClip _hurt;
    [SerializeField] private AudioClip _heal;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.Dead += OnDead;
        _player.Hurt += OnHurt;
        _player.Healed += OnHealed;
        _player.Recovered += OnHealed;
    }

    private void OnDisable()
    {
        _player.Dead -= OnDead;
        _player.Hurt -= OnHurt;
        _player.Healed -= OnHealed;
        _player.Recovered -= OnHealed;
    }

    private void OnDead()
    {
        _audioSource.PlayOneShot(_die);
    }

    private void OnHurt()
    {
        _audioSource.PlayOneShot(_hurt);
    }

    private void OnHealed()
    {
        _audioSource.PlayOneShot(_heal);
    }
}
