using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public float rotateSpeed;
    public AudioClip coinCollect;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LevelManager.Instance.CurrentNumOfCrystals--;
            LevelManager.Instance.FinishScreen(10);
            AudioPlayer.Instance.PlaySound(coinCollect, 1f);
            Destroy(gameObject);           
        }
    }
}
