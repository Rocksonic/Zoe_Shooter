using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> _enemys;
    private GameObject[] _enemysArray;
    public GameObject _Boss;
    public GameObject RoundManager;
    private GameObject _ActualBoss;

    
    public bool _stopSpawning = true;
    public int _maximumAmountOfSpawns;
    private int _amountSpawned = 0;
    public float _spawnTime;
    public float _spawnDelay;
    public bool _isBossActive = false;

    public float _difficultyMultiplierHealth;
    public float _difficultyMultiplierDamage;

    public Vector3[] _directions = 
    {
        Vector3.forward,
        Vector3.right,
        Vector3.left,
        Vector3.back
    };

    public Vector3[] _roomSize = 
    {
        Vector3.zero,
        Vector3.zero,
        Vector3.zero,
        Vector3.zero
    };

    void Awake()
    {
        RaycastHit hit;
        for (int i = 0; i < _directions.Length; i++)
        {
            Physics.Raycast(transform.position, _directions[i], out hit);
            _roomSize[i] = hit.point;
        }

        _enemysArray = _enemys.ToArray();
    }

    void Start()
    {
        if (_difficultyMultiplierHealth <= 0)
        {
            _difficultyMultiplierHealth = 0.5f;
        }

        if (_difficultyMultiplierDamage <= 0)
        {
            _difficultyMultiplierDamage = 0.5f;
        }
    }

    void Update() 
    {
        
        if ( _isBossActive && _ActualBoss.GetComponent<ShooterBoss>().isDead)
        {
            _isBossActive = false;
            RoundManager.GetComponent<RoundManager>().lockCount = true;
            RoundManager.GetComponent<RoundManager>().lockRound = true;
            RoundManager.GetComponent<RoundManager>().NextRound();
        }
    }



    public void StartSpawn()
    {
        InvokeRepeating("SpawnEnemy", _spawnTime, _spawnDelay);
    }

    void SpawnEnemy()
    {
        
        Vector3 spawnPosition = new Vector3(Random.Range(_roomSize[2].x, _roomSize[1].x), transform.position.y,Random.Range(_roomSize[3].z, _roomSize[0].z));
        
        if (!Physics.CheckSphere(spawnPosition, 2f) && Physics.Raycast(spawnPosition, Vector3.down, 10f))
        {
            GameObject SE =  Instantiate(_enemysArray[Random.Range(0, _enemysArray.Length)],spawnPosition, transform.rotation);
            SE.gameObject.GetComponent<ShooterEnemy>().health = SE.gameObject.GetComponent<ShooterEnemy>().health * _difficultyMultiplierHealth;
            SE.gameObject.GetComponent<ShooterEnemy>().damage = SE.gameObject.GetComponent<ShooterEnemy>().damage * _difficultyMultiplierDamage;
            _amountSpawned++;
        }

        if (_amountSpawned >= _maximumAmountOfSpawns)
        {
            _stopSpawning = true;
        }

        if (_stopSpawning)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    public void SpawnBoss()
    {
        if (!(_isBossActive))
        {

            Vector3 spawnPosition = new Vector3(Random.Range(_roomSize[2].x, _roomSize[1].x), transform.position.y,Random.Range(_roomSize[3].z, _roomSize[0].z));
        
            if (!Physics.CheckSphere(spawnPosition, 2f) && Physics.Raycast(spawnPosition, Vector3.down, 10f))
            {
                _ActualBoss = Instantiate(_Boss, spawnPosition, transform.rotation);
                _ActualBoss.GetComponent<ShooterBoss>().amountNextRound = _maximumAmountOfSpawns;
                _isBossActive = true;
            }
            
            else
            {
                SpawnBoss();
            }
        }
    }

    public void resetAmountSpawned()
    {
        _amountSpawned = 0;
        _stopSpawning = false;
    }
}
