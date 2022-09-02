using MimeKit;

namespace Core.Mailing;

public class Mail {
	public String Subject { get; set; }
	public String TextBody { get; set; }
	public String HtmlBody { get; set; }
	public AttachmentCollection? Attachments { get; set; }
	public String ToFullName { get; set; }
	public String ToEmail { get; set; }

	public Mail() { }

	public Mail(String subject, String textBody, String htmlBody, AttachmentCollection? attachments, String toFullName, String toEmail) : this() {
		Subject = subject;
		TextBody = textBody;
		HtmlBody = htmlBody;
		Attachments = attachments;
		ToFullName = toFullName;
		ToEmail = toEmail;
	}
}