using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxConverter
{
    class TagDictionary
    {
        /* This is a tag dictionary class.
         * The purpose of this class is to store a fairly sizable dictionary with all tagrefs possible in a sandbox.map, and their equivalent tags in Halo Online.
         * The reason this is so huge is because the way Forge maps work in Halo 3, EVERY map has different tag indexes for, say, the assault rifle. So you must store a different AR tag index
         * for every different map. Because there are 8 maps in Halo Online that were in Halo 3, there are 8 different entries in the dictionary for one Halo 3 tag like the AR.
         * I'm not entirely sure there is a better way to do this, honestly. This will stay until I get a better method.*/
         
        Dictionary<uint, uint> Tags = new Dictionary<uint, uint> { 
            
        // Valhalla (Riverworld)
        
        // Sandbox Vehicles
        { 0xEA3B08C5, 0x151F }, // Warthog
        { 0xEC120A9C, 0x151A }, // Banshee
        { 0xF1260FB0, 0x1518 }, // Brute Chopper
        { 0xF0B20F3C, 0x1517 }, // Ghost
        { 0xEFDC0E66, 0x1598 }, // Hornet
        { 0xEED60D60, 0x1520 }, // Scorpion
        { 0xED970C21, 0x1519 }, // Wraith
        { 0xED1F0BA9, 0x1596 }, // Mongoose
        
        // Sandbox Weapons
        { 0xE26700F1, 0x151E }, // Assault Rifle
        { 0xE53603C0, 0x157C }, // Battle Rifle
        { 0xE7E60670, 0x1A45 }, // Shotgun
        { 0xE8D3075D, 0x15B1 }, // Sniper
        { 0xE88E0718, 0x157D }, // SMG
        { 0xF32211AC, 0x1500 }, // Spiker
        { 0xE72705B1, 0x157E }, // Magnum
        { 0xF3D3125D, 0x14F7 }, // Plasma Pistol
        { 0xF35A11E4, 0x14F8 }, // Needler
        { 0xF584140E, 0x1509 }, // Beam Rifle
        { 0xF4C61350, 0x14FF }, // Brute
        { 0xE76305ED, 0x15B3 }, // Rocket Launcher
        { 0xE57F0409, 0x15B2 }, // Spartan Laser
        { 0xF51913A3, 0x159E }, // Energy Blade
        { 0xE984080E, 0x15B5 }, // Machine Gun Turret
        { 0xF4F71381, 0x150C }, // Gravity Hammer
        { 0xF5CA1454, 0x1A56 }, // Sentinel Gun
        
        // Sandbox Equipment
        { 0xF1AF1039, 0x01AC }, // Frag Grenade
        { 0xF1DD1067, 0x01AF }, // Plasma Nade
        { 0xF26910F3, 0x01B2 }, // Claymore 
        { 0xF5F91483, 0x01B5 }, // Firenade 
        { 0xF202108C, 0x196E }, // Bubbleshield Equipment
        { 0xF2A81132, 0x1561 }, // Powerdrain
        { 0xF24010CA, 0x1567 }, // Tripmine Equipment
        { 0xF6081492, 0x2EA9 }, // GravliftEquipment
        { 0xF2FA1184, 0x1566 }, // Regen Equipment
        { 0xF63214BC, 0x1560 }, // Jammer Equipment
        { 0xF64514CF, 0x1565 }, // Superflare Equipment
        { 0xF66114EB, 0x1569 }, // InstantCover Equipment
        { 0xF2E5116F, 0x2EAB }, // Powerup Red
        { 0xF2D4115E, 0x2EAA }, // Powerup Blue
        { 0xF2F3117D, 0x2EAC }, // Powerup Yellow
        
        // Sandbox Scenery
        { 0xF6A3152D, 0x34A4 }, // Fusion Coil
        { 0xF6CC1556, 0x2EB3 }, // Crate Packing 
        { 0xF6E3156D, 0x2EB4 }, // Crate Packing Giant MP
        { 0xF6EF1579, 0x2EBC }, // Case Ap Turret
        { 0xF6F4157E, 0x34A5 }, // Antennae Mast
        { 0xF6FF1589, 0x2EB2 }, // Camping Stool MP
        { 0xF712159C, 0x2EB1 }, // Drum 55gal
        { 0xF71E15A8, 0x34A6 }, // Case
        { 0xF72E15B8, 0x34A7 }, // Mil Radio Small
        { 0xF74315CD, 0x34A8 }, // Resupply Capsule Unfired
        { 0xF74915D3, 0x34A9 }, // Resupply Capsule Panel
        { 0xF74E15D8, 0x34AA }, // Barricade Large
        { 0xF75A15E4, 0x34AB }, // Medical Crate
        { 0xF76E15F8, 0x2EBF }, // Gravlift Perm
        { 0xF77315FD, 0x2EBE }, // Covenant Sword Holder
        
        // Sandbox Teleporters
        { 0xF7891613, 0x2EC0 }, // Teleporter Sender
        { 0xF79D1627, 0x2EC1 }, // Teleporter Receiver
        { 0xF7A4162E, 0x2EC2 }, // Teleporter 2Way
        
        // Sandbox Goal Objects
        { 0xF7A5162F, 0x2EC3 }, // CTF Flag Spawn Point 
        { 0xF7D81662, 0x2EC4 }, // CTF Flag Return Area
        { 0xF7E1166B, 0x2EC5 }, // Assault Bomb Spawn Point
        { 0xF8081692, 0x2EC6 }, // Assault Bomb Goal Area
        { 0xF8091693, 0x2EC7 }, // Juggernaut Destination Static
        { 0xF812169C, 0x2EC8 }, // KOTH Hill Static
        { 0xF813169D, 0x2EC9 }, // Oddball Spawn Point 
        { 0xF82316AD, 0x2ECA }, // Territory Static
        { 0xF82516AF, 0x2ECB }, // VIP Destination Static
        
        // Sandbox Spawning
        { 0xE200008A, 0x2E90 }, // Respawn Point
        { 0xEA02088C, 0x2E90 }, // Assault Initial Spawn Point
        { 0xE23600C0, 0x2E91 }, // CTF Initial Spawn Point
        { 0xE23700C1, 0x2E9A }, // KOTH Initial Spawn Point
        { 0xE21F00A9, 0x2E9D }, // Oddball Initial Spawn Point
        { 0xE21E00A8, 0x2E92 }, // Slayer Initial Spawn Point
        { 0xE9DA0864, 0x2E9C }, // Territories Initial Spawn Point
        { 0xEA10089A, 0x2E9E }, // VIP Initial Spawn Point
        { 0xEA03088D, 0x2E99 }, // Assault Respawn Zone
        { 0xE23500BF, 0x2E93 }, // CTF Respawn Zone
        { 0xE23400BE, 0x2E95 }, // CTF Flag At Home Respawn Zone
        { 0xE23300BD, 0x2E96 }, // CTF Flag Away Respawn Zone
        { 0xF82616B0, 0x2E9B }, // KOTH Respawn Zone
        { 0xF82716B1, 0x2ECC }, // Oddball Respawn Zone
        { 0xE22000AA, 0x2E94 }, // Slayer Respawn Zone
        { 0xE23800C2, 0x2E97 }, // Territories Respawn Zone
        { 0xEA11089B, 0x2E9F }, // VIP Respawn Zone
        { 0xF82816B2, 0x2EA7 }, // Infection Initial Spawn Point
        { 0xF82916B3, 0x2EA8 }, // Infection Respawn Zone
        
        // The Pit (Cyberdyne)
        
        // Sandbox Vehicles
        { 0xE9DC0866, 0x1517 }, // Ghost
        { 0xE914079E, 0x1596 }, // Mongoose
        
        // Sandbox Weapons
        { 0xEF650DEF, 0x151E }, // Assault Rifle
        { 0xEFAF0E39, 0x157C }, // Battle Rifle
        { 0xF0360EC0, 0x1A45 }, // Shotgun
        { 0xF0C60F50, 0x15B1 }, // Sniper
        { 0xF0830F0D, 0x157D }, // SMG
        { 0xF1200FAA, 0x1500 }, // Spiker
        { 0xECD30B5D, 0x157E }, // Magnum
        { 0xEE110C9B, 0x14F7 }, // Plasma Pistol
        { 0xEFE80E72, 0x14F7 ), // Plasma Rifle
        { 0xED8E0C18, 0x14F8 }, // Needler
        { 0xF24210CC, 0x14FF }, // Brute
        { 0xF15D0FE7, 0x15B3 }, // Rocket Launcher
        { 0xF1C4104E, 0x15B2 }, // Spartan Laser
        { 0xEF1D0DA7, 0x159E }, // Energy Blade
        { 0xEA4308CD, 0x15B5 }, // Machine Gun Turret
        { 0xF27B1105, 0x150C }, // Gravity Hammer
        { 0xEEE00D6A, 0x1504 }, // Excavator
        { 0xF2E5116F, 0x1504 }, // Flamethrower
        { 0xF29B1125, 0x14F9 }, // Flak Cannon
        { 0xF3891213, 0x1509 }, // Beam Rifle
        { 0xF3CE1258, 0x1A56 }, // Sentinel Gun
        
        // Sandbox Scenery
        { 0xF491131B, 0x34A4 }, // Fusion Coil
        { 0xF4B91343, 0x47B1 }, // Box Metal Small
        { 0xF4C2134C, 0x2EB2 }, // Camping Stool Mp
        { 0xF4D4135E, 0x2EB4 }, // Crate Packing Large
        { 0xF4DA1364, 0x47BA }, // Generator
        { 0xF4E71371, 0x47BB }, // Generator Flood No Lights
        { 0xF4FC1386, 0x47CD }, // Generator Heavy
        { 0xF514139E, 0x2EB5 }, // Barrel Rusty
        { 0xF52913B3, 0x2EB6 }, // Rusty Barrel Small
        { 0xF53313BD, 0x47E5 }, // Locker
        { 0xF54013CA, 0x47F2 }, // Jersey Barrier
        { 0xF56813F2, 0x481A }, // Barrier Short
        { 0xF5971421, 0x4849 }, // Missle Body
        { 0xF59C1426, 0x484E }, // Missle Cap
        { 0xF5A1142B, 0x2EB7 }, // Pallet large
        { 0xF5D2145C, 0x2EB8 }, // Sawhorse
        { 0xF5ED1477, 0x2EB9 }, // Street Cone
        { 0xF5FD1487, 0x4853 }, // Toolball Small
        { 0xF60F1499, 0x4865 }, // Toolbox Large
        { 0xF61714A1, 0x2EB0 }, // Rucksack
        { 0xF62014AA, 0x486D }, // Propane Tank
        { 0xF63614C0, 0x2EBE }, // Cov Sword Holder
        { 0xF64B14D5, 0x4885 }, // Gravlift Equipment
      
        // Sandbox Teleporters
        { 0xF65014DA, 0x2EC0 }, // Teleporter Senter
        { 0xF66414EE, 0x2EC1 }, // Teleporter Receiver
        { 0xF66B14F5, 0x2EC2 }, // Teleporter 2way
        
        // Sandbox Goal Objects
        { , 0x }, // 
        { , 0x }, // 
        { , 0x }, // 
        { , 0x }, // 
        { , 0x }, // 
        { , 0x }, // 
        { , 0x }, // 
        { , 0x }, //
        { , 0x }, //
        
        // Sandbox Spawning
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        { , 0x }, //
        
        // Standoff (bunkerworld)
        
        // Sandbox Vehicles
        
        // Sandbox Weapons
        
        // Sandbox Scenery
        
        // Sandbox Teleporters
        
        // Sandbox Goal Objects
        
        // Sandbox Spawning
        
        
        };
    }
}
