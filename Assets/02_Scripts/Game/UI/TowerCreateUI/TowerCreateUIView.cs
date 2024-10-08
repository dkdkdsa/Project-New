using UnityEngine;
using static TowerCreateUIController;

public class TowerCreateUIView : UIView<DeckData, TowerCreateUIEventType>, ILocalInject
{

    [SerializeField] private TowerSlotUI _prefab;
    [SerializeField] private Transform _slotRoot;

    private IResourceManager _resMgr;
    public void LocalInject(ComponentList list)
    {

        _resMgr = Managers.GetManager<IResourceManager>();

    }

    public override void Viewing(in DeckData model)
    {

        int i = 0;

        foreach (var m in model.unitDataAddress)
        {

            var res = _resMgr.GetResource<UnitDataSO>(m);
            var ins = Instantiate(_prefab, _slotRoot);

            ins.SetUp(this, i);
            ins.View(res.View, res.Name);
            i++;

        }

    }


}
