using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerAudio : MonoBehaviour
{
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
        Player.Dead += OnPlayerDied;
        Player.Hurt += OnPlayerHurt;
        Player.Healed += OnPlayerHealed;
        Player.Recovered += OnPlayerHealed;
    }

    private void OnDisable()
    {
        Player.Dead -= OnPlayerDied;
        Player.Hurt -= OnPlayerHurt;
        Player.Healed -= OnPlayerHealed;
        Player.Recovered -= OnPlayerHealed;
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
