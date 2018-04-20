using UnityEngine;

public class BasicCameraRotation : MonoBehaviour {

    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    [SerializeField] private RotationAxis _axis = RotationAxis.MouseX;

    private float _rotationMin = -45f;
    private float _rotationMax = 45f;

    [SerializeField] private float _sensivity = 10f;

    private float _rotationX = 0;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        switch (_axis)
        {
            case RotationAxis.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * _sensivity, 0);
                break;
            case RotationAxis.MouseY:
                _rotationX -= Input.GetAxis("Mouse Y") * _sensivity;
                _rotationX = Mathf.Clamp(_rotationX, _rotationMin, _rotationMax);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                break;
        }
    }
}
