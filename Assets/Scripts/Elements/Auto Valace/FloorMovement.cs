using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    [Range(-10,10)]
    public float _speed, _moveLimit;

    private void Update()
    {
        transform.Rotate(0, 0, _speed * Time.deltaTime * 10);
        /*
        float speed = Time.time * _speed;
        float move = -_moveLimit + Mathf.PingPong(speed, _moveLimit * 2);
        transform.localEulerAngles = new Vector3(0, 0, move);
        */
    }
}