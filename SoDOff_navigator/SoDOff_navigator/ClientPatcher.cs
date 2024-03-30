using System;
using System.Text;
using System.IO;

namespace SoDOff_navigator
{
    class ClientPatcher
    {
        public static void PatchClient(string path, string version, string mode)
        {
            //http://localhost:5001/.com/conf/
            byte[] url_offline = { 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x6C, 0x6F, 0x63, 0x61, 0x6C, 0x68, 0x6F, 0x73, 0x74,
                                   0x3A, 0x35, 0x30, 0x30, 0x31, 0x2F, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x63, 0x6F, 0x6E, 0x66, 0x2F };
            //https://ridersguild.org/DWADragonsUnity/
            byte[] url_online = { 0x68, 0x74, 0x74, 0x70, 0x73, 0x3A, 0x2F, 0x2F, 0x72, 0x69, 0x64, 0x65, 0x72, 0x73, 0x67, 0x75,
                                  0x69, 0x6C, 0x64, 0x2E, 0x6F, 0x72, 0x67, 0x2F, 0x44, 0x57, 0x41, 0x44, 0x72, 0x61, 0x67, 0x6F,
                                  0x6E, 0x73, 0x55, 0x6E, 0x69, 0x74, 0x79, 0x2F };
            //http://media.dev.jumpstart.com/DWADragonsUnity/
            byte[] url1_orig = { 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x6D, 0x65, 0x64, 0x69, 0x61, 0x2E, 0x64, 0x65, 0x76,
                                 0x2E, 0x6A, 0x75, 0x6D, 0x70, 0x73, 0x74, 0x61, 0x72, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x44,
                                 0x57, 0x41, 0x44, 0x72, 0x61, 0x67, 0x6F, 0x6E, 0x73, 0x55, 0x6E, 0x69, 0x74, 0x79, 0x2F };
            //http://media.qa.jumpstart.com/DWADragonsUnity/
            byte[] url2_orig = { 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x6D, 0x65, 0x64, 0x69, 0x61, 0x2E, 0x71, 0x61, 0x2E,
                                 0x6A, 0x75, 0x6D, 0x70, 0x73, 0x74, 0x61, 0x72, 0x74, 0x2E, 0x63, 0x6F, 0x6D, 0x2F, 0x44, 0x57,
                                 0x41, 0x44, 0x72, 0x61, 0x67, 0x6F, 0x6E, 0x73, 0x55, 0x6E, 0x69, 0x74, 0x79, 0x2F };

            //http://media.staging.jumpstart.com/DWADragonsUnity/
            byte[] url3_orig = { 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x6D, 0x65, 0x64, 0x69, 0x61, 0x2E, 0x73, 0x74, 0x61,
                                 0x67, 0x69, 0x6E, 0x67, 0x2E, 0x6A, 0x75, 0x6D, 0x70, 0x73, 0x74, 0x61, 0x72, 0x74, 0x2E, 0x63,
                                 0x6F, 0x6D, 0x2F, 0x44, 0x57, 0x41, 0x44, 0x72, 0x61, 0x67, 0x6F, 0x6E, 0x73, 0x55, 0x6E, 0x69,
                                 0x74, 0x79, 0x2F };

            string fileName = path + @"\DOMain_Data\resources.assets";
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Write);

