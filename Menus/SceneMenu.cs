using MenuAPI;

namespace Menu.Menus
{
    public static class SceneMenu
    {
        private const string SceneProps = "Scene Props";
        private const string SpeedZones = "Speed Zones";
        private const string TrafficNodeManager = "Traffic Node Manager";

        public static MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu sceneMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Scene Control");

            // Add and bind menu items
            AddAndBindMenuItem(sceneMenu, SceneProps, new PropMenu().GetMenu());
            AddAndBindMenuItem(sceneMenu, SpeedZones, new SpeedZoneMenu().GetMenu());
            AddAndBindMenuItem(sceneMenu, TrafficNodeManager, new NodeMenu().GetMenu());

            return sceneMenu;
        }

        // Helper method to add and bind a menu item
        private static void AddAndBindMenuItem(MenuAPI.Menu parentMenu, string itemName, MenuAPI.Menu childMenu)
        {
            MenuItem menuItem = new MenuItem(itemName)
            {
                Label = "→→→"
            };
            parentMenu.AddMenuItem(menuItem);
            MenuController.BindMenuItem(parentMenu, childMenu, menuItem);
        }
    }
}
