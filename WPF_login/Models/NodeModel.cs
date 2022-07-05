using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_login.Models
{
    public class NodeModel
    {
        public string Id { get; set; }
        /*
         0 : bình thường
         1 : sự cố
         2 : báo nguy cơ cháy
         */
        public int status { get; set; }
        /*
         0 báo nhiệt
         1 báo gas
         2 báo khói
         3 cảm biến độ ẩm
         */
        public int function { get; set; }
        public List<setData> listData { get; set; }
        public string location { get; set; }

    }

    public class setData
    {
        public long Time { get; set; }
        public double value { get; set; }
    }
    public class nodeSum
    {
        public setData nhiet_do { get; set; }//0
        public setData gas { get; set; }//1
        public setData khoi { get; set; }//2
        public setData do_am { get; set; }//3
    }
    public class Obj
    {

        public List<NodeModel> Value { get; set; }
        public string Action { get; set; }
    }
    public class ObjLog
    {

        public ObjLogin Value { get; set; }
        public string Action { get; set; }
    }
    public class ObjSum
    {

        public nodeSumlstString Value { get; set; }
        public string Action { get; set; }
    }
    public class nodeSumlst
    {
        public List<setData> nhiet_do { get; set; }//0
        public List<setData> gas { get; set; }//1
        public List<setData> khoi { get; set; }//2
        public List<setData> do_am { get; set; }//3
    }
    public class setDataString
    {
        public string Time { get; set; }
        public double value { get; set; }
        public setDataString(string time, double value)
        {
            Time = time;
            this.value = value;
        }
    }
    public class nodeSumlstString
    {
       public nodeSum sum { get; set; }
        public List<setDataString> nhiet_do { get; set; }//0
        public List<setDataString> gas { get; set; }//1
        public List<setDataString> khoi { get; set; }//2
        public List<setDataString> do_am { get; set; }//3

    }
    public class Building
    {
        public string Id { get; set; }
        public List<Flooring> floors { get; set; }
    }
    public class Flooring {
        public string Id { get; set; }
        public List<Room> rooms { get; set; }

    }
    public class Room
    {
        public string Id { get; set; }
        public List<string> NodeIds { get; set; }

    }
    public class ObjConvert
    {

        public object Value { get; set; }
        public string Action { get; set; }
    }

}