            if (version == "3.31" && mode == "offline")
            {
                file.Seek(11096316, SeekOrigin.Begin);
                //47 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 15; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(11096444, SeekOrigin.Begin);
                //46 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 14; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(11096572, SeekOrigin.Begin);
                //51 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 19; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(11096708, SeekOrigin.Begin);
                //40 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 8; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(11096840, SeekOrigin.Begin);
                //40 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 8; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(11097152, SeekOrigin.Begin);
                //56BB211B-CF06-48E1-9C1D-E40B5173D759
                byte[] id1_offline_331 = { 0x35, 0x36, 0x42, 0x42, 0x32, 0x31, 0x31, 0x42, 0x2D, 0x43, 0x46, 0x30, 0x36, 0x2D, 0x34, 0x38,
                                           0x45, 0x31, 0x2D, 0x39, 0x43, 0x31, 0x44, 0x2D, 0x45, 0x34, 0x30, 0x42, 0x35, 0x31, 0x37, 0x33,
                                           0x44, 0x37, 0x35, 0x39 };
                file.Write(id1_offline_331, 0, id1_offline_331.Length);

                file.Seek(11097268, SeekOrigin.Begin);
                file.Write(id1_offline_331, 0, id1_offline_331.Length);

                file.Seek(11097472, SeekOrigin.Begin);
                //B99F695C-7C6E-4E9B-B0F7-22034D799013
                byte[] id2_offline_331 = { 0x42, 0x39, 0x39, 0x46, 0x36, 0x39, 0x35, 0x43, 0x2D, 0x37, 0x43, 0x36, 0x45, 0x2D, 0x34, 0x45,
                                           0x39, 0x42, 0x2D, 0x42, 0x30, 0x46, 0x37, 0x2D, 0x32, 0x32, 0x30, 0x33, 0x34, 0x44, 0x37, 0x39,
                                           0x39, 0x30, 0x31, 0x33 };
                file.Write(id2_offline_331, 0, id2_offline_331.Length);

                file.Seek(11097512, SeekOrigin.Begin);
                file.Write(id1_offline_331, 0, id1_offline_331.Length);

                file.Close();
            }
            else if (version == "3.31" && mode == "online")
            {
                file.Seek(11096316, SeekOrigin.Begin);
                file.Write(url1_orig, 0, url1_orig.Length);

                file.Seek(11096444, SeekOrigin.Begin);
                file.Write(url2_orig, 0, url2_orig.Length);

                file.Seek(11096572, SeekOrigin.Begin);
                file.Write(url3_orig, 0, url3_orig.Length);

                file.Seek(11096708, SeekOrigin.Begin);
                file.Write(url_online, 0, url_online.Length);

                file.Seek(11096840, SeekOrigin.Begin);
                file.Write(url_online, 0, url_online.Length);

                file.Seek(11097152, SeekOrigin.Begin);
                //7D175215-56D3-4495-BC3E-F55EA92B06A5
                byte[] id1_online_331 = { 0x37, 0x44, 0x31, 0x37, 0x35, 0x32, 0x31, 0x35, 0x2D, 0x35, 0x36, 0x44, 0x33, 0x2D, 0x34, 0x34, 0x39,
                                          0x35, 0x2D, 0x42, 0x43, 0x33, 0x45, 0x2D, 0x46, 0x35, 0x35, 0x45, 0x41, 0x39, 0x32, 0x42, 0x30, 0x36,
                                          0x41, 0x35 };
                file.Write(id1_online_331, 0, id1_online_331.Length);

                file.Seek(11097268, SeekOrigin.Begin);
                //8ADB1B50-91F7-4829-BEEF-82152C6DB752
                byte[] id2_online_331 = { 0x38, 0x41, 0x44, 0x42, 0x31, 0x42, 0x35, 0x30, 0x2D, 0x39, 0x31, 0x46, 0x37, 0x2D, 0x34, 0x38, 0x32,
                                          0x39, 0x2D, 0x42, 0x45, 0x45, 0x46, 0x2D, 0x38, 0x32, 0x31, 0x35, 0x32, 0x43, 0x36, 0x44, 0x42, 0x37,
                                          0x35, 0x32 };
                file.Write(id2_online_331, 0, id2_online_331.Length);

                file.Seek(11097472, SeekOrigin.Begin);
                //FE543944-3F16-4E02-986C-C68C43C16F07
                byte[] id3_online_331 = { 0x46, 0x45, 0x35, 0x34, 0x33, 0x39, 0x34, 0x34, 0x2D, 0x33, 0x46, 0x31, 0x36, 0x2D, 0x34, 0x45, 0x30,
                                          0x32, 0x2D, 0x39, 0x38, 0x36, 0x43, 0x2D, 0x43, 0x36, 0x38, 0x43, 0x34, 0x33, 0x43, 0x31, 0x36, 0x46,
                                          0x30, 0x37 };
                file.Write(id3_online_331, 0, id3_online_331.Length);

                file.Seek(11097512, SeekOrigin.Begin);
                //F5D573D9-CDB3-4142-9462-F2A5DEF0B7E8
                byte[] id4_online_331 = { 0x46, 0x35, 0x44, 0x35, 0x37, 0x33, 0x44, 0x39, 0x2D, 0x43, 0x44, 0x42, 0x33, 0x2D, 0x34, 0x31, 0x34,
                                          0x32, 0x2D, 0x39, 0x34, 0x36, 0x32, 0x2D, 0x46, 0x32, 0x41, 0x35, 0x44, 0x45, 0x46, 0x30, 0x42, 0x37,
                                          0x45, 0x38 };
                file.Write(id4_online_331, 0, id4_online_331.Length);

                file.Close();
            }
            else if (version == "3.26" && mode == "offline")
            {
                file.Seek(34696932, SeekOrigin.Begin);
                //47 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 15; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34697060, SeekOrigin.Begin);
                //46 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 14; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34697188, SeekOrigin.Begin);
                //51 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 19; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34697324, SeekOrigin.Begin);
                //40 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 8; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34697456, SeekOrigin.Begin);
                //40 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 8; i++)
                {
                    file.WriteByte(0);
                }

                file.Seek(34698572, SeekOrigin.Begin);
                //A3A26A0A-7C6E-4E9B-B0F7-22034D799013
                byte[] id1_offline_326 = { 0x41, 0x33, 0x41, 0x32, 0x36, 0x41, 0x30, 0x41 };
                file.Write(id1_offline_326, 0, id1_offline_326.Length);

                file.Close();
            }
            else if (version == "3.26" && mode == "online")
            {
                file.Seek(34696932, SeekOrigin.Begin);
                file.Write(url1_orig, 0, url1_orig.Length);

                file.Seek(34697060, SeekOrigin.Begin);
                file.Write(url2_orig, 0, url2_orig.Length);

                file.Seek(34697188, SeekOrigin.Begin);
                file.Write(url3_orig, 0, url3_orig.Length);

                file.Seek(34697324, SeekOrigin.Begin);
                file.Write(url_online, 0, url_online.Length);

                file.Seek(34697456, SeekOrigin.Begin);
                file.Write(url_online, 0, url_online.Length);

                file.Seek(34698572, SeekOrigin.Begin);
                //B99F695C-7C6E-4E9B-B0F7-22034D799013
                byte[] id1_online_326 = { 0x42, 0x39, 0x39, 0x46, 0x36, 0x39, 0x35, 0x43 };
                file.Write(id1_online_326, 0, id1_online_326.Length);

                file.Close();
            }
            else if (version == "3.21" && mode == "offline")
            {
                file.Seek(34695260, SeekOrigin.Begin);
                //47 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 15; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34695388, SeekOrigin.Begin);
                //46 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 14; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34695516, SeekOrigin.Begin);
                //51 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 19; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34695652, SeekOrigin.Begin);
                //40 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 8; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34695784, SeekOrigin.Begin);
                //40 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 8; i++)
                {
                    file.WriteByte(0);
                }

                file.Close();
            }
            else if (version == "3.21" && mode == "online")
            {
                file.Seek(34695260, SeekOrigin.Begin);
                file.Write(url1_orig, 0, url1_orig.Length);

                file.Seek(34695388, SeekOrigin.Begin);
                file.Write(url2_orig, 0, url2_orig.Length);

                file.Seek(34695516, SeekOrigin.Begin);
                file.Write(url3_orig, 0, url3_orig.Length);

                file.Seek(34695652, SeekOrigin.Begin);
                file.Write(url_online, 0, url_online.Length);

                file.Seek(34695784, SeekOrigin.Begin);
                file.Write(url_online, 0, url_online.Length);

                file.Close();
            }
            else if (version == "3.19" && mode == "offline")
            {
                file.Seek(34695084, SeekOrigin.Begin);
                //47 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 15; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34695212, SeekOrigin.Begin);
                //46 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 14; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34695340, SeekOrigin.Begin);
                //51 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 19; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34695476, SeekOrigin.Begin);
                //40 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 8; i++)
                {
                    file.WriteByte(0);
                }
                file.Seek(34695608, SeekOrigin.Begin);
                //40 length
                file.Write(url_offline, 0, url_offline.Length);
                for (int i = 0; i < 8; i++)
                {
                    file.WriteByte(0);
                }

                file.Close();
            }
            else if (version == "3.19" && mode == "online")
            {
                file.Seek(34695084, SeekOrigin.Begin);
                file.Write(url1_orig, 0, url1_orig.Length);

                file.Seek(34695212, SeekOrigin.Begin);
                file.Write(url2_orig, 0, url2_orig.Length);

                file.Seek(34695340, SeekOrigin.Begin);
                file.Write(url3_orig, 0, url3_orig.Length);

                file.Seek(34695476, SeekOrigin.Begin);
                file.Write(url_online, 0, url_online.Length);

                file.Seek(34695608, SeekOrigin.Begin);
                file.Write(url_online, 0, url_online.Length);

                file.Close();
            }
        }
    }
}