using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    [Range(0,10)]
    public float _speed, _moveLimit;

    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, -_moveLimit + Mathf.PingPong(Time.time * _speed, _moveLimit * 2));
    }
}