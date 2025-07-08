// This file is used by Code Analysis to maintain SuppressMessage

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance", "CA1848:Use the LoggerMessage delegates", Justification = "Pending migration to LoggerMessage.", Scope = "member", Target = "~T:GtMotive.Estimate.Microservice.Infrastructure.Logging.LoggerAdapter`1")]
[assembly: SuppressMessage("Usage", "CA2254:Template should be a static expression", Justification = "Pending migration to LoggerMessage.", Scope = "member", Target = "~T:GtMotive.Estimate.Microservice.Infrastructure.Logging.LoggerAdapter`1")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Not null. From dependency injection.", Scope = "member", Target = "~M:GtMotive.Estimate.Microservice.Infrastructure.MongoDb.MongoService.#ctor(Microsoft.Extensions.Options.IOptions{GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings.MongoDbSettings})")]
