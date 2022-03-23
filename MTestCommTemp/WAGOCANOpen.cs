using System;

namespace WAGOTemplate
{
    /// <summary>
    /// 对数组提供扩展方法
    /// </summary>
    static class ArrayExtension
    {
        /// <summary>
        /// 截取一部分数组
        /// </summary>
        /// <typeparam name="T">数组类型</typeparam>
        /// <param name="data">要截取的数组</param>
        /// <param name="index">开始截取的索引</param>
        /// <param name="length">截取的长度</param>
        /// <returns>截取后的数组</returns>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static string Format(this uint[] data)
        {
            string rt = "";
            foreach (var i in data)
            {
                rt += i.ToString("X8") + ",";
            }
            var index = rt.LastIndexOf(',');
            if (index >= 0)
                rt = rt.Remove(index);
            return rt;
        }
    }

    static class WAGOCANOpen
    {
        public static int CalTPDOLength(int di, int ai, int uc)
        {
            return (di > 0 ? 1 : 0) + (int)(ai / 4) + (ai % 4 > 0 ? 1 : 0) + uc;
        }

        public static int CalRPDOLength(int doo, int ao)
        {
            return (doo > 0 ? 1 : 0) + (int)(ao / 4) + (ao % 4 > 0 ? 1 : 0);
        }

        //每个设备最多拥有24个TPDO和RPDO，实际上可以用于25个，但最后的不好分配。。
        private static readonly uint[] TPDOID = { 0x181,0x281,0x381,0x481,
                                                0x195,0x295,0x395,0x495,
                                                0x1A9,0x2A9,0x3A9,0x4A9,
                                                0x1BD,0x2BD,0x3BD,0x4BD,
                                                0x1D1,0x2D1,0x3D1,0x4D1,
                                                0x1E5,0x2E5,0x3E5,0x4E5,};
        private static readonly uint[] RPDOID = { 0x201,0x301,0x401,0x501,
                                                0x215,0x315,0x415,0x515,
                                                0x229,0x329,0x429,0x529,
                                                0x23D,0x33D,0x43D,0x53D,
                                                0x251,0x351,0x451,0x551,
                                                0x265,0x365,0x465,0x565, };

