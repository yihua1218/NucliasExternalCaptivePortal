using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;

namespace NucliasExternalCaptivePortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public StringValues ContinueUrl;
        public StringValues LoginUrl;
        public StringValues LogoutUrl;
        public StringValues ApName;
        public StringValues ApTags;
        public StringValues ApMac;
        public StringValues Mauth;
        public StringValues LoginResult;
        public StringValues DefaultUserName = "user1";
        public StringValues DefaultPassword = "password";
        public StringValues RadiusUserName;
        public StringValues RadiusPassword;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ContinueUrl = Request.Query["continue_url"];
            System.Console.WriteLine($"ContinueUrl is {ContinueUrl}");
            LoginUrl = Request.Query["login_url"];
            System.Console.WriteLine($"LoginUrl is {LoginUrl}");
            LogoutUrl = Request.Query["logout_url"];
            System.Console.WriteLine($"LogoutUrl is {LogoutUrl}");
            ApName = Request.Query["ap_name"];
            System.Console.WriteLine($"ApName is {ApName}");
            ApTags = Request.Query["ap_tags"];
            System.Console.WriteLine($"ApTags is {ApTags}");
            ApMac = Request.Query["ap_mac"];
            System.Console.WriteLine($"ApMac is {ApMac}");
            Mauth = Request.Query["mauth"];
            System.Console.WriteLine($"Mauth is {Mauth}");
            LoginResult = "";
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // perform action
            LoginResult = "Success";
        }
    }
}
