using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using communityThrive2;
using communityThrive2.Models;
using communityThrive2.Controllers;
using communityThrive2.DataControllers;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using communityThrive2.Models.communityThriveModels;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Services;
using System.Data.Entity;


namespace communityThrive2Tests
{
    [TestClass]
    public class categoryTests
    {
        //const string connectionstring = @"server=(localdb)\ProjectsV13;uid=ctUser;pwd=Password;database=communityThrive2DB;";

        [TestMethod]
        public void TestCreateCategory()
        {
            contentDataController contentDc = new contentDataController();

            contentDc.createCategory(1,"hello",true,true);

           

        }

        
        
    }
}
