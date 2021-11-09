using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameMechanics
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            StartCoroutine(PlaySoundCoroutine());
        }

        private IEnumerator PlaySoundCoroutine()
        {
            _audioSource.clip = clip;
            _audioSource.Play();

            yield return new WaitForSeconds(_audioSource.clip.length);

            Destroy(gameObject);
        }

    }
}
