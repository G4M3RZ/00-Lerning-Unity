using UnityEngine;

public class SlideMovement : MonoBehaviour
{
    [Range(0,5)]
    public float _speed;

    private void Update()
    {
        PlayerMovement(transform.position);
    }
    void PlayerMovement(Vector3 playerPos)
    {
        float h = Input.GetAxis("Horizontal");
        transform.localPosition = new Vector3(playerPos.x + h * Time.deltaTime * _speed, playerPos.y, playerPos.z);
    }
}