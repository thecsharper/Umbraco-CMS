﻿using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Umbraco.Cms.Core.Configuration;
using Umbraco.Cms.Tests.Common.Testing;
using Umbraco.Cms.Tests.Integration.Testing;
using Umbraco.Core.Migrations.Install;

namespace Umbraco.Cms.Tests.Integration.Umbraco.Infrastructure.Persistence
{
    [TestFixture]
    [UmbracoTest(Database = UmbracoTestOptions.Database.NewSchemaPerFixture)]
    public class SchemaValidationTest : UmbracoIntegrationTest
    {
        private IUmbracoVersion UmbracoVersion => GetRequiredService<IUmbracoVersion>();

        [Test]
        public void DatabaseSchemaCreation_Produces_DatabaseSchemaResult_With_Zero_Errors()
        {
            DatabaseSchemaResult result;

            using (var scope = ScopeProvider.CreateScope())
            {
                var schema = new DatabaseSchemaCreator(scope.Database, LoggerFactory.CreateLogger<DatabaseSchemaCreator>(), LoggerFactory, UmbracoVersion);
                result = schema.ValidateSchema(DatabaseSchemaCreator.OrderedTables);
            }

            // Assert
            Assert.That(result.Errors.Count, Is.EqualTo(0));
        }
    }
}