        public static SlaveConfig CreateSlaveConfig(int di, int doo, int ai, int ao, int uc, string name, string des = "")
        {
            //创建临时变量，并初始化
            Signal signal = new Signal();
            PDO pdo = new PDO();
            SlaveConfig slaveConfig = new SlaveConfig();

            signal.Name = "";
            signal.VarName = "";
            signal.Description = "";
            signal.Gain = 1;
            signal.Offset = 0;
            signal.StartBit = 0;
            signal.NumberOfBits = 1;
            signal.ByteOrder = ByteOrderEnum.LittleEndian;
            signal.DataType = DataTypeEnum.Default;

            pdo.Time = 0.1;
            pdo.PDOMapping = "";

            slaveConfig.PDOs = new PDO[CalTPDOLength(di, ai, uc) + CalRPDOLength(doo, ao)];
            slaveConfig.Description = des;
            slaveConfig.EmergencyEnable = false;
            slaveConfig.Factor = 25;
            slaveConfig.GuardingTime = 200;
            slaveConfig.NodeID = 1;
            slaveConfig.Name = name;
            slaveConfig.Watchdog = "";
            slaveConfig.EmergencyBufferSize = 1;
            slaveConfig.NodeGuardingorHearbeat = NodeGuardingorHearbeatEnum.NodeGuarding;
            slaveConfig.ResetNodeOnStart = true;
            slaveConfig.StartNode = true;
            slaveConfig.UseDefaultID = false;

            pdo.Extended = false;
            pdo.Type = FrameTypeEnum.CANData;

            int tpdoCount = 0;
            int rpdoCount = 0;
            if (di > 0)
            {
                //创建临时Signal数组
                Signal[] signals = new Signal[di];
                for (int i = 0; i < di; i++)
                {
                    signal.Name = $"DI{i + 1:d2}";
                    signal.StartBit = i;
                    signal.NumberOfBits = 1;
                    signal.DataType = DataTypeEnum.BOOL;

                    signals[i] = signal;
                }
                //替换frame中的数组
                pdo.Identifier = TPDOID[tpdoCount];   //默认第一个TPDO的ID
                pdo.Signals = signals;
                pdo.PDOType = PDOTypeEnum.TPDO;
                //是否应该使用静态定义PDOMaping？？
                var pdom = new uint[(int)(di / 8) + (di % 8 > 0 ? 1 : 0)];
                for (int i = 0; i < di; i += 8)
                {
                    pdom[i / 8] = 0x20000108 + 0x100 * (uint)(i / 8);
                }
                pdo.PDOMapping = pdom.Format();
                pdo.Name = $"TPDO{tpdoCount + 1:d3}";
                pdo.Description = "DI Channels";

                //添加从站的TPDO数组
                slaveConfig.PDOs[tpdoCount + rpdoCount] = pdo;
                tpdoCount++;
            }
            if (ai > 0)
            {
                Signal[] signals = new Signal[ai];
                for (int i = 0; i < ai; i++)
                {
                    signal.Name = $"AI{i + 1:d3}";
                    signal.StartBit = (i * 16) % 64;
                    signal.NumberOfBits = 16;
                    signal.DataType = DataTypeEnum.U32;
                    signals[i] = signal;
                }
                int len = (int)(ai / 4) + (ai % 4 > 0 ? 1 : 0);

                //PDO的长度
                for (int i = 0; i < len; i++)
                {
                    var leng = 4;
                    //每个PDO的signal的长度
                    if (i * 4 + 4 > signals.Length)
                    {
                        if (i * 4 < signals.Length)
                            leng = signals.Length - i * 4;
                        else
                            leng = 0;
                    }
                    pdo.Identifier = TPDOID[tpdoCount];   //为不同的PDO生成不同的ID
                    pdo.Signals = signals.SubArray(i * 4, leng);    //每次截取4条,最后一次不一定是4条
                    pdo.PDOType = PDOTypeEnum.TPDO;
                    var pdom = new uint[leng];
                    for (int j = 0; j < leng; j++)
                    {
                        pdom[j] = 0x24000110 + 0x100 * (uint)(j + i * 4);   //按顺序maping
                    }
                    pdo.PDOMapping = pdom.Format();
                    pdo.Name = $"TPDO{tpdoCount + 1:d3}";
                    pdo.Description = "AI Channels";
                    slaveConfig.PDOs[tpdoCount + rpdoCount] = pdo;
                    tpdoCount++;
                }
            }
            if (uc > 0)
            {
                Signal[] signals = new Signal[uc];
                for (int i = 0; i < uc; i++)
                {
                    signal.Name = $"UC{i + 1:d2}";
                    signal.StartBit = 0;
                    signal.NumberOfBits = 48;
                    signal.DataType = DataTypeEnum.U64;
                    signals[i] = signal;
                }
                for (int i = 0; i < uc; i++)
                {
                    pdo.Identifier = TPDOID[tpdoCount];   //为不同的PDO生成不同的ID
                    pdo.Signals = new[] { signals[i] };
                    pdo.PDOType = PDOTypeEnum.TPDO;
                    var pdom = new uint[1];
                    pdom[0] = 0x32000130 + 0x100 * (uint)i;   //按顺序maping
                    pdo.PDOMapping = pdom.Format();
                    pdo.Name = $"TPDO{tpdoCount + 1:d3}";
                    pdo.Description = "UC Channels";
                    slaveConfig.PDOs[tpdoCount + rpdoCount] = pdo;
                    tpdoCount++;
                }
            }

            if (doo > 0)
            {
                //创建临时Signal数组
                Signal[] signals = new Signal[doo];
                for (int i = 0; i < doo; i++)
                {
                    signal.Name = $"DO{i + 1:d2}";
                    signal.StartBit = i;
                    signal.NumberOfBits = 1;
                    signal.DataType = DataTypeEnum.BOOL;

                    signals[i] = signal;
                }
                //替换frame中的数组
                pdo.Identifier = RPDOID[rpdoCount];
                pdo.Signals = signals;
                pdo.PDOType = PDOTypeEnum.RPDO;
                var pdom = new uint[(int)(doo / 8) + (doo % 8 > 0 ? 1 : 0)];
                for (int i = 0; i < doo; i += 8)
                {
                    pdom[i / 8] = 0x21000108 + 0x100 * (uint)(i / 8);
                }
                pdo.PDOMapping = pdom.Format();
                pdo.Name = $"RPDO{rpdoCount + 1:d3}";
                pdo.Description = "DO Channels";


                //添加从站的RPDO数组
                slaveConfig.PDOs[tpdoCount + rpdoCount] = pdo;
                rpdoCount++;
            }
            if (ao > 0)
            {
                Signal[] signals = new Signal[ao];
                for (int i = 0; i < ao; i++)
                {
                    signal.Name = $"AO{i + 1:d3}";
                    signal.StartBit = (i * 16) % 64;
                    signal.NumberOfBits = 16;
                    signal.DataType = DataTypeEnum.U32;
                    signals[i] = signal;
                }
                int len = (int)(ao / 4) + (ao % 4 > 0 ? 1 : 0);
                for (int i = 0; i < len; i++)
                {
                    var leng = 4;
                    //每个PDO的signal的长度
                    if (i * 4 + 4 > signals.Length)
                    {
                        if (i * 4 < signals.Length)
                            leng = signals.Length - i * 4;
                        else
                            leng = 0;
                    }

                    pdo.Identifier = RPDOID[rpdoCount];   //为不同的PDO生成不同的ID
                    pdo.Signals = signals.SubArray(i * 4, leng);
                    pdo.PDOType = PDOTypeEnum.RPDO;
                    var pdom = new uint[leng];
                    for (int j = 0; j < leng; j++)
                    {
                        pdom[j] = 0x25000110 + 0x100 * (uint)(j + i * 4);   //按顺序maping
                    }
                    pdo.PDOMapping = pdom.Format();
                    pdo.Name = $"RPDO{rpdoCount + 1:d3}";
                    pdo.Description = "AO Channels";
                    slaveConfig.PDOs[tpdoCount + rpdoCount] = pdo;
                    rpdoCount++;
                }
            }

            return slaveConfig;
        }
    }
}
