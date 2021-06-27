using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private float _horizontal = 0f;
    [Space(height: 5f)]

    [Header("Audio")]
    [SerializeField] private AudioSource _runSource;
    [SerializeField] private AudioSource _dieSource;
    [Space(height: 5f)]

    [Header("End Game")]
    [SerializeField] private GameObject _fadeWindow;
    [Space(height: 5f)]

    [Header("Score")]
    [SerializeField] private Text[] _scoreText;
    [SerializeField] private Text[] _recordText;

    private string _scorePP = "ScorePP";
    private string _bestScorePP = "BestScorePP";

    private int _score;
    private int _bestScore;

    private bool _isMovement;
    public bool IsDie;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private const float _constJumpForce = 100;
    private const float _constSpeed = 100;


    private void Start()
    {
        Time.timeScale = 1;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _bestScore = PlayerPrefs.GetInt(_bestScorePP);
    }


    private void Update()
    {
        if(IsDie == false)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _runSource.Play();
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _animator.SetBool("Run", true);

                _isMovement = true;
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _runSource.Pause();

                _animator.SetBool("Run", false);

                _isMovement = false;
            }

            Scores();
        }

        if(IsDie == true)
        {
            _runSource.Stop();

            _fadeWindow.SetActive(true);

            Player_Die();
        }

        string gameScene = "GameScene";

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(gameScene);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsDie = true;

            _dieSource.Play();
        }
    }


    private void FixedUpdate()
    {
        if(_isMovement == true)
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

            _rigidbody2D.velocity = new Vector2(-_speed * _constSpeed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
        }
        else if(_isMovement == false)
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
    }


    private void Scores()
    {
        _score++;
        PlayerPrefs.SetInt(_scorePP, _score);

        foreach (Text scoreText in _scoreText)
        {
            scoreText.text = _score.ToString();
        }

        if (_score >= _bestScore)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt(_bestScorePP, _score);
        }

        foreach (Text recordText in _recordText)
        {
            recordText.text = _bestScore.ToString();
        }
    }


    private void Player_Die()
    {
        _speed = 0;

        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;

        _animator.SetTrigger("Die");
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Mash mash))
        {
            IsDie = true;

            _dieSource.Play();
        }

        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            IsDie = true;

            _dieSource.Play();
        }
    }
}