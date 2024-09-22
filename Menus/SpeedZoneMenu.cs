using CitizenFX.Core;
using MenuAPI;
using System.Collections.Generic;

namespace Menu.Menus
{
    public class SpeedZoneMenu
    {
        private const string SpeedzoneRadius = "Speedzone Radius";
        private const string SpeedzoneSpeed = "Speedzone Speed";
        private const string CreateSpeedzone = "Create Speedzone";
        private const string DeleteSpeedzone = "Delete Closest Speedzone";

        private readonly int[] speedzoneRadii = { 30, 50, 100, 200 };
        private readonly int[] speedzoneSpeeds = { 0, 10, 20, 30 };

        public MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu speedzoneMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Speedzones");

            // Add menu items for radius and speed
            speedzoneMenu.AddMenuItem(new MenuListItem(SpeedzoneRadius, new List<string> { "30m", "50m", "100m", "200m" }, 0));
            speedzoneMenu.AddMenuItem(new MenuListItem(SpeedzoneSpeed, new List<string> { "0 MPH", "10 MPH", "20 MPH", "30 MPH" }, 0));

            // Add menu items for creating and deleting speed zones
            speedzoneMenu.AddMenuItem(new MenuItem(CreateSpeedzone, "Create a speedzone with the radius and speed specified above."));
            speedzoneMenu.AddMenuItem(new MenuItem(DeleteSpeedzone, "Deletes the closest speedzone."));

            // Bind event handlers
            speedzoneMenu.OnItemSelect += SpeedZoneMenu_OnItemSelect;
            speedzoneMenu.OnListIndexChange += SpeedZoneMenu_OnListIndexChange;

            return speedzoneMenu;
        }

        private void SpeedZoneMenu_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            switch (menuItem.Text)
            {
                case CreateSpeedzone:
                    BaseScript.TriggerEvent("createSpeedzone");
                    break;
                case DeleteSpeedzone:
                    BaseScript.TriggerServerEvent("RemoveZone");
                    break;
                default:
                    break;
            }
        }
        private void SpeedZoneMenu_OnListIndexChange(MenuAPI.Menu menu, MenuListItem listItem, int oldSelectionIndex, int newSelectionIndex, int itemIndex)
        {
            if (listItem.Text == SpeedzoneRadius)
            {
                BaseScript.TriggerEvent("setRadius", speedzoneRadii[newSelectionIndex]);
            }
            else if (listItem.Text == SpeedzoneSpeed)
            {
                BaseScript.TriggerEvent("setSpeed", speedzoneSpeeds[newSelectionIndex]);
            }
        }
    }
}
