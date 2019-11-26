
namespace Wangfs763.Cards.Models
{
    public abstract class BaseModal
    {
        public abstract string Name { get; }
        public abstract void Start();
        public abstract void Stop();
    }

    #region 串口模型

    /// <summary>
    /// 串口模型
    /// </summary>
    public abstract class SerialPortModal : BaseModal
    {
        internal ControlPanel.PortPanel Panel { get; set; }

        /// <summary>
        /// 是否使用事件接收数据，为 false 需要自己读取数据
        /// </summary>
        public abstract bool UseEvent { get; }
        /// <summary>
        /// 收到数据
        /// </summary>
        /// <param name="data">字节数据</param>
        public abstract void OnDataArrived(byte[] data);
        /// <summary>
        /// 缓存区数据大小
        /// </summary>
        public int BytesToRead { get { return this.Panel.BytesToRead; } }

        public void Read(byte[] data, int offset, int len) { this.Panel.Read(data, offset, len); }

        public void Read(byte[] data) { this.Panel.Read(data, 0, data.Length); }

        public int ReadByte() { return this.Panel.ReadByte(); }

        public void Write(byte[] data, int offset, int len) { this.Panel.Write(data, offset, len); }

        public void Write(params byte[] data) { this.Panel.Write(data, 0, data.Length); }

        public void Write(string text) { this.Panel.Write(text); }
    }

    class NullPortModal : SerialPortModal
    {
        public override string Name { get { return "Null"; } }

        public override bool UseEvent { get { return true; } }

        public override void OnDataArrived(byte[] data) { }

        public override void Start() { }

        public override void Stop() { }
    }

    #endregion 

    #region 网络模型

    /// <summary>
    /// 网络通讯模型
    /// </summary>
    public abstract class NetModal : BaseModal
    {
        internal ControlPanel.NetPanel m_Panel { get; set; }

        // UDP 方法
        /// <summary>
        /// 收到 UDP 数据
        /// </summary>
        /// <param name="remote">远端 IP 和 端口</param>
        /// <param name="data">收到的数据</param>
        public abstract void OnUdpDataArrived(System.Net.IPEndPoint remote, byte[] data);
        /// <summary>
        /// 发送 UDP 数据
        /// </summary>
        /// <param name="remote">远端 IP 和 端口</param>
        /// <param name="data">要发送的字节数据</param>
        public void SendUdpData(System.Net.IPEndPoint remote, byte[] data) { this.m_Panel.SendUdpData(remote, data); }
        /// <summary>
        /// 发送 UDP 数据
        /// </summary>
        /// <param name="remote">远端 IP 和 端口</param>
        /// <param name="data">要发送的字符串数据</param>
        public void SendUdpData(System.Net.IPEndPoint remote, string data) { this.m_Panel.SendUdpData(remote, data); }
        

        // TCP 服务方法
        /// <summary>
        /// 有 TCP 客户端连接 TCP 服务
        /// </summary>
        /// <param name="point">TCP 客户端 IP 和 端口</param>
        public abstract void OnClientConnect(System.Net.EndPoint point);
        /// <summary>
        /// 有 TCP 客户端断开连接
        /// </summary>
        /// <param name="point">TCP 客户端 IP 和 端口</param>
        public abstract void OnClientDisconnect(System.Net.EndPoint point);
        /// <summary>
        /// 收到 TCP 客户端数据
        /// </summary>
        /// <param name="point">TCP 客户端 IP 和 端口</param>
        /// <param name="data">收到的数据</param>
        public abstract void OnClientDataArrived(System.Net.EndPoint point, byte[] data);
        /// <summary>
        /// 向 TCP 客户端发送数据
        /// </summary>
        /// <param name="point">TCP 客户端 IP 和 端口</param>
        /// <param name="data">要发送的字节数据</param>
        public void SendClientData(System.Net.EndPoint point, byte[] data) { this.m_Panel.SendClientData(point, data); }
        /// <summary>
        /// 向 TCP 客户端发送数据
        /// </summary>
        /// <param name="point">TCP 客户端 IP 和 端口</param>
        /// <param name="data">要发送的字符串数据</param>
        public void SendClientData(System.Net.EndPoint point, string data) { this.m_Panel.SendClientData(point, data); }
        

        // TCP 客户端方法
        /// <summary>
        /// TCP 客户端收到数据
        /// </summary>
        /// <param name="data"></param>
        public abstract void OnClientDataArrived(byte[] data);
        /// <summary>
        /// 向 TCP 服务发送数据
        /// </summary>
        /// <param name="data">要发送的字节数据</param>
        public void SendClientData(byte[] data) { this.m_Panel.SendClientData(data); }
        /// <summary>
        /// 向 TCP 服务发送数据
        /// </summary>
        /// <param name="data">要发送的字符串数据</param>
        public void SendClientData(string data) { this.m_Panel.SendClientData(data); }
    }

    class NullNetModal : NetModal
    {
        public override void OnUdpDataArrived(System.Net.IPEndPoint remote, byte[] data) { }

        public override void OnClientConnect(System.Net.EndPoint point) { }

        public override void OnClientDisconnect(System.Net.EndPoint point) { }

        public override void OnClientDataArrived(System.Net.EndPoint point, byte[] data) { }

        public override void OnClientDataArrived(byte[] data) { }

        public override string Name { get { return "Null"; } }

        public override void Start() { }

        public override void Stop() { }
    }

    #endregion
}
