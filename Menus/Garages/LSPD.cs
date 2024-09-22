using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;
using static Menu.Functions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Menu.Menus.Garages
{
    public static class LSPD
    {
        public static MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu lspdMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Police Vehicle Garage");

            lspdMenu.AddMenuItem(new MenuItem("Police Vehicle Name 1")
            {
                Label = "PATROL",
                RightIcon = MenuItem.Icon.CAR
            });

            lspdMenu.AddMenuItem(new MenuItem("Police Vehicle Name 2")
            {
                Label = "PATROL",
                RightIcon = MenuItem.Icon.CAR
            });

            lspdMenu.AddMenuItem(new MenuItem("Go Back"));
            lspdMenu.AddMenuItem(new MenuItem("Close"));
            lspdMenu.OnItemSelect += new MenuAPI.Menu.ItemSelectEvent(LSPD_OnItemSelect);
            return lspdMenu;
        }

        private static async void LSPD_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            string text = menuItem.Text;

            switch (text)
            {
                case "Police Vehicle Name 1":
                    // Pass the vehicle model, livery, and extra configurations (true = enabled, false = disabled)
                    await SpawnLSPDVehicle("police1", 0, new Dictionary<int, bool>
                    {
                        { 1, false },  // Extra 1 disabled
                        { 2, true },   // Extra 2 enabled
                        { 3, false }   // Extra 3 disabled (example)
                    });
                    break;

                case "Police Vehicle Name 2":
                    await SpawnLSPDVehicle("police2", 1, new Dictionary<int, bool>
                    {
                        { 1, true },   // Extra 1 enabled
                        { 2, false },  // Extra 2 disabled
                        { 4, true }    // Extra 4 enabled (example)
                    });
                    break;

                case "Go Back":
                    menu.GoBack();
                    break;

                case "Close":
                    MenuController.CloseAllMenus();
                    break;

                default:
                    break;
            }
        }

        private static async Task SpawnLSPDVehicle(string vehicleModel, int livery, Dictionary<int, bool> extras)
        {
            Vehicle veh = await spawnVehicle(vehicleModel);

            // Set the vehicle livery
            SetVehicleLivery(veh.Handle, livery);

            // Set vehicle extras based on the extras dictionary
            foreach (var extra in extras)
            {
                SetVehicleExtra(veh.Handle, extra.Key, !extra.Value);  // true = disable, false = enable
            }
        }
    }
}