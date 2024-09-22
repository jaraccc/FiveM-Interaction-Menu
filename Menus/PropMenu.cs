using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;
using System.Collections.Generic;

namespace Menu.Menus
{
    public class PropMenu
    {

        private const string SpawnProp = "Spawn Prop";
        private const string DeleteClosestProp = "Delete Closest Prop";
        private const string GoBack = "Go Back";
        private const string Close = "Close";


        public MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu scenePropMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Scene Props");

            // Add menu items
            scenePropMenu.AddMenuItem(new MenuListItem(SpawnProp, new List<string>
            {
                "Road Pole",
                "Small Cone",
                "Large Cone",
                "Small Barrier",
                "Large Barrier",
                "Police Barrier",
                "Tent",
                "Scene Lights",
                "Left Arrow Board",
                "Right Arrow Board"
            }, 0));

            scenePropMenu.AddMenuItem(new MenuItem(DeleteClosestProp, "Deletes the closest placed prop."));
            scenePropMenu.OnItemSelect += ScenePropMenu_OnItemSelect;
            scenePropMenu.OnListItemSelect += ScenePropMenu_OnListItemSelect;

            return scenePropMenu;
        }

        private void ScenePropMenu_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            switch (menuItem.Text)
            {
                case DeleteClosestProp:
                    BaseScript.TriggerEvent("delete:object");
                    break;
                case GoBack:
                    menu.GoBack();
                    break;
                case Close:
                    MenuController.CloseAllMenus();
                    break;
                default:
                    break;
            }
        }

        private void ScenePropMenu_OnListItemSelect(MenuAPI.Menu menu, MenuListItem listItem, int selectedIndex, int itemIndex)
        {
            if (listItem.Text == SpawnProp)
            {
                SpawnPropByIndex(selectedIndex);
            }
        }

        // Refactored method to handle prop spawning
        private void SpawnPropByIndex(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    BaseScript.TriggerEvent("spawn:rpole");
                    break;
                case 1:
                    BaseScript.TriggerEvent("spawn:scone");
                    break;
                case 2:
                    BaseScript.TriggerEvent("spawn:lcone");
                    break;
                case 3:
                    BaseScript.TriggerEvent("spawn:sbarrier");
                    break;
                case 4:
                    BaseScript.TriggerEvent("spawn:lbarrier");
                    break;
                case 5:
                    BaseScript.TriggerEvent("spawn:policebarrier");
                    break;
                case 6:
                    BaseScript.TriggerEvent("spawn:tent");
                    break;
                case 7:
                    BaseScript.TriggerEvent("spawn:scenelights");
                    break;
                case 8:
                    BaseScript.TriggerEvent("spawn:tbarrierL");
                    break;
                case 9:
                    BaseScript.TriggerEvent("spawn:tbarrierR");
                    break;
                default:
                    break;
            }
        }
    }
}
