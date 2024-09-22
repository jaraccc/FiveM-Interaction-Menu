using MenuAPI;
using Menu.Menus;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Menu
{
    public class Client : BaseScript
    {
        private readonly MenuAPI.Menu menu = new MenuAPI.Menu(Constants.MenuTitle, "Main Menu");
        public static bool DontOpenAnyMenu { get; set; } = true;

        public Client()
        {
            MenuController.MenuAlignment = MenuController.MenuAlignmentOption.Right;
            MenuController.EnableMenuToggleKeyOnController = false;
            MenuController.AddMenu(menu);

            CreateMenus();

            menu.OnItemSelect += new MenuAPI.Menu.ItemSelectEvent(Menu_OnItemSelect);
        }

        private void CreateMenus()
        {
            MenuItem menuItem1 = new MenuItem(Constants.CivOps, "Open the Civilian options.")
            {
                Label = "→→→"
            };
            menu.AddMenuItem(menuItem1);
            MenuController.BindMenuItem(menu, PlayerOptions.GetMenu(), menuItem1);

            MenuItem menuItem2 = new MenuItem(Constants.LEOOps, "Options for Law Enforcements.")
            {
                Label = "→→→"
            };
            menu.AddMenuItem(menuItem2);
            MenuController.BindMenuItem(menu, LEOMenu.GetMenu(), menuItem2);

            MenuItem menuItem3 = new MenuItem(Constants.VehOps, "Standard vehicle options.")
            {
                Label = "→→→"
            };
            menu.AddMenuItem(menuItem3);
            MenuController.BindMenuItem(menu, VehicleMenu.GetMenu(), menuItem3);

            MenuItem menuItem4 = new MenuItem(Constants.SceneControl, "Open the Scene Control menu.")
            {
                Label = "→→→"
            };
            menu.AddMenuItem(menuItem4);
            MenuController.BindMenuItem(menu, SceneMenu.GetMenu(), menuItem4);

            menu.AddMenuItem(new MenuItem(Constants.EmoteMenu, "The Server emotes menu.")
            {
                Label = "→→→"
            });

            menu.AddMenuItem(new MenuItem(Constants.GarageMenu, "Open the Garage menu")
            {
                Label = "→→→"
            });

            menu.AddMenuItem(new MenuItem(Constants.TLSWeapons, "Open the Rifle menu")
            {
                Label = "→→→"
            });

            MenuItem menuItem6 = new MenuItem(Constants.Settings, "Configure your menu.")
            {
                Label = "→→→"
            };
            menu.AddMenuItem(menuItem6);
            MenuController.BindMenuItem(menu, SettingsMenu.GetMenu(), menuItem6);
        }

        private void CloseMenuAndDisableControl()
        {
            MenuController.CloseAllMenus();
            Game.DisableControlThisFrame(0, (Control)201);
        }

        private void Menu_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            switch (menuItem.Text)
            {
                case Constants.EmoteMenu:
                    CloseMenuAndDisableControl();
                    ExecuteCommand("emotemenu");
                    break;

                case Constants.GarageMenu:
                    CloseMenuAndDisableControl();
                    ExecuteCommand("garage");
                    break;

                case Constants.TLSWeapons:
                    CloseMenuAndDisableControl();
                    ExecuteCommand("weapons");
                    break;

                default:
                    Debug.WriteLine("Unknown menu item selected.");
                    break;
            }
        }
    }
}
