using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        //audio sources
        private AudioSource deathAudioSource;
        private AudioSource backgroundMusicAudioSource;
        public int coinsCounter = 0;
        public int numCoinsToWin = 0;

        public GameObject playerGameObject;
        private PlayerController player;
        public GameObject deathPlayerPrefab;
        public Text coinText;

        public Text numCoinsToWinText;

        void Start()
        {
            //audio source
            deathAudioSource = transform.Find("DeathSound").GetComponent<AudioSource>();
            backgroundMusicAudioSource = transform.Find("BackgroundMusic").GetComponent<AudioSource>();
            backgroundMusicAudioSource.Play();

            numCoinsToWin = GameObject.Find("Coins").transform.childCount;
            numCoinsToWinText.text = "Collect " + numCoinsToWin + " coins to win!";
            player = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            coinText.text = coinsCounter.ToString();
            //player dies
            if(player.deathState == true)
            {
                deathAudioSource.Play();
                playerGameObject.SetActive(false);
                GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                player.deathState = false;
                Invoke("ReloadLevel", 3);
            }
            
            if (coinsCounter >= numCoinsToWin) 
            {
                SceneManager.LoadScene("Scene2");
            }
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene("Scene1");
        }
    }
}
