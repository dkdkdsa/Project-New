using UnityEngine;

public class AttackTower : TowerBase, ILocalInject
{

    protected IValueContainer<int> _valueContnainer;
    protected ITimer<float> _coolDownTimer;
    protected IController _attack;
    protected IController _target;
    protected IController _rotate;

    public void Inject(IController attack, IController target, IController rotate)
    {
        _attack = attack;
        _target = target;
        _rotate = rotate;
    }

    public void LocalInject(ComponentList list)
    {

        _valueContnainer = list.Find<IValueContainer<int>>();

    }

    protected override void Awake()
    {

        base.Awake();

        _coolDownTimer = TimerHelper.GetTimer<float>();

    }

    private void Update()
    {

        _target.Control();
        CheckAttack();

    }

    /// <summary>
    /// 공격 가능여부를 검사후 공격
    /// </summary>
    private void CheckAttack()
    {

        if (!_coolDownTimer.IsStarted)
        {
            var target = _valueContnainer.GetValue<Transform>(Hashs.TOWER_VALUE_TARGET);

            if (target != null)
            {

                _coolDownTimer.SetTime(_valueContnainer.GetValue<float>(Hashs.TOWER_VALUE_ATTACKRATE));
                _coolDownTimer.StartTimer();
                NotifyEvent(TowerEventType.Rotate);
                NotifyEvent(TowerEventType.Attack);

            }

        }

    }

    private void OnDestroy()
    {

        _coolDownTimer.Dispose();

    }
}
