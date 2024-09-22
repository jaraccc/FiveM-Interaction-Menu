using CitizenFX.Core;
using MenuAPI;
using System.Collections.Generic;

namespace Menu.Menus
{
    public static class CivilianAdvertMenu
    {
        private static readonly Dictionary<string, string> AdvertEvents = new Dictionary<string, string>
        {
            { "24/7", "ad1" },
            { "Ammunation", "ad2" },
            { "Downtown Cab Co.", "ad3" },
            { "Fleeca Bank", "ad4" },
            { "Gruppe Sechs Security", "ad5" },
            { "Rogers Salvage", "ad6" },
            { "Weazel News", "ad7" },
            { "Traffic Alert", "ad8" }
        };

        public static MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu advertMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Advert Menu");

            // Add menu items from the dictionary
            foreach (var advert in AdvertEvents.Keys)
            {
                advertMenu.AddMenuItem(new MenuItem(advert));
            }

            // Add the Go Back and Close options
            advertMenu.AddMenuItem(new MenuItem("Go Back"));
            advertMenu.AddMenuItem(new MenuItem("Close"));

            advertMenu.OnItemSelect += AdvertMenu_OnItemSelect;
            return advertMenu;
        }

        private static void AdvertMenu_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            string text = menuItem.Text;

            // Trigger advert events
            if (AdvertEvents.TryGetValue(text, out string advertEvent))
            {
                BaseScript.TriggerEvent(advertEvent);
            }
            else if (text == "Go Back")
            {
                menu.GoBack();
            }
            else if (text == "Close")
            {
                MenuController.CloseAllMenus();
            }
        }
    }
}
