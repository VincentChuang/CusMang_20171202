namespace CusMang.Models
{
    using Custom_DataType;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    //自訂 客戶資料 模型驗證
    [MetadataType(typeof(客戶資料MetaData))]
    //public partial class 客戶資料 : IValidatableObject {    //資料模型驗證 ， 需 extends IValidatableObject
    public partial class 客戶資料 {    //資料模型驗證 ， 需 extends IValidatableObject
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
        //
        //    #region 實作一個「自訂輸入驗證屬性」可驗證「手機」的電話格式必須為 "\d{4}-\d{6}" 的格式 ( e.g. 0911-111111 )
        //    Regex _regex = new Regex(@"\d{4}-\d{6}");
        //    if(! _regex.IsMatch(this.電話)) {
        //        yield return new ValidationResult("電話格式為『0911-111111』", new string[] { "電話" });
        //    }
        //    #endregion
        //    //throw new NotImplementedException();
        //}
    }

    public partial class 客戶資料MetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        
        [StringLength(8, ErrorMessage="欄位長度不得大於 8 個字元")]
        [Required]
        public string 統一編號 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [自訂行動電話驗證(ErrorMessage= "電話格式錯誤，應為『0911-111111』")]
        public string 電話 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 傳真 { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string 地址 { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "請輸入正確的電子信箱")]
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Remote("RemoteEmailCheck", "Customer", HttpMethod = "POST", ErrorMessage = "此Email已申請過會員，如忘記密碼可按忘記密碼取回密碼")]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 客戶分類 { get; set; }

        [Required]
        public Nullable<bool> 是否已刪除 { get; set; }
    
        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }
}
