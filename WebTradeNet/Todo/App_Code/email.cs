using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
//using System.Web.Mail;
using System.Net;


/// <summary>
/// Summary description for email
/// </summary>
public class email
{
	public email()
	{
		//
		// TODO: Add constructor logic here
		//
	}   

    public bool MailSend(string Mailto, string MailSubject, string MailBody, string AttachedFileName )
     {
        

	    try {
		    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
		    MailMessage msg = new MailMessage("Email Id from", Mailto, MailSubject, MailBody);
            
		    string mto = null;
		    smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential("query@tradenetstockbroking.in", "query12");
		    //smtp.Credentials = new NetworkCredential("Email Id from", "password");
            
		    smtp.EnableSsl = true;
		    msg.IsBodyHtml = true;
		    msg.Subject = MailSubject;
		    msg.Body = MailBody;
		    mto = Mailto;
		    msg.IsBodyHtml = true;
		    smtp.Send(msg);
	    } catch (Exception ex) {
		    //SharedClas.TrakTrace(ex);
           
	    }

	    return true;
    }
            
 
}


