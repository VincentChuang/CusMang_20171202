using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CusMang.Models.DataType
{
    public class 行動電話Attribute : DataTypeAttribute
    {

        //public 行動電話Attribute() : base(DataType.)   //文字類型 輸入
        //{ }

        public 行動電話Attribute() : base(DataType.Text)
        {

        }

        //打 ov + TAB + 空白鍵 ---> 選擇 可 override function
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            string str = (string)value;
            if (str.Contains("Will"))
                return true;
            else
                return false;
            //return base.IsValid(value);
        }

    }
}