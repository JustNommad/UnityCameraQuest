using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpeedConfig", menuName = "Player Speed")]
public class SpeedData : ScriptableObject
{
    [SerializeField] private float _speed = 0.0f;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
}
