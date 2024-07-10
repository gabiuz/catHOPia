using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;
    private AudioManager audioManager;

    public CoinManager coinManager;
    private bool hasPowerUp = false;
    public float powerUpDuration = 5f; // Duration of the power-up effect in seconds

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
                audioManager.PlaySFX(audioManager.jumpSound);
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (!hasPowerUp)
            {
                GameManager.Instance.GameOver();
                audioManager.PlaySFX(audioManager.deathSound);
                audioManager.StopBackground();
            }
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinManager.coinCount++;
            audioManager.PlaySFX(audioManager.CoinCollect);
        }

        if (other.gameObject.CompareTag("Power Up"))
        {
            Destroy(other.gameObject);
            StartCoroutine(PowerUpRoutine());
        }

        if (other.gameObject.CompareTag("Power Up 2"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.SetGameSpeed(10f);
        }


    }

    private IEnumerator PowerUpRoutine()
    {
        hasPowerUp = true;
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerUp = false;
    }
}

