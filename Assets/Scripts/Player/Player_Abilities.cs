using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Abilities : MonoBehaviour
{
    [Header("Random Index")]
    [SerializeField] private Text _randomIndex;

    [SerializeField] private float _time;

    private int _index;

    private bool _isActive;

    [Header("Spawner")]
    [SerializeField] private AudioSource _spawnerSource;
    [Space (height: 5f)]

    [SerializeField] private GameObject[] _boxes;
    private Transform _playerTransform;
    private Player _playerGameObject;

    private int _wastedBox = 0;


    private void Start()
    {
        _playerTransform = FindObjectOfType<Player>().transform;
        _playerGameObject = GetComponent<Player>();

        StartCoroutine(RandomIndex());
    }


    private void Update()
    {
        BoxGround_RandomIndex();
    }


    private void BoxGround_RandomIndex()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isActive == true && _playerGameObject.IsDie == false)
        {
            if(_wastedBox < _index)
            {
                _wastedBox++;

                _spawnerSource.Play();

                Instantiate(
                _boxes[Random.Range(0, _boxes.Length)],
                new Vector2(_playerTransform.position.x , -5.5f),
                Quaternion.identity);
            }
            else if(_wastedBox >= _index)
            {
                _wastedBox = 0;

                _isActive = false;
            }
        }
    }


    private IEnumerator RandomIndex()
    {
        while (true)
        {
            yield return new WaitForSeconds(_time);

            _index = Random.Range(1, 7);

            _wastedBox = 0;

            _isActive = true;

            _randomIndex.text = "You have " + _index.ToString() + " dice";
        }
    }
}