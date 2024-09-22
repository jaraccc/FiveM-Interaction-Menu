using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Menu
{
    class Functions
    {
        public static async Task<Vehicle> spawnVehicle(string spawnCode)
        {
            if (IsPedInAnyVehicle(Game.PlayerPed.Handle, true))
            {
                int playerVeh = Game.PlayerPed.CurrentVehicle.Handle;
                DeleteEntity(ref playerVeh);
            }

            uint spawnHash = (uint)GetHashKey(spawnCode);
            RequestModel(spawnHash);

            // Timeout in case the model fails to load
            int timeout = 10000; // 10 seconds
            int waited = 0;
            while (!HasModelLoaded(spawnHash) && waited < timeout)
            {
                await BaseScript.Delay(100);
                waited += 100;
            }

            // Check if the model failed to load
            if (!HasModelLoaded(spawnHash))
            {
                Debug.WriteLine($"[Error] Model {spawnCode} failed to load.");
                return null;
            }

            Vector3 playerLoc = Game.PlayerPed.Position;
            Vehicle veh = new Vehicle(CreateVehicle(spawnHash, playerLoc.X, playerLoc.Y, playerLoc.Z, Game.PlayerPed.Heading, true, false));
            int vehHandle = veh.Handle;
            SetPedIntoVehicle(Game.PlayerPed.Handle, vehHandle, -1);
            SetVehicleDirtLevel(vehHandle, 0);
            SetVehicleLivery(vehHandle, 0);

            return veh;
        }

        public static async Task SpawnEUPPed(string pedtype, int maskC, int maskD, int torsoC, int torsoD, int pantsC, int pantsD, int handsC, int handsD, int shoesC, int shoesD, int holsterC, int holsterD, int accessoryC, int accessoryD, int armorC, int armorD, int decalsC, int decalsD, int topC, int topD)
        {
            if (Game.PlayerPed.Model.Hash != Game.GenerateHash(pedtype))
            {
                var pedModel = new Model(pedtype);
                await Game.Player.ChangeModel(pedModel);
            }

            ClearPedProp(Game.PlayerPed.Handle, 0);
            ClearPedProp(Game.PlayerPed.Handle, 1);

            // Set ped variations
            SetPedComponentVariation(Game.PlayerPed.Handle, 1, maskC - 1, maskD - 1, 0);
            SetPedComponentVariation(Game.PlayerPed.Handle, 3, torsoC - 1, torsoD - 1, 0);
            SetPedComponentVariation(Game.PlayerPed.Handle, 4, pantsC - 1, pantsD - 1, 0);
            SetPedComponentVariation(Game.PlayerPed.Handle, 5, handsC - 1, handsD - 1, 0);
            SetPedComponentVariation(Game.PlayerPed.Handle, 6, shoesC - 1, shoesD - 1, 0);
            SetPedComponentVariation(Game.PlayerPed.Handle, 7, holsterC - 1, holsterD - 1, 0);
            SetPedComponentVariation(Game.PlayerPed.Handle, 8, accessoryC - 1, accessoryD - 1, 0);
            SetPedComponentVariation(Game.PlayerPed.Handle, 9, armorC - 1, armorD - 1, 0);
            SetPedComponentVariation(Game.PlayerPed.Handle, 10, decalsC - 1, decalsD - 1, 0);
            SetPedComponentVariation(Game.PlayerPed.Handle, 11, topC - 1, topD - 1, 0);
        }

        public static void SetEUPProps(int hatC, int hatD, int glassesC, int glassesD, int miscC, int miscD)
        {
            ClearPedProp(Game.Player.Handle, 0);
            ClearPedProp(Game.Player.Handle, 1);

            // Set prop variations
            SetPedPropIndex(Game.PlayerPed.Handle, 0, hatC - 2, hatD - 1, true);
            SetPedPropIndex(Game.PlayerPed.Handle, 1, glassesC - 2, glassesD - 1, true);
            SetPedPropIndex(Game.PlayerPed.Handle, 2, miscC - 2, miscD - 1, true);
        }

        public static Vehicle GetVehicle(bool lastVehicle = false)
        {
            if (lastVehicle)
            {
                return Game.PlayerPed.LastVehicle;
            }

            if (Game.PlayerPed.IsInVehicle())
            {
                return Game.PlayerPed.CurrentVehicle;
            }

            return null;
        }
    }
}
