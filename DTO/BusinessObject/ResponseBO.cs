using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BusinessObject
{
    public class ResponseBO<T>
    {
        private T _returnObject;
        public bool IsSuccess { get; set; }
        public string ResponseMessage { get; set; }

        public T ReturnedObject
        {
            get
            {
                return _returnObject;
            }
            set
            {
                _returnObject = value;
            }
        }

        //private class ReturnedObject<T>
        //{
        //    private T _value;

        //    public T Value
        //    {
        //        get
        //        {
        //            return _value
        //        }
        //    }
        //}
    }
}
