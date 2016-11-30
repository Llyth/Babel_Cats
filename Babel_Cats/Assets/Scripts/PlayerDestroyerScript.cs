using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerDestroyerScript : MonoBehaviour
{
    private GameObject[] _playerGame;
    private int _nbNotPlayerDead;

    // Trigger that destroys players on collision

    void Start()
    {
        _playerGame = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_playerGame == null)
            {
                _playerGame = GameObject.FindGameObjectsWithTag("Player");
                _nbNotPlayerDead = _playerGame.Length;
                _nbNotPlayerDead /= 3; // Les childs *3 le nbr de "Player" et NTM ON EST FATIGUE
                Debug.Log(_nbNotPlayerDead);
            }
            else
            {
                other.transform.gameObject.SetActive(false);
                --_nbNotPlayerDead;
                if (_nbNotPlayerDead <= 1)
                {
                    foreach (GameObject player in _playerGame)
                        if (player.activeSelf == true)
                            if (player.transform.parent == null)
                                GameObject.Find("GameManager").GetComponent<GameSceneManager>()._winnerName = player.transform.GetComponent<PlayerName>().text + " wins";
                            else
                                GameObject.Find("GameManager").GetComponent<GameSceneManager>()._winnerName = player.transform.parent.GetComponent<PlayerName>().text + " wins";
                    foreach (GameObject player in _playerGame)
                        player.SetActive(true);
                    SceneManager.LoadScene("GameOverScene");
                }
            }

            //    other.gameObject.GetComponent<HitByPlayer>()._isDead = true;
            //_playerGame = GameObject.FindGameObjectsWithTag("Player");
            //_nbNotPlayerDead = nbNotDeadPlayer();
        }
    }

    public int nbNotDeadPlayer()
    {
        int i = 0;

        foreach (GameObject playerGameObject in _playerGame)
        {
            if (!playerGameObject.GetComponent<HitByPlayer>()._isDead)
                i++;
        }
        return (i);
    }
}
