using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour
{

    public Transform _player;
    public Camera _camera;
    public float maxSize = 10;
    public float minSize = -10;
    public float speed = 0.5f;
    private float _cameraSize;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.position.x + 6, 0, -10);
        _cameraSize = _player.position.y + 5f;
        if (_cameraSize >= maxSize)
        {
            _cameraSize = maxSize;
        }

        else if(_cameraSize <= minSize)
        {
            _cameraSize = minSize;
        }

        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _cameraSize, Time.deltaTime / speed);
    }
}
