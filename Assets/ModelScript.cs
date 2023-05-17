using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelScript : MonoBehaviour
{

    /// <summary>
    /// Отвечает за состояние модели: вращение при бездействии и статичное положение при взаимодействии с пользователем.
    /// </summary>
    [SerializeField]
    bool IsSpinning;

    /// <summary>
    /// Отвечает за время ожидания после любого взаимодействия (в секундах).
    /// После указанного времени модель вновь начинает самостоятельное плавное вращение.
    /// </summary>
    [SerializeField]
    int WaitingDelay;

    [SerializeField]
    float TimeDelay;

    float SpinningSpeed;

    [SerializeField]
    float MaxSpinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        IsSpinning = false;
        TimeDelay = 0;
        WaitingDelay = 5;
        SpinningSpeed = 0;
        MaxSpinSpeed = 25;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsSpinning)
        {
            TimeDelay += 0.02F;
            if (TimeDelay >= WaitingDelay)
            {
                TimeDelay = 0;
                IsSpinning = true;
            }
            if (SpinningSpeed > 0)
                SpinningSpeed -= 1;
        }
        else if (IsSpinning)
        {
            if (SpinningSpeed < MaxSpinSpeed)
                SpinningSpeed += 1;
        }
        Quaternion rotationRight = Quaternion.AngleAxis(SpinningSpeed / 50.0F, Vector3.up);
        transform.rotation *= rotationRight;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            IsSpinning = !IsSpinning;
        }
    }

}
