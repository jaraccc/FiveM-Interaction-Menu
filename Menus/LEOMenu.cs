using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;
using System.Collections.Generic;

namespace Menu.Menus
{
    public static class LEOMenu
    {
        public static MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu policeMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Law Enforcement Options");

            policeMenu.AddMenuItem(new MenuListItem("Cuff", new List<string>
            {
                "Rear",
                "Front",
                "Ziptie"
            }, 0));

            policeMenu.AddMenuItem(new MenuListItem("Hands On", new List<string>
            {
                "Grab",
                "Put in Vehicle",
                "Take out of Vehicle",
                "Carry"
            }, 0));
            policeMenu.AddMenuItem(new MenuItem("Equip Loadout"));
            policeMenu.AddMenuItem(new MenuItem("Refill Ammunition"));
            policeMenu.AddMenuItem(new MenuListItem("Less Lethal", new List<string>
            {
                "Taser",
                "Pepperspray",
                "Bean Bag Shotgun",
                "Antidote"
            }, 0));
            policeMenu.AddMenuItem(new MenuListItem("Radio Animation", new List<string>
            {
                "Shoulder Radio",
                "Chest Radio",
                "Hand Held Radio",
                "Rifle Radio 1",
                "Rifle Radio 2"
            }, 0));
            policeMenu.AddMenuItem(new MenuListItem("Rack or Unrack", new List<string>
            {
                "Carbine",
                "Shotgun"
            }, 0));
            policeMenu.AddMenuItem(new MenuListItem("Add Armour", new List<string>
            {
                "Light",
                "Medium",
                "Heavy",
                "Remove"
            }, 0));
            policeMenu.AddMenuItem(new MenuItem("Radar Controller"));
            policeMenu.AddMenuItem(new MenuItem("GSR Roadside Test"));
            policeMenu.AddMenuItem(new MenuItem("Send to Jail"));
            policeMenu.AddMenuItem(new MenuListItem("Deploy Spikes", new List<string>
            {
                "1",
                "2"
            }, 0));
            policeMenu.AddMenuItem(new MenuItem("Remove Spikes"));

            policeMenu.AddMenuItem(new MenuItem("Breathalyze"));

            policeMenu.OnItemSelect += LeoToolboxMenu_OnItemSelect;
            policeMenu.OnListItemSelect += LeoToolboxMenu_OnListItemSelect;

            return policeMenu;
        }

        private static void LeoToolboxMenu_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            switch (menuItem.Text)
            {
                case "Refill Ammunition":
                    BaseScript.TriggerEvent("ammoRefill");
                    break;
                case "Cuff":
                    ExecuteCommand("cuff");
                    break;
                case "Radar Controller":
                    BaseScript.TriggerEvent("wk:openRemote");
                    break;
                case "Remove Spikes":
                    ExecuteCommand("removespikes");
                    break;
                case "Breathalyze":
                    ExecuteCommand("breathalyzer");
                    break;
                case "Equip Loadout":
                    ExecuteCommand("eqloadout");
                    break;
                default:
                    Debug.WriteLine("Unknown menu item selected.");
                    break;
            }
        }
        private static void LeoToolboxMenu_OnListItemSelect(MenuAPI.Menu menu, MenuListItem listItem, int selectedIndex, int itemIndex)
        {
            switch (listItem.Text)
            {
                case "Deploy Spikes":
                    DeploySpikes(selectedIndex);
                    break;
                case "Cuff":
                    HandleCuffSelection(selectedIndex);
                    break;
                case "Less Lethal":
                    HandleLessLethalSelection(selectedIndex);
                    break;
                case "Hands On":
                    HandleHandsOnSelection(selectedIndex);
                    break;
                case "Radio Animation":
                    HandleRadioAnimationSelection(selectedIndex);
                    break;
                case "Rack or Unrack":
                    HandleRackOrUnrackSelection(selectedIndex);
                    break;
                case "Add Armour":
                    HandleAddArmourSelection(selectedIndex);
                    break;
                default:
                    Debug.WriteLine("Unknown list item selected.");
                    break;
            }
        }

        private static void DeploySpikes(int selectedIndex)
        {
            ExecuteCommand($"setspikes {selectedIndex + 1}");
        }

        private static void HandleCuffSelection(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    ExecuteCommand("cuff");
                    break;
                case 1:
                    ExecuteCommand("frontcuff");
                    break;
                case 2:
                    ExecuteCommand("ziptie");
                    break;
            }
        }

        private static void HandleLessLethalSelection(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    ExecuteCommand("taser");
                    break;
                case 1:
                    ExecuteCommand("pepperspray");
                    break;
                case 2:
                    ExecuteCommand("beanbag");
                    break;
                case 3:
                    ExecuteCommand("antidote");
                    break;
            }
        }

        private static void HandleHandsOnSelection(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    ExecuteCommand("grab");
                    break;
                case 1:
                    ExecuteCommand("+putcar");
                    break;
                case 2:
                    ExecuteCommand("+exitcar");
                    break;
                case 3:
                    ExecuteCommand("carry");
                    break;
            }
        }

        private static void HandleRadioAnimationSelection(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    ExecuteCommand("shoulderanim");
                    break;
                case 1:
                    ExecuteCommand("chestanim");
                    break;
                case 2:
                    ExecuteCommand("handheldanim");
                    break;
                case 3:
                    ExecuteCommand("swatanim1");
                    break;
                case 4:
                    ExecuteCommand("swatanim2");
                    break;
            }
        }

        private static void HandleRackOrUnrackSelection(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    BaseScript.TriggerEvent("toggleCarbine");
                    break;
                case 1:
                    BaseScript.TriggerEvent("toggleShotgun");
                    break;
            }
        }

        private static void HandleAddArmourSelection(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    BaseScript.TriggerEvent("bodyarmorA");
                    break;
                case 1:
                    BaseScript.TriggerEvent("bodyarmorB");
                    break;
                case 2:
                    BaseScript.TriggerEvent("bodyarmorC");
                    break;
                case 3:
                    BaseScript.TriggerEvent("bodyarmorremove");
                    break;
            }
        }
    }
}
