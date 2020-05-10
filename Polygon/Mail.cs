using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Polygon
{
    public partial class Mail : Form
    {
        public Mail(string stringemail)
        {
            InitializeComponent();
            textBox1.Text = stringemail;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //smtp должен совпадать с почтой
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            //пароль и логин от почты 
            smtp.Credentials = new NetworkCredential("login", "pass");
            smtp.EnableSsl = true;
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("login", "Золотой код");
            // кому отправляем
            MailAddress to = new MailAddress(textBox1.Text);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = textBox2.Text; ;
            // текст письма
            m.Body = "<h2>"+textBox3.Text+"</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            smtp.Send(m);
        }
    }
}
