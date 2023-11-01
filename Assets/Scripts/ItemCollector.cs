using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int Pineapple;
    [SerializeField] private Text pineappleText;

    [SerializeField] private AudioSource ItemCollectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            ItemCollectSoundEffect.Play();
            Destroy(collision.gameObject);
            Pineapple++;
            pineappleText.text = "Pineapples: " + Pineapple;
            
        }
    }
}
