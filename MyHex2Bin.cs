using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Hex2Bin
{
    /// <summary>
    /// hex文件转bin文件 
    /// hex格式解析：<0x3a>[数据长度1Byte][数据地址2Byte][数据类型1Byte][数据nByte][校验1Byte]<0x0d><0x0a>
    /// </summary>
    public static class MyHex2Bin
    {
        /// <summary>
        /// hex文件段信息结构体
        /// </summary>
        public class Section
        {
            public uint startAddr = new uint();
            public uint endAddr = new uint();
            public List<byte> data = new List<byte>();
            public string filePath;
        }

        /// <summary>
        /// hex 数据类型
        /// </summary>
        enum INTEL_COMMAND : byte
        {
            UNKNOWN = 0xFF,
            /// <summary>
            /// Data Record 数据
            /// </summary>
            DATA = 0x00,
            /// <summary>
            /// End of File Record 文件结束标志
            /// </summary>
            EOF = 0x01,
            /// <summary>
            /// Extended Segment Address Record 延伸段地址
            /// </summary>
            EXT_SEGMENT_ADDR = 0x02,
            /// <summary>
            /// Start Segment Address Record   起始延伸地址
            /// </summary>
            SEGMENT_ADDR = 0x03,
            /// <summary>
            /// Extended Linear Address Record 扩展线性地址 也就是基地址
            /// </summary>
            EXTEND_ADDR = 0x04,
            /// <summary>
            /// Start Linear Address Record       程序起始地址也就是程序入口地址(main)
            /// </summary>
            LINEAR_ADDR = 0x05,
            DATA_LOOP = 0x10
        }

        /// <summary>
        /// 根据hex文件生成bin文件
        /// </summary>
        /// <param name="outBinFilePath">bin文件路径</param>
        /// <param name="encoding">编码格式</param>
        /// <param name="ignoreByte">占位符 空白的地址填</param>
        /// <param name="sections">hex文件信息</param>
        /// <param name="log">日志信息</param>
        /// <param name="inHexFilePath">hex文件路径</param>
        public static void Conver(string outBinFilePath, Encoding encoding, byte ignoreByte, ref List<Section> sections, out string log, params string[] inHexFilePath)
        {
            GetAddrInfo(encoding, ref sections, out log, inHexFilePath);

            //输出文件
            WriteBinFile(outBinFilePath, encoding, ignoreByte, sections);
        }

        /// <summary>
        /// 根据hex文件生成bin文件
        /// </summary>
        /// <param name="outBinFilePath">bin文件路径</param>
        /// <param name="inHexFilePath">hex文件路径</param>
        public static void Conver(string outBinFilePath, params string[] inHexFilePath)
        {
            List<Section> sections = new List<Section>();
            GetAddrInfo(Encoding.Default, ref sections, out string log, inHexFilePath);

            //输出文件
            WriteBinFile(outBinFilePath, Encoding.Default, 0, sections);
        }

        /// <summary>
        /// 获取地址信息
        /// </summary>
        /// <param name="encoding">编码格式</param>
        /// <param name="sections">hex文件信息</param>
        /// <param name="log">日志</param>
        /// <param name="inHexFilePath">hex文件路径</param>
        public static void GetAddrInfo(Encoding encoding, ref List<Section> sections, out string log, params string[] inHexFilePath)
        {
            //加载hex文件
            LoadHex(encoding, ref sections, out log, inHexFilePath);

            //检查地址冲突
            if (!CheckAddr(sections, out string str))
            {
                log += str;
            }
        }

        static void LoadHex(Encoding encoding, ref List<Section> sections, out string log, params string[] inHexFilePath)
        {

            log = "";
            foreach (var item in inHexFilePath)
            {
                //文件存在并且以.hex结尾
                if (File.Exists(item) && Path.GetExtension(item).ToLower().Equals(".hex"))
                {
                    #region 解析一个hex文件
                    //读取hex文件
                    string[] hexFileAllLines = File.ReadAllLines(item, encoding);
                    List<Section> tempSections = new List<Section>();
                    uint extend_address = 0, start_address = 0, segment_address = 0, linear_address = 0;
                    uint count = 0, address = 0;
                    byte dataType = 0;
                    INTEL_COMMAND command = INTEL_COMMAND.UNKNOWN;
                    for (int line = 0; line < hexFileAllLines.Length; line++)
                    {
                        bool fail = false;
                        string hexFileLine = hexFileAllLines[line];
                        //hex文件每行最少11个字符并且以":"起始
                        if (hexFileLine.Length >= 11 && hexFileLine.StartsWith(":") && CheckSum(hexFileLine))
                        {
                            #region 解析一行hex文件 获取其长度、地址、数据类型、校验和信息
                            fail |= !uint.TryParse(hexFileLine.Substring(1, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out count);
                            fail |= !uint.TryParse(hexFileLine.Substring(3, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out address);
                            fail |= !byte.TryParse(hexFileLine.Substring(7, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out dataType);
                            command = (INTEL_COMMAND)dataType;
                            if (fail)
                            {
                                log += "文件:" + item + " 第" + line + "行 不符合hex文件格式！解析失败\r\n";
                                break;
                            }
                            #endregion
                        }
                        else
                        {
                            log += "文件:" + item + " 第" + line + "行 不符合hex文件格式！\r\n";
                            continue;
                        }

                        switch (command)
                        {
                            case INTEL_COMMAND.EOF:
                                sections.AddRange(tempSections);
                                log += "文件:" + item + " 解析完成 共解析:" + line + "行\r\n";
                                line = hexFileAllLines.Length;
                                break;
                            case INTEL_COMMAND.DATA:
                            #region 正常数据接收
                            case INTEL_COMMAND.DATA_LOOP:
                                int idx = 9; //hex文件 第九个字符开始才是数据
                                for (; !fail && count > 0; --count)
                                {
                                    fail = !byte.TryParse(hexFileLine.Substring(idx, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte data);

                                    if (!fail && tempSections.Count > 0)
                                    {
                                        if (tempSections[tempSections.Count - 1].startAddr.Equals(segment_address) || tempSections[tempSections.Count - 1].startAddr.Equals(extend_address))
                                        {
                                            segment_address = 0;
                                            extend_address = 0;
                                            tempSections[tempSections.Count - 1].filePath = item;
                                            tempSections[tempSections.Count - 1].startAddr += address;
                                            tempSections[tempSections.Count - 1].endAddr = tempSections[tempSections.Count - 1].startAddr;
                                        }
                                        tempSections[tempSections.Count - 1].data.Add(data);
                                        tempSections[tempSections.Count - 1].endAddr++;
                                    }
                                    else
                                    {
                                        fail = true;
                                    }
                                    idx += 2;
                                }
                                break;
                            #endregion
                            case INTEL_COMMAND.EXT_SEGMENT_ADDR: // Extended Segment Address Record
                                #region Extended segment address record
                                if (count != 2 || hexFileLine.Length != 15)
                                {
                                    fail = true;
                                    log += string.Format("Bad Extended segment address record line {0}.\r\n", line);
                                }
                                else
                                {
                                    fail |= !uint.TryParse(hexFileLine.Substring(9, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out segment_address);
                                    if (fail)
                                        log += string.Format("Bad Start Address records line {0}.\r\n", line);
                                    else
                                    {
                                        segment_address <<= 4;
                                        tempSections.Add(new Section());
                                        tempSections[tempSections.Count - 1].startAddr = segment_address;
                                    }

                                }
                                break;
                            #endregion
                            case INTEL_COMMAND.SEGMENT_ADDR:
                                #region Start Segment Address Record
                                if (count != 4)
                                {
                                    log += string.Format("Bad Start Segment records line {0}.\r\n", line);
                                }
                                else
                                {
                                    fail |= !uint.TryParse(hexFileLine.Substring(9, 8), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out start_address);
                                    if (fail)
                                        log += string.Format("Bad Start Segment records line {0}.\r\n", line);
                                    else
                                        log += string.Format("Start Segment: {0:X}\r\n", start_address);
                                }
                                break;
                            #endregion
                            case INTEL_COMMAND.EXTEND_ADDR:
                                #region Extended Linear Address Record
                                if (hexFileLine.Length != 15)
                                {
                                    log += string.Format("Bad Extended Address records line {0}.\r\n", line);
                                    fail = true;
                                }
                                else
                                {
                                    fail |= !uint.TryParse(hexFileLine.Substring(9, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out extend_address);
                                    if (!fail)
                                    {
                                        extend_address = extend_address << 16;
                                        tempSections.Add(new Section());
                                        tempSections[tempSections.Count - 1].startAddr = extend_address;
                                    }
                                }
                                break;
                            #endregion
                            case INTEL_COMMAND.LINEAR_ADDR:
                                #region Start Linear Address Record
                                if (count != 4)
                                {
                                    log += string.Format("Bad Linear Address record line {0}.\r\n", line);
                                }
                                else
                                {
                                    fail |= !uint.TryParse(hexFileLine.Substring(9, 8), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out linear_address);
                                    if (fail)
                                        log += string.Format("Bad Linear Address record line {0}.\r\n", line);
                                    else
                                        log += string.Format("Linear Address: 0x{0:X}", linear_address);
                                }
                                break;
                            #endregion
                            default:
                                log += string.Format("Bad command {0} at line {1}.\r\n", command, line);
                                fail = true;
                                break;
                        }
                        if (fail)
                        {
                            log += "文件:" + item + " 第" + line + "行 不符合hex文件格式！解析失败\r\n";
                            break;
                        }
                    }


                    #endregion
                }
                else
                {
                    log += "文件:" + item + "不存在或不是.hex文件！\r\n";
                }
            }
        }

        /// <summary>
        /// 校验hex文件一行数据 
        /// </summary>
        /// <param name="hexLine">hex一行数据</param>
        /// <returns>true 校验成功</returns>
        static bool CheckSum(string hexLine)
        {
            bool fail = false;
            byte sum = 0;
            byte data = 0;
            for (int i = 1; i < hexLine.Length - 2; i += 2)
            {
                fail |= !byte.TryParse(hexLine.Substring(i, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out data);
                sum += data;
            }

            fail |= !byte.TryParse(hexLine.Substring(hexLine.Length - 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out data);

            if ((byte)(0x100 - sum) == data && !fail)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检查地址是否冲突
        /// </summary>
        /// <param name="sections"></param>
        /// <param name="log">日志信息</param>
        /// <returns>true 不冲突</returns>
        static bool CheckAddr(List<Section> sections, out string log)
        {
            log = "";
            bool err = true;
            //排序
            sections.Sort((x, y) => x.startAddr.CompareTo(y.startAddr));

            for (int i = 0; i < sections.Count; i++)
            {
                if (sections[i].startAddr + sections[i].data.Count != sections[i].endAddr)
                {
                    log += string.Format("地址块：{0:x}--{1:x} 数据出错\r\n", sections[i].startAddr, sections[i].endAddr);
                    err = false;
                }
            }

            for (int i = 1; i< sections.Count; i++)
            {
                if(sections[i].startAddr < sections[i-1].endAddr)
                {
                    log += string.Format("地址冲突：{0:x}--{1:x} 和 {2:x}--{3:x}\r\n", sections[i - 1].startAddr, sections[i - 1].endAddr, sections[i].startAddr, sections[i].endAddr);
                    err = false;
                }
            }
            return err;
        }

        static void WriteBinFile(string outBinFilePath, Encoding encoding, byte ignoreByte, List<Section> sections)
        {
            uint startAddr = sections[0].startAddr;
            int size = (int)(sections[sections.Count - 1].endAddr - startAddr);
            if(size > 1024*1024*20)
            {
                return;
            }
            byte[] binFile = new byte[size];
            ArrayList.Repeat(ignoreByte, size).CopyTo(binFile);

            foreach (var item in sections)
            {
                item.data.ToArray().CopyTo(binFile, item.startAddr - startAddr);
            }

            using (StreamWriter file = new StreamWriter(outBinFilePath, false, encoding))
            {
                file.Write(binFile);
            }
        }
    }
}
