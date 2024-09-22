using MenuAPI;
using Menu.Menus.Garages;

namespace Menu.Menus
{
    public class GarageMainMenu
    {
        public MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu garageMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Garage Menu");
            MenuItem menuItem1 = new MenuItem("Police Department")
            {
                Label = "→→→"
            };
            garageMenu.AddMenuItem(menuItem1);
            MenuController.BindMenuItem(garageMenu, LSPD.GetMenu(), menuItem1);

            MenuItem menuItem2 = new MenuItem("Sheriff's Office")
            {
                Label = "→→→"
            };
            garageMenu.AddMenuItem(menuItem2);
            MenuController.BindMenuItem(garageMenu, BCSO.GetMenu(), menuItem2);

            MenuItem menuItem3 = new MenuItem("Highway Patrol")
            {
                Label = "→→→"
            };
            garageMenu.AddMenuItem(menuItem3);
            MenuController.BindMenuItem(garageMenu, SAHP.GetMenu(), menuItem3);

            MenuItem menuItem4 = new MenuItem("Fire & EMS")
            {
                Label = "→→→"
            };
            garageMenu.AddMenuItem(menuItem4);
            MenuController.BindMenuItem(garageMenu, SAFR.GetMenu(), menuItem4);

            garageMenu.AddMenuItem(new MenuItem("Close"));
            garageMenu.OnItemSelect += new MenuAPI.Menu.ItemSelectEvent(GarageMainMenu.GarageMenu_OnItemSelect);
            return garageMenu;
        }

        private static void GarageMenu_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            string text = menuItem.Text;
            if (text == "Go Back")
            {
                menu.GoBack();
            }
            else
            {
                if (!(text == "Close"))
                    return;
                MenuController.CloseAllMenus();
            }
        }
    }
}