using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class RespawnEnemy : MonoBehaviour
{
    public List<Enemy> EnemyList = new List<Enemy>();

    public List<GameObject> SpawnPos = new List<GameObject>();

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Respawn", 0, 5f);

    }

    public void Respawn()
    {
        if(GameManager.Instance.enemyCount <= 0)
        {
            return;
        }

        for(int i = 0; i < SpawnPos.Count; i++)
        {
            if(EnemyList[i].gameObject.activeInHierarchy == false)
            {
                EnemyList[i].transform.position = SpawnPos[Random.Range(Random.Range(0, 10), i)].transform.position;

                StartCoroutine(Spawn(EnemyList[i]));
            }
        }
    }

    public IEnumerator Spawn(Enemy _enemy)
    {
        yield return new WaitForSeconds(Random.Range(5, 10));

        _enemy.gameObject.SetActive(true);

        _enemy.isDead = false;

        _enemy.enabled = true;

        _enemy.Score = 0;

        _enemy.ScoreText.text = _enemy.Score.ToString();

        _enemy.GetComponent<NavMeshAgent>().enabled = true;

        _enemy.GetComponent<Collider>().enabled = true;

        _enemy.GetComponent<Rigidbody>().detectCollisions = true;

        if (!GameManager.Instance._listCharacter.Contains(_enemy.GetComponent<CharacterManager>()))
        {
            GameManager.Instance._listCharacter.Add(_enemy.GetComponent<CharacterManager>());
        }
    }
}
