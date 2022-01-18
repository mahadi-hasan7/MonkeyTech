using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using System.Data;
using System.Data.SqlClient;

namespace s_ecws.admin
{
    public partial class add_product : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shakil\source\repos\s_ecws\s_ecws\App_Data\shopping.mdf;Integrated Security=True");
        String a, b;

        

        protected void Page_Load(object sender, EventArgs e)
        {

            //note: 
                //String type decleare kora lagbe, cause ImageUrl er system er String type input nei, string na

            //String PathOfImage = "";
            //PathOfImage += "../product_images/213007622_877693309493820_8972727898832016991_n.jpg";
            //uploadedImage.ImageUrl = PathOfImage.ToString();
            //System.Diagnostics.Debug.Write(PathOfImage);
        }









        protected void uploadNewProduct_Click(object sender, EventArgs e)
        {
            //f1.SaveAs(Request.PhysicalApplicationPath+"./product_images/"+f1.FileName.ToString());
            //https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.fileupload.saveas?view=netframework-4.8
            string fileName = "";
            if (imageFile.HasFile)
                fileName = SaveFile(imageFile.PostedFile);
            else
                UploadStatusLabel.Text = "You did not specify a file to upload.";



            //for database path
            // we will use this path to restore the image from product_images folder
            b = "../product_images/" + fileName;

            System.Diagnostics.Debug.Write(b);
            con.Open();


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into product values('" + productName.Text + "','" + productDescription.Text + "','" + productPrice.Text + "','" + productQuantity.Text + "','" + b.ToString() + "')";
            cmd.ExecuteNonQuery();
            con.Close();


            //uploadedImage.ImageUrl = b.ToString();
        }



        string SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            string savePath = "C:\\Users\\shakil\\source\\repos\\s_ecws\\s_ecws\\product_images\\";
            string fileName = imageFile.FileName;
            string pathToCheck = savePath + fileName;
            string tempfileName = "";
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }
                fileName = tempfileName;
                UploadStatusLabel.Text = "A file with the same name already exists." +
                    "<br />Your file was saved as " + fileName;
            }
            else
            {
                UploadStatusLabel.Text = "Your file was uploaded successfully.";
            }
            savePath += fileName;
            imageFile.SaveAs(savePath);

            System.Diagnostics.Debug.Write(savePath);

            return fileName;
        }
    }
}