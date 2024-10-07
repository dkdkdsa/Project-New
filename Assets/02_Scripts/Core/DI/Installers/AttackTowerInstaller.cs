using UnityEngine;

public class AttackTowerInstaller : InstallerBase<AttackTower>
{

    [SerializeField] private Component _attackController;
    [SerializeField] private Component _rotateController;
    [SerializeField] private Component _targetController;

    protected override void Inject(AttackTower target)
    {

        target.Inject(_attackController as IController, _targetController as IController, _rotateController as IController);

    }

}