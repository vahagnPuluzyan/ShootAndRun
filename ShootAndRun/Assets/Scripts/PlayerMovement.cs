using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement _instance;

    [SerializeField] float _speed;
    [SerializeField] float _turnSpeed;
    [SerializeField] float _maxX;

    FloatingJoystick joy;

    private float y;
    private float positionX;

    private void Awake()
    {
        joy = FindObjectOfType<FloatingJoystick>();
    }

    private void Start()
    {
        _instance = this;
        y = transform.localEulerAngles.y;
    }

    private void Update()
    {
            transform.position += new Vector3(0, 0 , _speed * Time.deltaTime);

            if (transform.position.y < -0.5f)
            {
                GameManager._instance.GameOver();
            }
            var horizontal = joy.Horizontal;
            positionX += horizontal * _speed * Time.deltaTime;
            positionX = Mathf.Clamp(positionX,-_maxX,_maxX);

            y += horizontal * _turnSpeed * Time.deltaTime;
            y = Mathf.Clamp(y, -15, 15);

            if (positionX < _maxX && positionX > -_maxX)
            {
                transform.localPosition = new Vector3(positionX,transform.position.y,transform.position.z);
            }

            if (joy.Horizontal == 0)
            {
                if (y < 0)
                {
                    y += _turnSpeed * Time.deltaTime;
                }
                if (y > 0)
                {
                    y -= _turnSpeed * Time.deltaTime;
                }
            }

            if (y < 15 && y > -15)
            {
                transform.localEulerAngles = new Vector3(0, y, 0);
            }
        }
}
