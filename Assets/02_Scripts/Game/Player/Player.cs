using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LocalInstaller))]
public class Player : MonoBehaviour, ILocalInject
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private List<IController> _controllers;
    private IInputController _input;
    private IMoveable _move;
    private IRotateable _rotate;

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputController>();
        _move = list.Find<IMoveable>();
        _controllers = list.FindAll<IController>();
        _rotate = list.Find<IRotateable>();

    }

    private void Update()
    {

        foreach (var controller in _controllers)
        {

            if (!controller.Active)
                continue;

            controller.Control();

        }

        MoveExecute();
        RotateExecute();

    }

    private void MoveExecute()
    {

        Vector2 input = _input.GetValue<Vector2>(Hashs.INPUT_HASH_MOVE_VECTOR);
        Vector3 vec = ((Vector3.forward * input.y) + (Vector3.right * input.x)).normalized;
        
        _move.Move(vec, _moveSpeed);

    }

    private void RotateExecute()
    {

        if(_input.GetValue<MouseInputType>(Hashs.INPUT_HASH_R_MOUSE_BUTTON) == MouseInputType.Down)
        {

            _rotate.Rotate(
                _input.GetValue<Vector2>(Hashs.INPUT_HASH_MOUSE_POSITION),
            _rotateSpeed);

        }


    }

}
