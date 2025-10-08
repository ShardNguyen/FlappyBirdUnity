using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipeData _pipeData;
    [SerializeField] private GameObject _bottom;
    [SerializeField] private GameObject _top;

    private float _maxY = 0f;
    private float _minY;
    private float _leftBorder;
    private bool _scored;

    private void Awake()
    {
        _minY = -Camera.main.orthographicSize * 2;
    }

    private void OnEnable()
    {
        SetPipeHeight();
        SetLeftBorder();
        _scored = false;
    }

    private void Update()
    {
        _bottom.transform.position += Vector3.left * _pipeData.speed * Time.deltaTime;
        _top.transform.position += Vector3.left * _pipeData.speed * Time.deltaTime;

        if (!_scored && _bottom.transform.position.x < 0 && _top.transform.position.x < 0)
        {
            GameManager.Instance.AddScore();
            _scored = true;
        }

        if (_bottom.transform.position.x < _leftBorder && _top.transform.position.x < _leftBorder)
        {
            Destroy(gameObject);
        }
    }

    private void SetPipeHeight()
    {
        float randomHeight = Random.Range(_minY, _maxY - _pipeData.gap);

        _bottom.transform.position = new Vector3(0f, randomHeight, 0f) + transform.position;
        _top.transform.position = new Vector3(0f, randomHeight + Camera.main.orthographicSize * 2 + _pipeData.gap, 0f) + transform.position;
    }

    private void SetLeftBorder()
    {
        Camera mainCam = Camera.main;
        _leftBorder = -mainCam.orthographicSize * mainCam.aspect * 2f;
    }
}
