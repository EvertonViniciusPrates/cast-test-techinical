using Cast.Model;
using System.Collections.Generic;

namespace Cast.Util.Results
{
    public class ResultSet<T> where T : EntityBase
    {
        public T Obj { get; set; }
        public List<T> ObjList { get; set; }
        public string Msg { get; set; }

        public ResultSet(T obj, string msg)
        {
            Obj = obj;
            Msg = msg;
        }

        public ResultSet<T> Result(T t, string msg) {
            return new ResultSet<T>(t, msg);
        }

        public ResultSet(List<T> objList, string msg)
        {
            ObjList = objList;
            Msg = msg;
        }

        public ResultSet<T> Result(List<T> t, string msg)
        {
            return new ResultSet<T>(t, msg);
        }
    }
}
