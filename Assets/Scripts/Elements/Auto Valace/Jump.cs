using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(0, 10)]
    public float _speed, _jumpForce;

    private CharacterController _ch;
    private Vector3 playerVelocity;
    private float _gravity;

    private AutoValace _autoValance;

    private void Awake()
    {
        _gravity = Physics.gravity.y;
        _ch = GetComponent<CharacterController>();

        _autoValance = GetComponent<AutoValace>();
    }
    void Update()
    {
        bool grounded = _ch.isGrounded;

        if (Input.GetButtonDown("Jump") && grounded)
            playerVelocity.y += Mathf.Sqrt(_jumpForce * -3.0f * _gravity);

        if (!grounded)
            playerVelocity += transform.up * _gravity * Time.deltaTime;

        playerVelocity += transform.forward * _speed * Time.deltaTime;
        _ch.Move(playerVelocity);

        _autoValance.Valance(transform.position);
    }
}