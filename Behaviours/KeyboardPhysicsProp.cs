using UnityEngine;

namespace DingusThings.Behaviours
{
    internal class KeyboardPhysicsProp : PhysicsProp
    {
        private readonly float cooldown = 5.0f;

        float _lastTriggeredTime;

        private System.Random? randomizer;

        public override void Start()
        {
            base.Start();
            int seed = StartOfRound.Instance.randomMapSeed + StartOfRound.Instance.currentLevelID + itemProperties.itemId;
            randomizer = new System.Random(seed);
        }

        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            // if still under cooldown do not activate
            if (Time.time - _lastTriggeredTime < cooldown) return;

            base.ItemActivate(used, buttonDown);
            if (buttonDown)
            {
                _lastTriggeredTime = Time.time;
                string itemName = "Keyboard";
                AssetBundle? bundle = DingusThings.Bundle;

                if (bundle == null)
                {
                    DingusThings.Logger.LogError(itemName + ": Sound failed to play.");
                    return;
                }
                AudioClip[] clips = [
                    bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/ryan keyboard.ogg"),
                    bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/pingu keyboard.ogg"),
                    bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/mika keyboard.ogg"),
                    bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/kayeo keyboard.ogg"),
                    bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/agam keyboard.ogg"),
                    bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/luna keyboard.ogg")
                ];

                int randomIndex = 0;
                if (randomizer != null)
                {
                    randomIndex = randomizer.Next(clips.Length);
                }
                
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(clips[randomIndex], 1F);
            }
        }
    }
}
