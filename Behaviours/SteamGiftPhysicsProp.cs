using UnityEngine;

namespace DingusThings.Behaviours
{
    internal class SteamGiftPhysicsProp : PhysicsProp
    {
        private void ChangeTooltip()
        {
            if (base.IsOwner)
            {
                HUDManager.Instance.ChangeControlTip(2, scrapValue <= 0 ? "ALREADY REDEEMED" : "Redeem : [ LMB ]");
            }
        }

        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            if (scrapValue <= 0) return;

            base.ItemActivate(used, buttonDown);

            if (buttonDown)
            {
                AssetBundle? bundle = DingusThings.Bundle;
                string itemName = "Steam Gift Card";

                // find a terminal
                Terminal terminal = DingusThings.GetTerminalInstance();
                if (terminal != null)
                {
                    // add scrap value to terminal
                    terminal.groupCredits = terminal.groupCredits + scrapValue;

                    // set scrap value to 0
                    SetScrapValue(0);
                    ChangeTooltip();

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
}
