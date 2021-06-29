using System.ComponentModel;

namespace EIPTemplate
{
    static class WAGOEIP
    {
        public static RemoteDevice CreateSlaveConfig(int di, int doo, int ai, int ao, int uc, string name, string des = "")
        {
            var remoteDevice = new RemoteDevice();
            remoteDevice.IPAddress = "192.168.1.1";
            remoteDevice.CycleTime = 100;
            remoteDevice.Name = name;
            remoteDevice.Description = des;
            remoteDevice.O2TBytes = (ushort)CalRPDOBytes(doo, ao, uc);                                                               //O\T分别是什么
            remoteDevice.T2OBytes = (ushort)CalTPDOBytes(di, ai, uc);
            remoteDevice.EIPO2T = new EIPConfig()
            {
                ClassID = 4,
                AttributeID = 3,
                InstanceID = 101  
            };
            remoteDevice.EIPT2O = new EIPConfig()
            {
                ClassID = 4,
                AttributeID = 3,
                InstanceID = 104
            };
            var signals = new BindingList<Signal>();
            remoteDevice.Signals = signals;
            //input
            int startBit = 0;
            for (int i = 0; i < ai; i++)
            {
                signals.Add(new Signal()
                {
                    SignalType = SignalTypeEnum.Input,
                    Name = "AI" + i,
                    ByteOrder = ByteOrderEnum.LittleEndian,
                    DataType = DataTypeEnum.I16,
                    StartBit = startBit,
                    NumberOfBits = 16,
                });
                startBit += 16;
            }
            //uc 6个字节，前两个是状态后两个是计数器值
            for (int i = 0; i < uc; i++)
            {
                signals.Add(new Signal()
                {
                    SignalType = SignalTypeEnum.Input,
                    Name = "UC" + i,
                    Description = "Status",
                    ByteOrder = ByteOrderEnum.LittleEndian,
                    DataType = DataTypeEnum.I16,
                    StartBit = startBit,
                    NumberOfBits = 16,
                });
                startBit += 16;
                signals.Add(new Signal()
                {
                    SignalType = SignalTypeEnum.Input,
                    Name = "UC" + i,
                    Description = "Value",
                    ByteOrder = ByteOrderEnum.LittleEndian,
                    DataType = DataTypeEnum.U32,
                    StartBit = startBit,
                    NumberOfBits = 32,
                });
                startBit += 32;
            }
            for (int i = 0; i < di; i++)
            {
                signals.Add(new Signal()
                {
                    SignalType = SignalTypeEnum.Input,
                    Name = "DI" + i,
                    ByteOrder = ByteOrderEnum.LittleEndian,
                    DataType = DataTypeEnum.BOOL,
                    StartBit = startBit,
                    NumberOfBits = 1,
                });
                startBit += 1;
            }

            //output
            startBit = 0;
            for (int i = 0; i < ao; i++)
            {
                signals.Add(new Signal()
                {
                    SignalType = SignalTypeEnum.Output,
                    Name = "AO" + i,
                    ByteOrder = ByteOrderEnum.LittleEndian,
                    DataType = DataTypeEnum.I16,
                    StartBit = startBit,
                    NumberOfBits = 16,
                });
                startBit += 16;
            }
            //uc 6个字节，前两个是状态后两个是计数器值
            for (int i = 0; i < uc; i++)
            {
                signals.Add(new Signal()
                {
                    SignalType = SignalTypeEnum.Output,
                    Name = "UC" + i,
                    Description = "Control",
                    ByteOrder = ByteOrderEnum.LittleEndian,
                    DataType = DataTypeEnum.I16,
                    StartBit = startBit,
                    NumberOfBits = 16,
                });
                startBit += 16;
                signals.Add(new Signal()
                {
                    SignalType = SignalTypeEnum.Output,
                    Name = "UC" + i,
                    Description = "SetValue",
                    ByteOrder = ByteOrderEnum.LittleEndian,
                    DataType = DataTypeEnum.U32,
                    StartBit = startBit,
                    NumberOfBits = 32,
                });
                startBit += 32;
            }
            for (int i = 0; i < doo; i++)
            {
                signals.Add(new Signal()
                {
                    SignalType = SignalTypeEnum.Output,
                    Name = "DO" + i,
                    ByteOrder = ByteOrderEnum.LittleEndian,
                    DataType = DataTypeEnum.BOOL,
                    StartBit = startBit,
                    NumberOfBits = 1,
                });
                startBit += 1;
            }
            return remoteDevice;
        }

        public static int CalTPDOBytes(int di, int ai, int uc)
        {
            return di / 8 + (di % 8 > 0 ? 1 : 0) + ai * 2 + uc * 6 + 1;//输入多一个状态字
        }

        public static int CalRPDOBytes(int doo, int ao, int uc)
        {
            return doo / 8 + (doo % 8 > 0 ? 1 : 0) + ao * 2 + uc * 6;
        }
    }
}
