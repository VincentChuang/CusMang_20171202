using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CusMang.Models.Custom_DataType
{
    public class 自訂行動電話驗證Attribute : DataTypeAttribute
    {

        //* 實作一個「自訂輸入驗證屬性」可驗證「手機」的電話格式必須為 "\d{4}-\d{6}" 的格式 ( e.g. 0911-111111 )
        private Regex _regex = new Regex(@"\d{4}-\d{6}");
        
        public 自訂行動電話驗證Attribute() : base(DataType.Text) { }   //文字類型 輸入
        //打 ov + TAB + 空白鍵 ---> 選擇 可 override function
        public override bool IsValid(object value) {
            if (value == null)
                return true;
            bool bln = _regex.IsMatch(value.ToString());
            return bln;
        }
        
    }
}