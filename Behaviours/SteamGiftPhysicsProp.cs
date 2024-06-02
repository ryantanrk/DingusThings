using UnityEngine;

namespace DingusThings.Behaviours
{
    internal class SteamGiftPhysicsProp : PhysicsProp
    {
        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            base.ItemActivate(used, buttonDown);

            if (buttonDown)
            {
                AssetBundle? bundle = DingusThings.Bundle;
                string itemName = "Steam Gift Card";
                if (bundle == null)
                {
                    DingusThings.Logger.LogError($"{itemName}: Sound failed to play.");
                    return;
                }

                AudioClip audioClip = bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/steam_achievement.ogg");
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioClip, 1F);
            }
        }
    }
}
