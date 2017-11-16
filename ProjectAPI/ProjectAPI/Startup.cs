using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using ProjectAPI.Helpers;

[assembly: OwinStartup(typeof(ProjectAPI.Startup))]

namespace ProjectAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Fixture.ScrapeData();
            ConfigureAuth(app);
        }
    }
}
