using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace WAGOTemplate
{
    public struct CANConfig
    {
        public string CANCard;
        public string SerialNumber;
        public ulong BaudRate;
        public SlaveConfig[] SlaveConfig;
    }

    public struct Signal
    {
        public string Name;
        public string VarName;
        public string Description;
        public ByteOrderEnum ByteOrder;
        public DataTypeEnum DataType;
        public int StartBit;
        public int NumberOfBits;
        public double Gain;
        public double Offset;
    }

    public struct Frame
    {
        public uint Identifier;
        public bool Extended;
        public FrameTypeEnum Type;
        public Signal[] Signals;
    }

    public struct PDO
    {
        public PDOTypeEnum PDOType;
        public double Time;
        public string PDOMaping;
        public string Name;
        public string Description;
        public uint Identifier;
        public bool Extended;
        public FrameTypeEnum Type;
        public Signal[] Signals;
    }

    public struct SlaveConfig
    {
        public int NodeID;
        public bool EmergencyEnable;
        public ushort EmergencyBufferSize;
        public NodeGuardingorHearbeatEnum NodeGuardingorHearbeat;
        public ushort GuardingTime;
        public byte Factor;
        public bool ResetNodeOnStart;
        public bool StartNode;
        public bool UseDefaultID;
        public string Name;
        public string Watchdog;
        public string Description;
        public PDO[] PDOs;
    }

    public enum ByteOrderEnum
    {
        BigEndian, LittleEndian
    }

    public enum DataTypeEnum
    {
        Default, BOOL, U8, I8, U16, I16, U32, I32, U64, I64, Float, Double
    }

    public enum FrameTypeEnum
    {
        CANData, CANRemote, CANBusError, CAN20Data, CANFDData, CANFDBRS, J1939, Delay, LogTrigger, StartTrigger
    }

    public enum PDOTypeEnum
    {
        RPDO, TPDO
    }

    public enum NodeGuardingorHearbeatEnum
    {
        None, NodeGuarding, Hearbeat
    }
}