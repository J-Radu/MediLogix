namespace MediLogix.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly IConfiguration _configuration;
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUsername;
    private readonly string _smtpPassword;
    private readonly string _senderEmail;
    private readonly string _senderName;
    private readonly bool _useSsl;
    private readonly string _appBaseUrl;

    public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        
        _smtpServer = _configuration["EmailSettings:SmtpServer"];
        _smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
        _smtpUsername = _configuration["EmailSettings:SmtpUsername"];
        _smtpPassword = _configuration["EmailSettings:SmtpPassword"];
        _senderEmail = _configuration["EmailSettings:SenderEmail"];
        _senderName = _configuration["EmailSettings:SenderName"];
        _useSsl = bool.Parse(_configuration["EmailSettings:UseSsl"]);
        _appBaseUrl = _configuration["AppSettings:BaseUrl"];
    }

    public async Task SendPasswordResetEmailAsync(string email, string resetToken)
    {
        bool isLocalDevelopment = _configuration["AppSettings:IsLocalDevelopment"]?.ToLower() == "true";
        
        if (isLocalDevelopment)
        {
            _logger.LogInformation("Token de resetare pentru {Email}: {Token}", email, resetToken);
            await Task.CompletedTask;
            return;
        }

        string encodedToken = WebUtility.UrlEncode(resetToken);
        string encodedEmail = WebUtility.UrlEncode(email);
        string resetUrl = $"{_appBaseUrl}/reset-password?email={encodedEmail}&token={encodedToken}";
        
        string subject = "Resetare parolă MediLogix";
        string body = $@"
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; }}
                    .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                    .header {{ background-color: #4A89DC; color: white; padding: 10px; text-align: center; }}
                    .content {{ padding: 20px; }}
                    .button {{ display: inline-block; background-color: #4A89DC; color: white; padding: 10px 20px; 
                              text-decoration: none; border-radius: 5px; margin: 20px 0; }}
                    .footer {{ font-size: 12px; color: #777; margin-top: 30px; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>
                        <h2>Resetare Parolă MediLogix</h2>
                    </div>
                    <div class='content'>
                        <p>Dragă utilizator,</p>
                        <p>Am primit o cerere de resetare a parolei pentru contul tău. Pentru a-ți reseta parola, 
                           te rugăm să faci click pe butonul de mai jos:</p>
                        <p><a href='{resetUrl}' class='button'>Resetează Parola</a></p>
                        <p>Sau copiază și lipește următorul link în browser:</p>
                        <p>{resetUrl}</p>
                        <p>Acest link va expira în 24 de ore. Dacă nu ai solicitat resetarea parolei, 
                           te rugăm să ignori acest email.</p>
                        <p>Cu stimă,<br>Echipa MediLogix</p>
                    </div>
                    <div class='footer'>
                        <p>Acest email a fost trimis automat. Te rugăm să nu răspunzi la acest email.</p>
                    </div>
                </div>
            </body>
            </html>";

        await SendEmailAsync(email, subject, body);
    }

    public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
    {
        try
        {
            using var client = new SmtpClient(_smtpServer, _smtpPort);
            client.EnableSsl = _useSsl;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);

            using var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_senderEmail, _senderName);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isHtml;

            mailMessage.To.Add(to);

            await client.SendMailAsync(mailMessage);
            _logger.LogInformation("Email trimis cu succes către {Email}", to);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Eroare la trimiterea email-ului către {Email}: {Message}", to, ex.Message);
            throw;
        }
    }
} 