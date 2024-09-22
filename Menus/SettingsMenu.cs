using CitizenFX.Core;
using MenuAPI;

namespace Menu.Menus
{
    public class SettingsMenu
    {
        private const string RightAlignMenu = "Right-Align Menu";
        private const string AboutMenu = "About Menu";

        public static MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu settingsMenu = new MenuAPI.Menu("Settings", Constants.MenuTitle);

            // Add menu items
            MenuCheckboxItem alignMenuCheckbox = new MenuCheckboxItem(RightAlignMenu, "Align the menu to the right side.");
            settingsMenu.AddMenuItem(alignMenuCheckbox);

            settingsMenu.AddMenuItem(new MenuItem(AboutMenu, "Created by ~b~notcamslice~s~"));

            // Event handler for checkbox change
            settingsMenu.OnCheckboxChange += SettingsMenu_OnCheckboxChange;

            return settingsMenu;
        }


        private static void SettingsMenu_OnCheckboxChange(MenuAPI.Menu menu, MenuCheckboxItem menuItem, int itemIndex, bool newCheckedState)
        {
            // Handle right-align menu option
            if (menuItem.Text == RightAlignMenu)
            {
                MenuController.MenuAlignment = newCheckedState
                    ? MenuController.MenuAlignmentOption.Right
                    : MenuController.MenuAlignmentOption.Left;
            }
        }
    }
}
