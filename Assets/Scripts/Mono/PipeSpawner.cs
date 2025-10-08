using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] public GameObject pipePrefab;
    [SerializeField] public float spawnRate = 1f;

    private float _spawnX;

    private void OnEnable()
    {
        SetPosition();
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(pipePrefab, transform.position, Quaternion.identity);
    }

    private void SetPosition()
    {
        Camera mainCam = Camera.main;
        _spawnX = mainCam.orthographicSize * mainCam.aspect * 2f;
        transform.position = new Vector3(_spawnX, 0, 0);
    }
}
