using MenuAPI;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System.Collections.Generic;

namespace Menu.Menus
{
    public static class PlayerOptions
    {

        private const string HandsUp = "Hands Up";
        private const string HandsUpKnees = "Hands Up Knees";
        private const string HandsOnHead = "Hands on Head";
        private const string Ziptie = "Ziptie";
        private const string UncuffSelf = "Uncuff Self";
        private const string Carry = "Carry";
        private const string ComposeAd = "Compose An Advertisement";

        public static MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu civilianMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Civilian Options");

            civilianMenu.AddMenuItem(new MenuItem(Ziptie));
            civilianMenu.AddMenuItem(new MenuItem(Carry));
            civilianMenu.AddMenuItem(new MenuItem(HandsUp));
            civilianMenu.AddMenuItem(new MenuItem(HandsUpKnees));
            civilianMenu.AddMenuItem(new MenuItem(HandsOnHead));
            civilianMenu.AddMenuItem(new MenuItem(UncuffSelf));

            civilianMenu.AddMenuItem(new MenuListItem("Priority", new List<string>()
            {
                "Start Priority",
                "Join Priority",
                "Leave Priority",
                "End Priority",
                "Priority Cooldown"
            }, 0));

            civilianMenu.AddMenuItem(new MenuListItem("Set Effect", new List<string>()
            {
                "Drunk",
                "Severely Drunk",
                "Cocaine",
                "Meth",
                "Weed",
                "LSD",
                "Heroin",
                "Reset"
            }, 0));

            // Compose Advertisement
            MenuItem menuItem1 = new MenuItem(ComposeAd) { Label = "→→→" };
            civilianMenu.AddMenuItem(menuItem1);
            MenuController.BindMenuItem(civilianMenu, CivilianAdvertMenu.GetMenu(), menuItem1);

            // Event listeners
            civilianMenu.OnItemSelect += CivToolboxMenu_OnItemSelect;
            civilianMenu.OnListItemSelect += CivToolboxMenu_OnListItemSelect;

            return civilianMenu;
        }

        private static void CivToolboxMenu_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            switch (menuItem.Text)
            {
                case HandsUp:
                    ExecuteCommand("hu");
                    break;
                case HandsUpKnees:
                    ExecuteCommand("huk");
                    break;
                case HandsOnHead:
                    ExecuteCommand("hoh");
                    break;
                case Ziptie:
                    ExecuteCommand("ziptie");
                    break;
                case UncuffSelf:
                    ExecuteCommand("uncuffself");
                    break;
                case Carry:
                    ExecuteCommand("carry");
                    break;
                default:
                    break;
            }
        }

        private static void CivToolboxMenu_OnListItemSelect(MenuAPI.Menu menu, MenuListItem listItem, int selectedIndex, int itemIndex)
        {
            switch (listItem.Text)
            {
                case "Priority":
                    HandlePrioritySelection(selectedIndex);
                    break;
                case "Set Effect":
                    HandleEffectSelection(selectedIndex);
                    break;
                default:
                    break;
            }
        }

        private static void HandlePrioritySelection(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    ExecuteCommand("stprio");
                    break;
                case 1:
                    ExecuteCommand("jprio");
                    break;
                case 2:
                    ExecuteCommand("lprio");
                    break;
                case 3:
                    ExecuteCommand("sprio");
                    break;
                case 4:
                    ExecuteCommand("cdprio");
                    break;
                default:
                    break;
            }
        }

        // Handle Effect selections
        private static void HandleEffectSelection(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    BaseScript.TriggerEvent("civ-effect:drunk1");
                    break;
                case 1:
                    BaseScript.TriggerEvent("civ-effect:drunk2");
                    break;
                case 2:
                    BaseScript.TriggerEvent("civ-effect:coke");
                    break;
                case 3:
                    BaseScript.TriggerEvent("civ-effect:meth");
                    break;
                case 4:
                    BaseScript.TriggerEvent("civ-effect:weed");
                    break;
                case 5:
                    BaseScript.TriggerEvent("civ-effect:lsd");
                    break;
                case 6:
                    BaseScript.TriggerEvent("civ-effect:heroin");
                    break;
                case 7:
                    BaseScript.TriggerEvent("civ-effect:reset");
                    break;
                default:
                    break;
            }
        }
    }
}
