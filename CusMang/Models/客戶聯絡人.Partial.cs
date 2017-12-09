namespace CusMang.Models
{
    using Custom_DataType;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    ////自訂 客戶資料 模型驗證
    //[MetadataType(typeof(客戶資料MetaData))]
    ////public partial class 客戶資料 : IValidatableObject {    //資料模型驗證 ， 需 extends IValidatableObject
    //public partial class 客戶資料 {    //資料模型驗證 ， 需 extends IValidatableObject
    //    //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
    //    //
    //    //    #region 實作一個「自訂輸入驗證屬性」可驗證「手機」的電話格式必須為 "\d{4}-\d{6}" 的格式 ( e.g. 0911-111111 )
    //    //    Regex _regex = new Regex(@"\d{4}-\d{6}");
    //    //    if(! _regex.IsMatch(this.電話)) {
    //    //        yield return new ValidationResult("電話格式為『0911-111111』", new string[] { "電話" });
    //    //    }
    //    //    #endregion
    //    //    //throw new NotImplementedException();
    //    //}
    //}



    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject {    // : IValidatableObject

        private CusDBEntities db = new CusDBEntities();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {

            //實作「客戶聯絡人」時，同一個客戶下的聯絡人，其 Email 不能重複。
            bool bln = !db.客戶聯絡人
                .Where(x => x.客戶Id == this.客戶Id)
                .Where(x => x.Email == this.Email)
                .Any();
            if (bln == false) {
                yield return new ValidationResult("同一個客戶下的聯絡人，其 Email 重複", new string[] { "Email" });
            }
            
            //throw new NotImplementedException();
        }

    }

    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }

        [Required]
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [DataType(DataType.EmailAddress, ErrorMessage = "請輸入正確的電子信箱")]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [自訂行動電話驗證(ErrorMessage = "電話格式錯誤，應為『0911-111111』")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }

        [Required]
        public Nullable<bool> 是否已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
