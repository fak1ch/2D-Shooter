using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Bullets
{
    public class AK74 : Gun
    {
        protected override void AddBulletsToAmmo(int bullets)
        {
            if (_itemCell.InventoryPopUp.TryGetItemCellByItemType<AK47Ammo>(out ItemCell itemCell))
            {
                bullets = itemCell.RemoveCountFromStack(bullets);
            }
            else
            {
                bullets = 0;
            }

            base.AddBulletsToAmmo(bullets);
        }
    }
}