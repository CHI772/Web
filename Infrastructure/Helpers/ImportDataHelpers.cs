using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Web.Models;
using LinqToExcel;
using Microsoft.Ajax.Utilities;

namespace Web.Infrastructure.Helpers
{
    public class ImportDataHelpers
    {
        public CheckResult CheckImportData(string fileName, List<Student> importStudent)
        {
            var result = new CheckResult();

            var targetFile = new FileInfo(fileName);

            if (!targetFile.Exists)
            {
                result.ID = Guid.NewGuid();
                result.Success = false;
                result.ErrorCount = 0;
                result.ErrorMessage = "匯入的資料檔案不存在";
                return result;
            }

            var excelFile = new ExcelQueryFactory(fileName);

            //欄位對映
            excelFile.AddMapping<Student>(x => x.SID, "SID");
            excelFile.AddMapping<Student>(x => x.CID, "CID");
            excelFile.AddMapping<Student>(x => x.SName, "SName");
            excelFile.AddMapping<Student>(x => x.SPassword, "SPassword");
            excelFile.AddMapping<Student>(x => x.Sex, "Sex");
            excelFile.AddMapping<Student>(x => x.Stage, "Stage");
            excelFile.AddMapping<Student>(x => x.Grade, "Grade");

            //SheetName
            var excelContent = excelFile.Worksheet<Student>("工作表1");

            int errorCount = 0;
            int rowIndex = 1;
            var importErrorMessages = new List<string>();

            //檢查資料
            foreach (var row in excelContent)
            {
                var errorMessage = new StringBuilder();
                var stu = new Student();

                stu.SID = row.SID;


                if (string.IsNullOrWhiteSpace(row.SID))
                {
                    errorMessage.Append("學生學號 - 不可空白. ");
                }
                else
                {
                    using (var db = new MoodleModel())
                    {
                        Student student = db.Students.Find(row.SID);
                        if (student != null)
                        {
                            errorMessage.Append("學生學號 - 已存在. ");
                        }
                    }
                }
                stu.SID = row.SID;


                if (string.IsNullOrWhiteSpace(row.SName))
                {
                    errorMessage.Append("學生姓名 - 不可空白. ");
                }
                stu.SName = row.SName;

                if (string.IsNullOrWhiteSpace(row.SPassword))
                {
                    errorMessage.Append("密碼 - 不可空白. ");
                }
                stu.SPassword = row.SPassword;

                if (string.IsNullOrWhiteSpace(row.CID))
                {
                    errorMessage.Append("課程編號 - 不可空白. ");
                }
                stu.CID = row.CID;

                if (string.IsNullOrWhiteSpace(row.Sex))
                {
                    errorMessage.Append("學生性別 - 不可空白. ");
                }
                stu.Sex = row.Sex;

                if (string.IsNullOrWhiteSpace(row.Stage))
                {
                    errorMessage.Append("教育階段 - 不可空白. ");
                }
                stu.Stage = row.Stage;

                if (string.IsNullOrWhiteSpace(row.Grade))
                {
                    errorMessage.Append("年級 - 不可空白. ");
                }
                stu.Grade = row.Grade;

                //=============================================================================
                if (errorMessage.Length > 0)
                {
                    errorCount += 1;
                    importErrorMessages.Add(string.Format(
                        "第 {0} 列資料發現錯誤：{1}{2}",
                        rowIndex,
                        errorMessage,
                        "<br/>"));
                }
                importStudent.Add(stu);
                rowIndex += 1;
            }

            try
            {
                result.ID = Guid.NewGuid();
                result.Success = errorCount.Equals(0);
                result.RowCount = importStudent.Count;
                result.ErrorCount = errorCount;

                string allErrorMessage = string.Empty;

                foreach (var message in importErrorMessages)
                {
                    allErrorMessage += message;
                }

                result.ErrorMessage = allErrorMessage;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Saves the import data.
        /// </summary>
        /// <param name="importZipCodes">The import zip codes.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SaveImportData(IEnumerable<Student> importStudent)
        {
            try
            {
                //先砍掉全部資料
                //using (var db = new TutorEntities())
                //{
                //    foreach (var item in db.Student.OrderBy(x => x.SID))
                //    {
                //        db.Student.Remove(item);
                //    }
                //    db.SaveChanges();
                //}

                //再把匯入的資料給存到資料庫
                using (var db = new MoodleModel())
                {
                    foreach (var item in importStudent)
                    {
                        db.Students.Add(item);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
