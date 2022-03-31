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
        _player.Dead += OnPlayerDied;
        _player.Hurt += OnPlayerHurt;
        _player.Healed += OnPlayerHealed;
        _player.Recovered += OnPlayerHealed;
    }

    private void OnDisable()
    {
        _player.Dead -= OnPlayerDied;
        _player.Hurt -= OnPlayerHurt;
        _player.Healed -= OnPlayerHealed;
        _player.Recovered -= OnPlayerHealed;
    }

    private void OnPlayerDied()
    {
        _audioSource.PlayOneShot(_die);
    }

    private void OnPlayerHurt()
    {
        _audioSource.PlayOneShot(_hurt);
    }

    private void OnPlayerHealed()
    {
        _audioSource.PlayOneShot(_heal);
    }
}
