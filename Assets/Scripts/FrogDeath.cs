using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogDeath : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource DeathSoundEffect;
    [SerializeField] private AudioSource RespawnSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        DeathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

    }

    private void RestartLevel()
    {
        RespawnSoundEffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}