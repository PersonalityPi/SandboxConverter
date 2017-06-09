using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("SandboxConverter - A utility for converting Halo 3 sandbox.map files to \nHalo Online/ElDewrito.\n");
                Console.WriteLine("Sandbox.map files MUST NOT be inside an Xbox 360 container.\n");
                Console.WriteLine("Usage: SandboxConverter.exe <halo 3 sandbox.map> <output sandbox.map>\n");
                return;
            }
            using (EndianBinaryReader UsermapReader = new EndianBinaryReader(File.Open(args[0], FileMode.Open)))
            {
                using(BinaryWriter UsermapWriter = new BinaryWriter(File.Create(args[1])))
                {
                    // Read blf header
                    UsermapWriter.Write(UsermapReader.ReadBytes(0x30));

                    #region chdr
                    // Read chdr
                    UsermapWriter.Write(UsermapReader.ReadBytes(0x18));
                    for (var i = 0; i < 16; i++)
                    {
                        UsermapWriter.Write(UsermapReader.ReadInt16()); // chdr Unicode map name
                    }

                    byte[] desc = UsermapReader.ReadBytes(128);
                    var description = System.Text.Encoding.Default.GetString(desc);
                    byte[] auth = UsermapReader.ReadBytes(16);
                    var author = System.Text.Encoding.Default.GetString(auth);
                    UsermapWriter.Write(desc); // chdr map description
                    UsermapWriter.Write(author); // chdr map author
                    for(var i =0; i < 13;i++)
                    {
                        UsermapWriter.Write(UsermapReader.ReadInt32());
                    }
                    UsermapWriter.Write(UsermapReader.ReadInt16());
                    UsermapWriter.Write(UsermapReader.ReadBytes(10));
                    #endregion
                    #region mapv
                    // Do it all over again for the mapv header
                    UsermapWriter.Write(UsermapReader.ReadBytes(0x18));
                    for (var i = 0; i < 16; i++)
                    {
                        UsermapWriter.Write(UsermapReader.ReadInt16()); // mapv Unicode map name
                    }
                    UsermapWriter.Write(UsermapReader.ReadBytes(128)); // mapv map description
                    UsermapWriter.Write(UsermapReader.ReadBytes(16)); // mapv map author
                    for (var i = 0; i < 13; i++)
                    {
                        UsermapWriter.Write(UsermapReader.ReadInt32());
                    }
                    UsermapWriter.Write(UsermapReader.ReadInt16());
                    UsermapWriter.Write(UsermapReader.ReadBytes(10));
                    #endregion
                    #region map attributes
                    UsermapWriter.Write(UsermapReader.ReadInt16());
                    UsermapWriter.Write(UsermapReader.ReadInt16());
                    UsermapWriter.Write(UsermapReader.ReadByte());
                    UsermapWriter.Write(UsermapReader.ReadByte());
                    UsermapWriter.Write(UsermapReader.ReadInt16());
                    UsermapWriter.Write(UsermapReader.ReadInt32()); // map id
                    UsermapWriter.Write(UsermapReader.ReadInt32()); // world bounds x min
                    UsermapWriter.Write(UsermapReader.ReadInt32()); // world bounds x max
                    UsermapWriter.Write(UsermapReader.ReadInt32()); // world bounds y min
                    UsermapWriter.Write(UsermapReader.ReadInt32()); // world bounds y max
                    UsermapWriter.Write(UsermapReader.ReadInt32()); // world bounds z min
                    UsermapWriter.Write(UsermapReader.ReadInt32()); // world bounds z max
                    UsermapWriter.Write(UsermapReader.ReadInt32());
                    UsermapWriter.Write(UsermapReader.ReadInt32()); // maximum forge budget
                    UsermapWriter.Write(UsermapReader.ReadInt32()); // current forge budget
                    UsermapWriter.Write(UsermapReader.ReadBytes(4));
                    UsermapWriter.Write(UsermapReader.ReadInt32());
                    #endregion
                    #region object placements
                    for (var i=0;i < 640;i++)
                    {
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // object type
                        UsermapWriter.Write(UsermapReader.ReadBytes(8));
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // tags block index
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // bbject x
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // object y
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // object z
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // object yaw
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // object pitch
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // object roll
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // unknown rotation 1
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // unknown rotation 2
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // unknown rotation 3
                        UsermapWriter.Write(UsermapReader.ReadBytes(8));
                        UsermapWriter.Write(UsermapReader.ReadByte());
                        UsermapWriter.Write(UsermapReader.ReadByte());
                        UsermapWriter.Write(UsermapReader.ReadByte()); // place at start/symmetrical/asymmetrical
                        UsermapWriter.Write(UsermapReader.ReadByte()); // team
                        UsermapWriter.Write(UsermapReader.ReadByte()); // spare clips/teleporter channel
                        UsermapWriter.Write(UsermapReader.ReadByte()); // respawn time
                        UsermapWriter.Write(UsermapReader.ReadInt16());
                        UsermapWriter.Write(UsermapReader.ReadBytes(16));
                    }
                    #endregion
                    #region unknown block
                    for(var i = 0;i < 14;i++)
                    {
                        UsermapWriter.Write(UsermapReader.ReadInt16());
                    }
                    #endregion
                    #region tags
                    for (var i = 0; i < 256; i++)
                    {
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // tag datum index
                        UsermapWriter.Write(UsermapReader.ReadByte()); // run time minimum
                        UsermapWriter.Write(UsermapReader.ReadByte()); // run time maximum
                        UsermapWriter.Write(UsermapReader.ReadByte()); // number on map
                        UsermapWriter.Write(UsermapReader.ReadByte()); // design time maximum
                        UsermapWriter.Write(UsermapReader.ReadInt32()); // total cost
                    }
                    #endregion
                    #region unknown block 2
                    for (var i = 0; i < 80; i++)
                    {
                        UsermapWriter.Write(UsermapReader.ReadInt16());
                        UsermapWriter.Write(UsermapReader.ReadInt16());
                    }
                    #endregion

                    // Write the _eof and blank space (so its gonna be forever, or its gonna go down in flames) and some other stuff that 
                    // I haven't quite figured out but will later
                    UsermapWriter.Write(UsermapReader.ReadBytes(3628));
                    Console.WriteLine("Map Name: Placeholder"); // Will update soon
                    Console.WriteLine("Map Description: " + description);
                    Console.WriteLine("Map Author: " + author);
                }
            }
            
        }
    }
}
