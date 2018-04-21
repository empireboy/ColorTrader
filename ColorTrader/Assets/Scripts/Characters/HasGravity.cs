using UnityEngine;

public class HasGravity : MonoBehaviour {

	[SerializeField] private float _gravity;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        movement.y = _gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
