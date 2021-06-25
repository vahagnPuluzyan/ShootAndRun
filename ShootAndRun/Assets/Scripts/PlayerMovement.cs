using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement _instance;

    public float _speed;
    public GameObject[] enemies;

    [SerializeField] float _turnSpeed = 5;
    [SerializeField] float _maxX;

    [HideInInspector] public bool shoot = false;
    [HideInInspector] public int index;

    FloatingJoystick joy;
    float positionX;


    private void Awake()
    {
        joy = FindObjectOfType<FloatingJoystick>();
    }

    private void Start()
    {
        _instance = this;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, _speed * Time.deltaTime);
        if (index <= enemies.Length)
        {
            if (index == enemies.Length)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.LookAt(enemies[index].transform);
            }
        }
        //player control 
        if (transform.position.y < -0.5f)
        {
            GameManager._instance.GameOver();
        }
        var horizontal = joy.Horizontal;
        positionX += horizontal * _turnSpeed * Time.deltaTime;
        positionX = Mathf.Clamp(positionX, -_maxX, _maxX);

        if (positionX < _maxX && positionX > -_maxX)
        {
            transform.localPosition = new Vector3(positionX, transform.position.y, transform.position.z);
        }
        //shoting
        if (index <= enemies.Length)
        {
            if (index == enemies.Length)
            {
                shoot = false;
            }
            else
            {
                if (Vector3.Distance(enemies[index].transform.position,transform.position) < 30) {
                    shoot = true;
                }
            }
        }
    }
}
