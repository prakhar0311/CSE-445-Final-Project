using Hotel_Application_445.ServicesRef;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;

namespace YourNamespace
{
    public partial class Login : System.Web.UI.Page
    {
        private void RegenerateCaptcha()
        {
            Tuple<string, Bitmap> captcha = GenerateCaptcha();
            string base64String = GetBase64StringForImage(captcha.Item2);
            Image_Captcha.ImageUrl = "data:image/png;base64," + base64String;
            Session["Captcha"] = captcha.Item1;
        }

        private Tuple<string, Bitmap> GenerateCaptcha()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string captcha = new string(
                Enumerable.Repeat(chars, 6)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            Bitmap bmp = new Bitmap(200, 50);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.DrawString(captcha, new Font("Arial", 20), new SolidBrush(Color.Black), new PointF(10, 10));

            return new Tuple<string, Bitmap>(captcha, bmp);
        }

        private string GetBase64StringForImage(Bitmap image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegenerateCaptcha();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (Service1Client service1 = new Service1Client())
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string enteredCaptcha = TextBox_inputCaptcha.Text.Trim();

                try
                {
                    string correctCaptcha = Session["Captcha"] as string;

                    if (string.IsNullOrEmpty(correctCaptcha) ||
                        !string.Equals(enteredCaptcha, correctCaptcha, StringComparison.OrdinalIgnoreCase))
                    {
                        lblCaptchaError.Text = "Incorrect Captcha. Please try again.";
                        return;
                    }

                    lblCaptchaError.Text = "";

                    SetCookie("Username", username);
                    SetCookie("Password", password);

                    bool result = service1.login(username, password);

                    if (result)
                    {
                        if (service1.isStaff(username))
                        {
                            Response.Redirect("~/StaffDashBoard.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Login failed. Please check your credentials.');", true);
                    }
                }
                catch (CommunicationException ex)
                {
                    lblCaptchaError.Text = "Communication error: " + ex.Message;
                }
                catch (Exception ex)
                {
                    lblCaptchaError.Text = "An unexpected error occurred during login: " + ex.Message;
                }
            }
        }


        private void SetCookie(string name, string value)
        {
            HttpCookie cookie = new HttpCookie(name, value);
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }
    }
}
