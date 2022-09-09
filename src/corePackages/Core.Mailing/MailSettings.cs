namespace Core.Mailing;

public class MailSettings {
    public String Server { get; set; }
    public Int32 Port { get; set; }
    public String SenderFullName { get; set; }
    public String SenderEmail { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }

    public MailSettings() { }

    public MailSettings(String server, Int32 port, String senderFullName, String senderEmail, String userName, String password) : this() {
        Server = server;
        Port = port;
        SenderFullName = senderFullName;
        SenderEmail = senderEmail;
        UserName = userName;
        Password = password;
    }
}