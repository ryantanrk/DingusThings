using HarmonyLib;
using UnityEngine;

namespace DingusThings.Patches
{
    internal class LifebuoyBarSoapPatch
    {
        private static void RandomizeMaterial(GrabbableObject instance)
        {
            // get cube
            Item item = instance.itemProperties;
            GameObject prefab = item.spawnPrefab;
            GameObject model = prefab.transform.GetChild(0).gameObject;
            GameObject cube = model.transform.GetChild(0).gameObject;
            if (cube != null)
            {
                // get materials and set a random one
                Material[] materials = item.materialVariants;
                int randomIndex = Random.Range(0, materials.Length);
                cube.GetComponent<Renderer>().SetMaterial(materials[randomIndex]);
            }
        }

        [HarmonyPatch(typeof(GrabbableObject), nameof(GrabbableObject.Start))]
        [HarmonyPostfix]
        private static void GrabbableObject_Start(GrabbableObject __instance)
        {
            if (__instance.itemProperties.itemName == "Lifebuoy Bar Soap")
            {
                RandomizeMaterial(__instance);
            }
        }
    }
}
